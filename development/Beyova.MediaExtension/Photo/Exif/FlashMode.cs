using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Enum FlashMode
    /// </summary>
    public enum FlashMode
    {
        /// <summary>
        /// The not fired
        /// </summary>
        NotFired = 0,
        /// <summary>
        /// The fired
        /// </summary>
        Fired = 1,
        /// <summary>
        /// The fired but no strobe returned
        /// </summary>
        FiredButNoStrobeReturned = 5,
        /// <summary>
        /// The fired and strobe returned
        /// </summary>
        FiredAndStrobeReturned = 7,
    }
}

