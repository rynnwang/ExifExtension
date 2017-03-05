using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Enum ExposureMeteringMode
    /// </summary>
    public enum ExposureMeteringMode
    {
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The average
        /// </summary>
        Average = 1,
        /// <summary>
        /// The center weighted average
        /// </summary>
        CenterWeightedAverage = 2,
        /// <summary>
        /// The spot
        /// </summary>
        Spot = 3,
        /// <summary>
        /// The multi spot
        /// </summary>
        MultiSpot = 4,
        /// <summary>
        /// The multi segment
        /// </summary>
        MultiSegment = 5,
        /// <summary>
        /// The partial
        /// </summary>
        Partial = 6,
        /// <summary>
        /// The other
        /// </summary>
        Other = 255
    }
}

