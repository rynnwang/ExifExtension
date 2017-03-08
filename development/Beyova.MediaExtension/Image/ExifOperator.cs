using System;
using System.Drawing;
using System.Globalization;
using Beyova.Media.Exif;

namespace Beyova.Media
{
    /// <summary>
    /// Class ExifOperator.
    /// </summary>
    public class ExifOperator : IDisposable
    {
        /// <summary>
        /// The _image
        /// </summary>
        protected System.Drawing.Bitmap _image;

        /// <summary>
        /// The dateTime format
        /// </summary>
        protected const string dateTimeFormat = @"yyyy\:MM\:dd HH\:mm\:ss";

        /// <summary>
        /// Initializes a new instance of the <see cref="ExifOperator" /> class.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        protected ExifOperator(Bitmap bitmap)
        {
            this._image = bitmap;
        }

        #region Nicely formatted well-known properties

        /// <summary>
        /// Gets the equipment maker.
        /// </summary>
        /// <value>The equipment maker.</value>
        public string EquipmentMaker
        {
            get
            {
                return this.GetPropertyString(ExifProperty.EquipMake);
            }
        }

        /// <summary>
        /// Gets the equipment model.
        /// </summary>
        /// <value>The equipment model.</value>
        public string EquipmentModel
        {
            get
            {
                return this.GetPropertyString(ExifProperty.EquipModel);
            }
        }

