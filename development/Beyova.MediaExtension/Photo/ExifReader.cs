using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beyova.Media.Exif;

namespace Beyova.Media
{
    public class ExifOperator : IDisposable
    {
        protected System.Drawing.Bitmap _image;
        protected System.Text.Encoding _Encoding = System.Text.Encoding.UTF8;
        protected const string datetimeFormat = @"yyyy\:MM\:dd HH\:mm\:ss";

        #region Type declarations

        /// <summary>
        /// Struct RationalObject
        /// </summary>
        public struct RationalObject
        {
            public Int32 Numerator { get; set; }

            public Int32 Denominator { get; set; }

            public override string ToString()
            {
                return ToString("/");
            }

            public string ToString(string delimiter)
            {
                return Numerator + "/" + Denominator;
            }

            public double ToDouble()
            {
                return (double)Numerator / Denominator;
            }
        }

        #endregion

        protected ExifOperator(Bitmap bitmap)
        {
            this._image = bitmap;
        }

        public override string ToString()
        {
            System.Text.StringBuilder SB = new StringBuilder();

            SB.Append("Image:");


            SB.Append("\nShooting conditions:");
            SB.Append("\n\tExposure time: " + this.ExposureTime.ToString("N4") + " s");
            SB.Append("\n\tExposure program: " + Enum.GetName(typeof(ExposurePrograms), this.ExposureProgram));
            SB.Append("\n\tExposure mode: " + Enum.GetName(typeof(ExposureMeteringModes), this.ExposureMeteringMode));
            SB.Append("\n\tAperture: F" + this.Aperture.ToString("N2"));
            SB.Append("\n\tISO sensitivity: " + this.ISO);
            SB.Append("\n\tSubject distance: " + this.SubjectDistance.ToString("N2") + " m");
            SB.Append("\n\tFocal length: " + this.FocalLength);
            SB.Append("\n\tFlash: " + Enum.GetName(typeof(FlashMode), this.FlashMode));
            SB.Append("\n\tLight source (WB): " + Enum.GetName(typeof(LightSource), this.LightSource));
            //SB.Replace("\n", vbCrLf);
            //SB.Replace("\t", vbTab);
            return SB.ToString();
        }

        #region Nicely formatted well-known properties

        public string EquipmentMaker
        {
            get
            {
                return this.GetPropertyString(ExifProperty.EquipMake);
            }
        }

        public string EquipmentModel
        {
            get
            {
                return this.GetPropertyString(ExifProperty.EquipModel);
            }
        }

        public string Software
        {
            get
            {
                return this.GetPropertyString(ExifProperty.SoftwareUsed);
            }
        }

        public Beyova.Media.Exif.Orientation Orientation
        {
            get
            {
                Int32 X = this.GetPropertyInt16(Beyova.Media.Exif.ExifProperty.Orientation);

                if (!Enum.IsDefined(typeof(Orientation), X))
                    return Orientation.TopLeft;
                else
                    return (Orientation)Enum.Parse(typeof(Orientation), Enum.GetName(typeof(Orientation), X));
            }
        }

