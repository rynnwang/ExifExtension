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
        NotFired = 0,
        Fired = 1,
        FiredButNoStrobeReturned = 5,
        FiredAndStrobeReturned = 7,
    }
}

