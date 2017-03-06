using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Enum ExifDataTypes
    /// </summary>
    public enum ExifDataTypes : short
    {
        /// <summary>
        /// The unsigned byte
        /// </summary>
        UnsignedByte = 1,
        /// <summary>
        /// The ASCII string
        /// </summary>
        AsciiString = 2,
        /// <summary>
        /// The unsigned short
        /// </summary>
        UnsignedShort = 3,
        /// <summary>
        /// The unsigned long
        /// </summary>
        UnsignedLong = 4,
        /// <summary>
        /// The unsigned rational
        /// </summary>
        UnsignedRational = 5,
        /// <summary>
        /// The signed byte
        /// </summary>
        SignedByte = 6,
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined = 7,
        /// <summary>
        /// The signed short
        /// </summary>
        SignedShort = 8,
        /// <summary>
        /// The signed long
        /// </summary>
        SignedLong = 9,
        /// <summary>
        /// The signed rational
        /// </summary>
        SignedRational = 10,
        /// <summary>
        /// The single float
        /// </summary>
        SingleFloat = 11,
        /// <summary>
        /// The double float
        /// </summary>
        DoubleFloat = 12
    }
}

