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

        protected ExifOperator(Bitmap bitmap)
        {
            this._image = bitmap;
        }

        public override string ToString()
        {
            System.Text.StringBuilder SB = new StringBuilder();

            SB.Append("Image:");



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

        public DateTime? LastUpdatedStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.DateTime).ToDateTime(datetimeFormat, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                this.SetPropertyString(ExifProperty.DateTime, value.HasValue ? value.Value.ToString(datetimeFormat) : string.Empty);
            }
        }

        public DateTime? OriginalStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ExifDTOrig).ToDateTime(datetimeFormat, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                this.SetPropertyString(ExifProperty.ExifDTOrig, value.HasValue ? value.Value.ToString(datetimeFormat) : string.Empty);
            }
        }

        public DateTime? DigitizedStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ExifDTDigitized).ToDateTime(datetimeFormat, DateTimeStyles.AssumeUniversal);
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
                this.SetPropertyString(ExifProperty.ImageTitle, value);
            }
        }

        /// <summary>
        /// Gets or sets the user comment.
        /// </summary>
        /// <value>The user comment.</value>
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

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>The artist.</value>
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

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
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

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>The copyright.</value>
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

        /// <summary>
        /// Gets the exposure time abs.
        /// </summary>
        /// <value>The exposure time abs.</value>
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
        public FractionObject ExposureTime
        {
            get
            {
                return this.IsPropertyDefined(ExifProperty.ExifExposureTime) ? this.GetPropertyRational(ExifProperty.ExifExposureTime) : new FractionObject();
            }
        }

        /// <summary>
        /// Gets the aperture.
        /// </summary>
        /// <value>The aperture.</value>
        public double? Aperture
        {
            get
            {
                if (this.IsPropertyDefined(ExifProperty.ExifFNumber))
                {
                    return this.GetPropertyRational(ExifProperty.ExifFNumber).ToDouble();
                }
                else if (this.IsPropertyDefined(ExifProperty.ExifAperture))
                {
                    return Math.Pow(System.Math.Sqrt(2), this.GetPropertyRational(ExifProperty.ExifAperture).ToDouble());
                }
                else
                {
                    return null;
                }
            }
        }

        public ExposureProgram ExposureProgram
        {
            get
            {
                Int32 x = this.GetPropertyInt16(ExifProperty.ExifExposureProg);
                return x.ParseToEnum<ExposureProgram>(ExposureProgram.Normal);
            }
        }

        public Int16 ISO
        {
            get { return this.GetPropertyInt16(ExifProperty.ExifISOSpeed); }
        }

        /// <summary>
        /// Gets the subject distance.
        /// </summary>
        /// <value>The subject distance.</value>
        public double SubjectDistance
        {
            get { return this.GetPropertyRational(ExifProperty.ExifSubjectDist).ToDouble(); }
        }

        /// <summary>
        /// Gets the exposure metering mode.
        /// </summary>
        /// <value>The exposure metering mode.</value>
        public ExposureMeteringMode ExposureMeteringMode
        {
            get
            {
                Int32 x = this.GetPropertyInt16(ExifProperty.ExifMeteringMode);
                return x.ParseToEnum<ExposureMeteringMode>(ExposureMeteringMode.Unknown);
            }
        }

        /// <summary>
        /// Gets the length of the focal.
        /// </summary>
        /// <value>The length of the focal.</value>
        public double FocalLength
        {
            get { return this.GetPropertyRational(ExifProperty.ExifFocalLength).ToDouble(); }
        }

        /// <summary>
        /// Gets the flash mode.
        /// </summary>
        /// <value>The flash mode.</value>
        public FlashMode FlashMode
        {
            get
            {
                Int32 x = this.GetPropertyInt16(ExifProperty.ExifFlash);
                return x.ParseToEnum<FlashMode>(FlashMode.NotFired);
            }
        }

        /// <summary>
        /// Gets the light source.
        /// </summary>
        /// <value>The light source.</value>
        public LightSource LightSource
        {
            get
            {
                Int32 x = this.GetPropertyInt16(ExifProperty.ExifLightSource);
                return x.ParseToEnum<LightSource>(LightSource.Unknown);
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

        #region GetProperty

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
        protected FractionObject GetPropertyRational(ExifProperty propertyId)
        {
            return (IsPropertyDefined(propertyId)) ? GetRational(this._image.GetPropertyItem((int)propertyId).Value) : new FractionObject
            {
                Numerator = 0,
                Denominator = 1
            };
        }

        #endregion

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
        protected FractionObject GetRational(byte[] data)
        {
            if (data == null)
            {
                return default(FractionObject);
            }

            byte[] N = new byte[4];
            byte[] D = new byte[4];

            Array.Copy(data, 0, N, 0, 4);
            Array.Copy(data, 4, D, 0, 4);
            return new FractionObject
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
                LastUpdatedStamp = this.LastUpdatedStamp,
                DigitizedStamp = this.DigitizedStamp,
                OriginalStamp = this.OriginalStamp,
                Software = this.Software,
                EquipmentMaker = this.EquipmentMaker,
                EquipmentModel = this.EquipmentModel,
                ExposureTime = this.ExposureTime,
                ExposureProgram = this.ExposureProgram,
                Artist = this.Artist,
                UserComment = this.UserComment,
                LightSource = this.LightSource,
                FlashMode = this.FlashMode,
                ExposureMeteringMode = this.ExposureMeteringMode,
                Aperture = this.Aperture,
                ISO = this.ISO,
                SubjectDistance = this.SubjectDistance,
                FocalLength = this.FocalLength
            };

            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
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
