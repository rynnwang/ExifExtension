using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Class ExifInfo.
    /// </summary>
    public class ExifInfo
    {
        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation? Orientation { get; set; }

        /// <summary>
        /// Gets or sets the light source.
        /// </summary>
        /// <value>The light source.</value>
        public LightSource? LightSource { get; set; }

        /// <summary>
        /// Gets or sets the flash mode.
        /// </summary>
        /// <value>The flash mode.</value>
        public FlashMode? FlashMode { get; set; }

        /// <summary>
        /// Gets or sets the height. (px)
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width. (px)
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the resolution x. (dpi)
        /// </summary>
        /// <value>The resolution x.</value>
        public double? ResolutionX { get; set; }

        /// <summary>
        /// Gets or sets the resolution y. (dpi)
        /// </summary>
        /// <value>The resolution y.</value>
        public double? ResolutionY { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        /// <value>The copyright.</value>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the digitized stamp.
        /// </summary>
        /// <value>The digitized stamp.</value>
        public DateTime? DigitizedStamp { get; set; }

        /// <summary>
        /// Gets or sets the original stamp.
        /// </summary>
        /// <value>The original stamp.</value>
        public DateTime? OriginalStamp { get; set; }

        /// <summary>
        /// Gets or sets the last updated stamp.
        /// </summary>
        /// <value>The last updated stamp.</value>
        public DateTime? LastUpdatedStamp { get; set; }

        /// <summary>
        /// Gets or sets the software.
        /// </summary>
        /// <value>The software.</value>
        public string Software { get; set; }

        /// <summary>
        /// Gets or sets the equipment maker.
        /// </summary>
        /// <value>The equipment maker.</value>
        public string EquipmentMaker { get; set; }

        /// <summary>
        /// Gets or sets the equipment model.
        /// </summary>
        /// <value>The equipment model.</value>
        public string EquipmentModel { get; set; }

        /// <summary>
        /// Gets or sets the exposure time.
        /// </summary>
        /// <value>The exposure time.</value>
        public FractionObject? ExposureTime { get; set; }

        /// <summary>
        /// Gets or sets the exposure program.
        /// </summary>
        /// <value>The exposure program.</value>
        public ExposureProgram? ExposureProgram { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>The artist.</value>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the user comment.
        /// </summary>
        /// <value>The user comment.</value>
        public string UserComment { get; set; }

        /// <summary>
        /// Gets or sets the exposure metering mode.
        /// </summary>
        /// <value>The exposure metering mode.</value>
        public ExposureMeteringMode? ExposureMeteringMode { get; set; }

        /// <summary>
        /// Gets or sets the aperture.
        /// </summary>
        /// <value>The aperture.</value>
        public double? Aperture { get; set; }

        /// <summary>
        /// Gets or sets the iso.
        /// </summary>
        /// <value>The iso.</value>
        public Int16? ISO { get; set; }

        /// <summary>
        /// Gets or sets the subject distance.
        /// </summary>
        /// <value>The subject distance.</value>
        public double? SubjectDistance { get; set; }

        /// <summary>
        /// Gets or sets the length of the focal.
        /// </summary>
        /// <value>The length of the focal.</value>
        public double? FocalLength { get; set; }

        /// <summary>
        /// Gets or sets the geo position.
        /// </summary>
        /// <value>The geo position.</value>
        public GeoPosition? GeoPosition { get; set; }
    }
}