        /// <summary>
        /// Gets the software.
        /// </summary>
        /// <value>The software.</value>
        public string Software
        {
            get
            {
                return this.GetPropertyString(ExifProperty.SoftwareUsed);
            }
        }

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                Int32 x = this.GetPropertyInt16(Beyova.Media.Exif.ExifProperty.Orientation);
                return x.ParseToEnum<Orientation>(Orientation.TopLeft);
            }
        }

        /// <summary>
        /// Gets or sets the last updated stamp.
        /// </summary>
        /// <value>The last updated stamp.</value>
        public DateTime? LastUpdatedStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.DateTime).ToDateTime(dateTimeFormat, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                this.SetPropertyString(ExifProperty.DateTime, value.ToString(dateTimeFormat));
            }
        }

        /// <summary>
        /// Gets or sets the original stamp.
        /// </summary>
        /// <value>The original stamp.</value>
        public DateTime? OriginalStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ExifDTOrig).ToDateTime(dateTimeFormat, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                this.SetPropertyString(ExifProperty.ExifDTOrig, value.ToString(dateTimeFormat));
            }
        }

        /// <summary>
        /// Gets or sets the digitized stamp.
        /// </summary>
        /// <value>The digitized stamp.</value>
        public DateTime? DigitizedStamp
        {
            get
            {
                return this.GetPropertyString(ExifProperty.ExifDTDigitized).ToDateTime(dateTimeFormat, DateTimeStyles.AssumeUniversal);
            }
            set
            {
                this.SetPropertyString(ExifProperty.ExifDTDigitized, value.ToString(dateTimeFormat));
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
        public double? ResolutionX
        {
            get
            {
                var resolution = this.GetPropertyFractionObject(ExifProperty.XResolution).ToDouble();

                if (resolution.HasValue)
                {
                    if (this.GetPropertyInt16(ExifProperty.ResolutionUnit) == 3)
                    {
                        // Resolution unit: points/cm
                        return resolution.Value * 2.54;
                    }
                    else
                    {
                        // Resolution unit: points/inch
                        return resolution.Value;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the resolution y.
        /// </summary>
        /// <value>The resolution y.</value>
        public double? ResolutionY
        {
            get
            {
                var resolution = this.GetPropertyFractionObject(ExifProperty.YResolution).ToDouble();

                if (resolution.HasValue)
                {
                    if (this.GetPropertyInt16(ExifProperty.ResolutionUnit) == 3)
                    {
                        // Resolution unit: points/cm
                        return resolution.Value * 2.54;
                    }
                    else
                    {
                        // Resolution unit: points/inch
                        return resolution.Value;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the longtitude.
        /// </summary>
        /// <value>The longtitude.</value>
        public double? Longtitude
        {
            get
            {
                var resolution = this.GetPropertyFractionObject(ExifProperty.XResolution).ToDouble();

                if (resolution.HasValue)
                {
                    if (this.GetPropertyInt16(ExifProperty.ResolutionUnit) == 3)
                    {
                        // Resolution unit: points/cm
                        return resolution.Value * 2.54;
                    }
                    else
                    {
                        // Resolution unit: points/inch
                        return resolution.Value;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
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
                    return this.GetPropertyFractionObject(ExifProperty.ExifExposureTime).ToDouble();
                }
                else if (this.IsPropertyDefined(ExifProperty.ExifShutterSpeed))
                {
                    var tmp = this.GetPropertyFractionObject(ExifProperty.ExifShutterSpeed).ToDouble();

                    return tmp.HasValue ? (1 / Math.Pow(2, tmp.Value)) as double? : null;
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
        public FractionObject? ExposureTime
        {
            get
            {
                return this.IsPropertyDefined(ExifProperty.ExifExposureTime) ? this.GetPropertyFractionObject(ExifProperty.ExifExposureTime) : null;
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
                    return this.GetPropertyFractionObject(ExifProperty.ExifFNumber).ToDouble();
                }
                else if (this.IsPropertyDefined(ExifProperty.ExifAperture))
                {
                    var tmp = this.GetPropertyFractionObject(ExifProperty.ExifAperture).ToDouble();
                    return tmp.HasValue ? Math.Pow(System.Math.Sqrt(2), tmp.Value) as double? : null;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the exposure program.
        /// </summary>
        /// <value>The exposure program.</value>
        public ExposureProgram ExposureProgram
        {
            get
            {
                Int32 x = this.GetPropertyInt16(ExifProperty.ExifExposureProg);
                return x.ParseToEnum<ExposureProgram>(ExposureProgram.Normal);
            }
        }

        /// <summary>
        /// Gets the iso.
        /// </summary>
        /// <value>The iso.</value>
        public Int16 ISO
        {
            get { return this.GetPropertyInt16(ExifProperty.ExifISOSpeed); }
        }

        /// <summary>
        /// Gets the subject distance.
        /// </summary>
        /// <value>The subject distance.</value>
        public double? SubjectDistance
        {
            get { return this.GetPropertyFractionObject(ExifProperty.ExifSubjectDist).ToDouble(); }
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
        public double? FocalLength
        {
            get { return this.GetPropertyFractionObject(ExifProperty.ExifFocalLength).ToDouble(); }
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

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public GeoCoordinate? Latitude
        {
            get { return this.GetPropertyGeoCoordinate(ExifProperty.GpsLatitude); }
        }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public GeoCoordinate? Longitude
        {
            get { return this.GetPropertyGeoCoordinate(ExifProperty.GpsLongitude); }
        }

        #endregion

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
        protected FractionObject? GetPropertyFractionObject(ExifProperty propertyId)
        {
            return (IsPropertyDefined(propertyId)) ? GetFractionObject(this._image.GetPropertyItem((int)propertyId).Value) : null;
        }

        /// <summary>
        /// Gets the property geo coordinate.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <returns>System.Nullable&lt;GeoPosition&gt;.</returns>
        protected GeoCoordinate? GetPropertyGeoCoordinate(ExifProperty propertyId)
        {
            return (IsPropertyDefined(propertyId)) ? GetGeoCoordinate(this._image.GetPropertyItem((int)propertyId).Value) : null;
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

        #region GetXXX

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
        protected FractionObject? GetFractionObject(byte[] data)
        {
            if (data == null)
            {
                return null;
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

        /// <summary>
        /// Gets the geo coordinate.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.Nullable&lt;GeoCoordinate&gt;.</returns>
        protected GeoCoordinate? GetGeoCoordinate(byte[] data)
        {
            if (data == null || data.Length != 24)
            {
                return null;
            }

            byte[] tmp = new byte[8];
            Array.Copy(data, 0, tmp, 0, 8);
            var degree = GetFractionObject(tmp);
            if (!degree.HasValue)
            {
                return null;
            }

            Array.Copy(data, 8, tmp, 0, 8);
            var minutes = GetFractionObject(tmp);
            if (!minutes.HasValue)
            {
                return null;
            }

            Array.Copy(data, 16, tmp, 0, 8);
            var seconds = GetFractionObject(tmp);

            if (!seconds.HasValue)
            {
                return null;
            }

            return new GeoCoordinate
            {
                Degrees = (int)(degree.Value.ToDouble()),
                Minutes = (int)(minutes.Value.ToDouble()),
                Seconds = (int)(seconds.Value.ToDouble())
            };
        }

        #endregion

        /// <summary>
        /// Reads as exif information.
        /// </summary>
        /// <returns>ExifInfo.</returns>
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
                FocalLength = this.FocalLength,
                GeoPosition = (this.Latitude.HasValue && this.Longitude.HasValue) ? new GeoPosition
                {
                    Latitude = this.Latitude.Value,
                    Longitude = this.Longitude.Value
                } as GeoPosition? : null
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
        /// Creates the operator.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>ExifOperator.</returns>
        public static ExifOperator CreateOperator(Bitmap bitmap)
        {
            bitmap.CheckNullObject(nameof(bitmap));
            return new ExifOperator(bitmap.Clone() as Bitmap);
        }

        /// <summary>
        /// Creates the operator.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>ExifOperator.</returns>
        public static ExifOperator CreateOperator(string path)
        {
            path.CheckEmptyString(nameof(path));
            return new ExifOperator(Bitmap.FromFile(path) as Bitmap);
        }

        #endregion
    }

}