        public DateTime LastUpdatedStamp
        {
            get
            {
                try
                {
                    return DateTime.ParseExact(this.GetPropertyString(ExifProperty.DateTime), datetimeFormat, null);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                try
                {
                    this.SetPropertyString(ExifProperty.DateTime, value.ToString(datetimeFormat));
                }
                catch
                { }
            }
        }

        public DateTime OriginalDateTime
        {
            get
            {
                try
                {
                    return DateTime.ParseExact(this.GetPropertyString(ExifProperty.ExifDTOrig), datetimeFormat, null);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                try
                {
                    this.SetPropertyString(ExifProperty.ExifDTOrig, value.ToString(datetimeFormat));
                }
                catch
                { }
            }
        }

        public DateTime? DigitizedStamp
        {
            get
            {
                DateTime dateTime;
                return DateTime.TryParseExact(this.GetPropertyString(ExifProperty.ExifDTDigitized), datetimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime) ? dateTime : null as DateTime?;
            }
            set
            {
                this.SetPropertyString(ExifProperty.ExifDTDigitized, value.HasValue ? value.Value.ToString(datetimeFormat) : string.Empty);
            }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public Int32 Width
        {
            get { return this._image.Width; }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public Int32 Height
        {
            get { return this._image.Height; }
        }

        /// <summary>
        /// Gets the resolution x.
        /// </summary>
        /// <value>The resolution x.</value>
        public double ResolutionX
        {
            get
            {
                double R = this.GetPropertyRational(ExifProperty.XResolution).ToDouble();

                if (this.GetPropertyInt16(ExifProperty.ResolutionUnit) == 3)
                {
                    // Resolution unit: points/cm
                    return R * 2.54;
                }
                else
                {
                    // Resolution unit: points/inch
                    return R;
                }
            }
        }

        /// <summary>
        /// Gets the resolution y.
        /// </summary>
        /// <value>The resolution y.</value>
        public double ResolutionY
        {
            get
            {
                double R = this.GetPropertyRational(ExifProperty.YResolution).ToDouble();

                if (this.GetPropertyInt16(ExifProperty.ResolutionUnit) == 3)
                {
                    // Resolution unit: points/cm
                    return R * 2.54;
                }
                else
                {
                    // Resolution unit: points/inch
                    return R;
                }
            }
        }

        public string Title
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ImageTitle);
            }
            set
            {
                try
                {
                    this.SetPropertyString(ExifProperty.ImageTitle, value);
                }
                catch { }
            }
        }

        public string UserComment
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ExifUserComment);
            }
            set
            {
                this.SetPropertyString(ExifProperty.ExifUserComment, value);
            }
        }

        public string Artist
        {
            get
            {
                return this.GetPropertyString(ExifProperty.Artist);
            }
            set
            {
                this.SetPropertyString(ExifProperty.Artist, value);
            }
        }

        public string Description
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ImageDescription);
            }
            set
            {
                this.SetPropertyString(ExifProperty.ImageDescription, value);
            }
        }

        public string Copyright
        {
            get
            {
                return this.GetPropertyString(ExifProperty.Copyright);
            }
            set
            {
                this.SetPropertyString(ExifProperty.Copyright, value);
            }
        }

        public double? ExposureTimeAbs
        {
            get
            {
                if (this.IsPropertyDefined(ExifProperty.ExifExposureTime))
                {
                    return this.GetPropertyRational(ExifProperty.ExifExposureTime).ToDouble();
                }
                else if (this.IsPropertyDefined(ExifProperty.ExifShutterSpeed))
                {
                    return (1 / Math.Pow(2, this.GetPropertyRational(ExifProperty.ExifShutterSpeed).ToDouble()));
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the exposure time.
        /// </summary>
        /// <value>The exposure time.</value>
        public RationalObject ExposureTime
        {
            get
            {
                return this.IsPropertyDefined(ExifProperty.ExifExposureTime) ? this.GetPropertyRational(ExifProperty.ExifExposureTime) : new RationalObject();
            }
        }

        public double Aperture
        {
            get
            {
                if (this.IsPropertyDefined(ExifProperty.ExifFNumber))
                    return this.GetPropertyRational(ExifProperty.ExifFNumber).ToDouble();
                else
                if (this.IsPropertyDefined(ExifProperty.ExifAperture))
                    return Math.Pow(System.Math.Sqrt(2), this.GetPropertyRational(ExifProperty.ExifAperture).ToDouble());
                else
                    return 0;
            }
        }

        public ExposurePrograms ExposureProgram
        {
            get
            {
                Int32 X = this.GetPropertyInt16(ExifProperty.ExifExposureProg);

                if (Enum.IsDefined(typeof(ExposurePrograms), X))
                    return (ExposurePrograms)Enum.Parse(typeof(ExposurePrograms), Enum.GetName(typeof(ExposurePrograms), X));
                else
                    return ExposurePrograms.Normal;
            }
        }

        public Int16 ISO
        {
            get { return this.GetPropertyInt16(ExifProperty.ExifISOSpeed); }
        }

        public double SubjectDistance
        {
            get { return this.GetPropertyRational(ExifProperty.ExifSubjectDist).ToDouble(); }
        }

        public ExposureMeteringModes ExposureMeteringMode
        {
            get
            {
                Int32 X = this.GetPropertyInt16(ExifProperty.ExifMeteringMode);

                if (Enum.IsDefined(typeof(ExposureMeteringModes), X))
                    return (ExposureMeteringModes)Enum.Parse(typeof(ExposureMeteringModes), Enum.GetName(typeof(ExposureMeteringModes), X));
                else
                    return ExposureMeteringModes.Unknown;
            }
        }

        public double FocalLength
        {
            get { return this.GetPropertyRational(ExifProperty.ExifFocalLength).ToDouble(); }
        }

        public FlashMode FlashMode
        {
            get
            {
                Int32 X = this.GetPropertyInt16(ExifProperty.ExifFlash);

                if (Enum.IsDefined(typeof(FlashMode), X))
                    return (FlashMode)Enum.Parse(typeof(FlashMode), Enum.GetName(typeof(FlashMode), X));
                else
                    return FlashMode.NotFired;
            }
        }

        public LightSource LightSource
        {
            get
            {
                Int32 X = this.GetPropertyInt16(ExifProperty.ExifLightSource);

                if (Enum.IsDefined(typeof(LightSource), X))
                    return (LightSource)Enum.Parse(typeof(LightSource), Enum.GetName(typeof(LightSource), X));
                else
                    return LightSource.Unknown;
            }
        }

        #endregion

        #region Support methods for working with EXIF properties

        /// <summary>
        /// Determines whether [is property defined] [the specified property identifier].
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <returns><c>true</c> if [is property defined] [the specified property identifier]; otherwise, <c>false</c>.</returns>
        protected bool IsPropertyDefined(ExifProperty propertyId)
        {
            return (Array.IndexOf(this._image.PropertyIdList, (int)propertyId) > -1);
        }

        /// <summary>
        /// Gets the property int32.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Int32.</returns>
        protected Int32 GetPropertyInt32(ExifProperty propertyId, Int32 defaultValue = 0)
        {
            return IsPropertyDefined(propertyId) ? GetInt32(this._image.GetPropertyItem((int)propertyId).Value) : defaultValue;
        }

        /// <summary>
        /// Gets the property int16.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Int16.</returns>
        protected Int16 GetPropertyInt16(ExifProperty propertyId, Int16 defaultValue = 0)
        {
            return IsPropertyDefined(propertyId) ? GetInt16(this._image.GetPropertyItem((int)propertyId).Value) : defaultValue;
        }

        /// <summary>
        /// Gets the property string.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        protected string GetPropertyString(ExifProperty propertyId, string defaultValue = "")
        {
            return IsPropertyDefined(propertyId) ? GetString(this._image.GetPropertyItem((int)propertyId).Value) : defaultValue;
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Byte[].</returns>
        protected byte[] GetProperty(ExifProperty propertyId, byte[] defaultValue = null)
        {
            return IsPropertyDefined(propertyId) ? this._image.GetPropertyItem((int)propertyId).Value : defaultValue;
        }

        /// <summary>
        /// Gets the property rational.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <returns>Rational.</returns>
        protected RationalObject GetPropertyRational(ExifProperty propertyId)
        {
            return (IsPropertyDefined(propertyId)) ? GetRational(this._image.GetPropertyItem((int)propertyId).Value) : new RationalObject
            {
                Numerator = 0,
                Denominator = 1
            };
        }

        #region SetProperty

        /// <summary>
        /// Sets the property string.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="value">The value.</param>
        protected void SetPropertyString(ExifProperty propertyId, string value)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value.SafeToString() + '\0');
            SetProperty(propertyId, data, ExifDataTypes.AsciiString);
        }

        /// <summary>
        /// Sets the property int16.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="value">The value.</param>
        protected void SetPropertyInt16(ExifProperty propertyId, Int16 value)
        {
            byte[] data = new byte[2] {
                (byte)(value & 0xFF),
                (byte)((value & 0xFF00) >> 8) };

            SetProperty(propertyId, data, ExifDataTypes.SignedShort);
        }

        /// <summary>
        /// Sets the property int32.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="value">The value.</param>
        protected void SetPropertyInt32(ExifProperty propertyId, Int32 value)
        {
            byte[] data = new byte[4];
            for (int I = 0; I < 4; I++)
            {
                data[I] = (byte)(value & 0xFF);
                value >>= 8;
            }
            SetProperty(propertyId, data, ExifDataTypes.SignedLong);
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        protected void SetProperty(ExifProperty propertyId, byte[] data, ExifDataTypes type)
        {
            try
            {
                var property = this._image.PropertyItems[0];
                property.Id = (int)propertyId;
                property.Value = data;
                property.Type = (Int16)type;
                property.Len = data.Length;
                this._image.SetPropertyItem(property);
            }
            catch (Exception ex)
            {
                throw ex.Handle(new { propertyId, type });
            }
        }

        #endregion

        /// <summary>
        /// Gets the int32.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Int32.</returns>
        /// <exception cref="ExceptionSystem.FriendlyHint"></exception>
        protected Int32 GetInt32(byte[] data)
        {
            if (data == null || data.Length < 4)
            {
                throw ExceptionFactory.CreateInvalidObjectException(nameof(data), data, hint: new ExceptionSystem.FriendlyHint { Message = "Data too short (4 bytes expected)" });
            }

            return data[3] << 24 | data[2] << 16 | data[1] << 8 | data[0];
        }

        /// <summary>
        /// Gets the int16.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Int16.</returns>
        /// <exception cref="ExceptionSystem.FriendlyHint"></exception>
        protected Int16 GetInt16(byte[] data)
        {
            if (data == null || data.Length < 2)
            {
                throw ExceptionFactory.CreateInvalidObjectException(nameof(data), data, hint: new ExceptionSystem.FriendlyHint { Message = "Data too short (2 bytes expected)" });
            }

            return (short)(data[1] << 8 | data[0]);
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        protected string GetString(byte[] data)
        {
            return data == null ? string.Empty : System.Text.Encoding.UTF8.GetString(data).TrimEnd('\0');
        }

        /// <summary>
        /// Gets the rational.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>RationalObject.</returns>
        protected RationalObject GetRational(byte[] data)
        {
            if (data == null)
            {
                return default(RationalObject);
            }

            byte[] N = new byte[4];
            byte[] D = new byte[4];

            Array.Copy(data, 0, N, 0, 4);
            Array.Copy(data, 4, D, 0, 4);
            return new RationalObject
            {
                Denominator = this.GetInt32(D),
                Numerator = this.GetInt32(N)
            };
        }

        #endregion

        public ExifInfo ReadAsExifInfo()
        {
            var result = new ExifInfo
            {
                Width = this._image.Width,
                Height = this._image.Height,
                ResolutionX = this.ResolutionX,
                ResolutionY = this.ResolutionY,
                Orientation = this.Orientation,
                Title = this.Title,
                Description = this.Description,
                Copyright = this.Copyright,
                LastUpdatedStamp=this.DateTimeLastModified,
                DigitizedStamp = this.DigitizedStamp,

            };



            SB.Append("\nEquipment:");
            SB.Append("\n\tMaker: " + this.EquipmentMaker);
            SB.Append("\n\tModel: " + this.EquipmentModel);
            SB.Append("\n\tSoftware: " + this.Software);
            SB.Append("\nDate and time:");
            SB.Append("\n\tGeneral: " + this.DateTimeLastModified.ToString());
            SB.Append("\n\tOriginal: " + this.OriginalDateTime.ToString());
            SB.Append("\n\tDigitized: " + this.DigitizedStamp.ToString());

            return result;
        }

        public void Dispose()
        {
            this._image.Dispose();
        }

        #region Static Methods

        /// <summary>
        /// Creates the reader.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>ExifReader.</returns>
        public static ExifOperator CreateReader(Bitmap bitmap)
        {
            bitmap.CheckNullObject(nameof(bitmap));
            return new ExifOperator(bitmap.Clone() as Bitmap);
        }

        #endregion

    }

}
