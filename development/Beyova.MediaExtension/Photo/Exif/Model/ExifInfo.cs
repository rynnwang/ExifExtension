using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
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
        public double ResolutionX { get; set; }

        /// <summary>
        /// Gets or sets the resolution y. (dpi)
        /// </summary>
        /// <value>The resolution y.</value>
        public double ResolutionY { get; set; }

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

        public DateTime? DigitizedStamp { get; set; }

        public DateTime? OriginalStamp { get; set; }

        public DateTime? LastUpdatedStamp { get; set; }
    }
}

