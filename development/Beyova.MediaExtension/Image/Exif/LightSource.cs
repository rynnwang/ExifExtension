using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Enum LightSource
    /// </summary>
    public enum LightSource
    {
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The daylight
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// The fluorescent
        /// </summary>
        Fluorescent = 2,
        /// <summary>
        /// The tungsten
        /// </summary>
        Tungsten = 3,
        /// <summary>
        /// The flash
        /// </summary>
        Flash = 10,
        /// <summary>
        /// The standard light a
        /// </summary>
        StandardLightA = 17,
        /// <summary>
        /// The standard light b
        /// </summary>
        StandardLightB = 18,
        /// <summary>
        /// The standard light c
        /// </summary>
        StandardLightC = 19,
        /// <summary>
        /// The D55
        /// </summary>
        D55 = 20,
        /// <summary>
        /// The D65
        /// </summary>
        D65 = 21,
        /// <summary>
        /// The D75
        /// </summary>
        D75 = 22,
        /// <summary>
        /// The other
        /// </summary>
        Other = 255
    }
}

