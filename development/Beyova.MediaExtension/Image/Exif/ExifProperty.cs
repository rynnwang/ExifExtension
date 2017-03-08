using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyova.Media.Exif
{
    /// <summary>
    /// Enum ExifProperty
    /// </summary>
    public enum ExifProperty
    {
        /// <summary>
        /// The exif ifd
        /// </summary>
        ExifIFD = 0x8769,
        /// <summary>
        /// The GPS ifd
        /// </summary>
        GpsIFD = 0x8825,
        /// <summary>
        /// The new subfile type
        /// </summary>
        NewSubfileType = 0xFE,
        /// <summary>
        /// The subfile type
        /// </summary>
        SubfileType = 0xFF,
        /// <summary>
        /// The image width
        /// </summary>
        ImageWidth = 0x100,
        /// <summary>
        /// The image height
        /// </summary>
        ImageHeight = 0x101,
        /// <summary>
        /// The bits per sample
        /// </summary>
        BitsPerSample = 0x102,
        /// <summary>
        /// The compression
        /// </summary>
        Compression = 0x103,
        /// <summary>
        /// The photometric interp
        /// </summary>
        PhotometricInterp = 0x106,
        /// <summary>
        /// The thresh holding
        /// </summary>
        ThreshHolding = 0x107,
        /// <summary>
        /// The cell width
        /// </summary>
        CellWidth = 0x108,
        /// <summary>
        /// The cell height
        /// </summary>
        CellHeight = 0x109,
        /// <summary>
        /// The fill order
        /// </summary>
        FillOrder = 0x10A,
        /// <summary>
        /// The document name
        /// </summary>
        DocumentName = 0x10D,
        /// <summary>
        /// The image description
        /// </summary>
        ImageDescription = 0x10E,
        /// <summary>
        /// The equip make
        /// </summary>
        EquipMake = 0x10F,
        /// <summary>
        /// The equip model
        /// </summary>
        EquipModel = 0x110,
        /// <summary>
        /// The strip offsets
        /// </summary>
        StripOffsets = 0x111,
        /// <summary>
        /// The orientation
        /// </summary>
        Orientation = 0x112,
        /// <summary>
        /// The samples per pixel
        /// </summary>
        SamplesPerPixel = 0x115,
        /// <summary>
        /// The rows per strip
        /// </summary>
        RowsPerStrip = 0x116,
        /// <summary>
        /// The strip bytes count
        /// </summary>
        StripBytesCount = 0x117,
        /// <summary>
        /// The minimum sample value
        /// </summary>
        MinSampleValue = 0x118,
        /// <summary>
        /// The maximum sample value
        /// </summary>
        MaxSampleValue = 0x119,
        /// <summary>
        /// The x resolution
        /// </summary>
        XResolution = 0x11A,
        /// <summary>
        /// The y resolution
        /// </summary>
        YResolution = 0x11B,
        /// <summary>
        /// The planar configuration
        /// </summary>
        PlanarConfig = 0x11C,
        /// <summary>
        /// The page name
        /// </summary>
        PageName = 0x11D,
        /// <summary>
        /// The x position
        /// </summary>
        XPosition = 0x11E,
        /// <summary>
        /// The y position
        /// </summary>
        YPosition = 0x11F,
        /// <summary>
        /// The free offset
        /// </summary>
        FreeOffset = 0x120,
        /// <summary>
        /// The free byte counts
        /// </summary>
        FreeByteCounts = 0x121,
        /// <summary>
        /// The gray response unit
        /// </summary>
        GrayResponseUnit = 0x122,
        /// <summary>
        /// The gray response curve
        /// </summary>
        GrayResponseCurve = 0x123,
        /// <summary>
        /// The t4 option
        /// </summary>
        T4Option = 0x124,
        /// <summary>
        /// The t6 option
        /// </summary>
        T6Option = 0x125,
        /// <summary>
        /// The resolution unit
        /// </summary>
        ResolutionUnit = 0x128,
        /// <summary>
        /// The page number
        /// </summary>
        PageNumber = 0x129,
        /// <summary>
        /// The transfer funcition
        /// </summary>
        TransferFuncition = 0x12D,
        /// <summary>
        /// The software used
        /// </summary>
        SoftwareUsed = 0x131,
        /// <summary>
        /// The date time
        /// </summary>
        DateTime = 0x132,
        /// <summary>
        /// The artist
        /// </summary>
        Artist = 0x13B,
        /// <summary>
        /// The host computer
        /// </summary>
        HostComputer = 0x13C,
        /// <summary>
        /// The predictor
        /// </summary>
        Predictor = 0x13D,
        /// <summary>
        /// The white point
        /// </summary>
        WhitePoint = 0x13E,
        /// <summary>
        /// The primary chromaticities
        /// </summary>
        PrimaryChromaticities = 0x13F,
        /// <summary>
        /// The color map
        /// </summary>
        ColorMap = 0x140,
        /// <summary>
        /// The halftone hints
        /// </summary>
        HalftoneHints = 0x141,
        /// <summary>
        /// The tile width
        /// </summary>
        TileWidth = 0x142,
        /// <summary>
        /// The tile length
        /// </summary>
        TileLength = 0x143,
        /// <summary>
        /// The tile offset
        /// </summary>
        TileOffset = 0x144,
        /// <summary>
        /// The tile byte counts
        /// </summary>
        TileByteCounts = 0x145,
        /// <summary>
        /// The ink set
        /// </summary>
        InkSet = 0x14C,
        /// <summary>
        /// The ink names
        /// </summary>
        InkNames = 0x14D,
        /// <summary>
        /// The number of inks
        /// </summary>
        NumberOfInks = 0x14E,
        /// <summary>
        /// The dot range
        /// </summary>
        DotRange = 0x150,
        /// <summary>
        /// The target printer
        /// </summary>
        TargetPrinter = 0x151,
        /// <summary>
        /// The extra samples
        /// </summary>
        ExtraSamples = 0x152,
        /// <summary>
        /// The sample format
        /// </summary>
        SampleFormat = 0x153,
        /// <summary>
        /// The s minimum sample value
        /// </summary>
        SMinSampleValue = 0x154,
        /// <summary>
        /// The s maximum sample value
        /// </summary>
        SMaxSampleValue = 0x155,
        /// <summary>
        /// The transfer range
        /// </summary>
        TransferRange = 0x156,
        /// <summary>
        /// The JPEG proc
        /// </summary>
        JPEGProc = 0x200,
        /// <summary>
        /// The JPEG inter format
        /// </summary>
        JPEGInterFormat = 0x201,
        /// <summary>
        /// The JPEG inter length
        /// </summary>
        JPEGInterLength = 0x202,
        /// <summary>
        /// The JPEG restart interval
        /// </summary>
        JPEGRestartInterval = 0x203,
        /// <summary>
        /// The JPEG lossless predictors
        /// </summary>
        JPEGLosslessPredictors = 0x205,
        /// <summary>
        /// The JPEG point transforms
        /// </summary>
        JPEGPointTransforms = 0x206,
        /// <summary>
        /// The jpegq tables
        /// </summary>
        JPEGQTables = 0x207,
        /// <summary>
        /// The jpegdc tables
        /// </summary>
        JPEGDCTables = 0x208,
        /// <summary>
        /// The jpegac tables
        /// </summary>
        JPEGACTables = 0x209,
        /// <summary>
        /// The y cb cr coefficients
        /// </summary>
        YCbCrCoefficients = 0x211,
        /// <summary>
        /// The y cb cr subsampling
        /// </summary>
        YCbCrSubsampling = 0x212,
        /// <summary>
        /// The y cb cr positioning
        /// </summary>
        YCbCrPositioning = 0x213,
        /// <summary>
        /// The reference black white
        /// </summary>
        REFBlackWhite = 0x214,
        /// <summary>
        /// The icc profile
        /// </summary>
        ICCProfile = 0x8773,
        /// <summary>
        /// The gamma
        /// </summary>
        Gamma = 0x301,
        /// <summary>
        /// The icc profile descriptor
        /// </summary>
        ICCProfileDescriptor = 0x302,
        /// <summary>
        /// The SRGB rendering intent
        /// </summary>
        SRGBRenderingIntent = 0x303,
        /// <summary>
        /// The image title
        /// </summary>
        ImageTitle = 0x320,
        /// <summary>
        /// The copyright
        /// </summary>
        Copyright = 0x8298,
        /// <summary>
        /// The resolution x unit
        /// </summary>
        ResolutionXUnit = 0x5001,
        /// <summary>
        /// The resolution y unit
        /// </summary>
        ResolutionYUnit = 0x5002,
        /// <summary>
        /// The resolution x length unit
        /// </summary>
        ResolutionXLengthUnit = 0x5003,
        /// <summary>
        /// The resolution y length unit
        /// </summary>
        ResolutionYLengthUnit = 0x5004,
        /// <summary>
        /// The print flags
        /// </summary>
        PrintFlags = 0x5005,
        /// <summary>
        /// The print flags version
        /// </summary>
        PrintFlagsVersion = 0x5006,
        /// <summary>
        /// The print flags crop
        /// </summary>
        PrintFlagsCrop = 0x5007,
        /// <summary>
        /// The print flags bleed width
        /// </summary>
        PrintFlagsBleedWidth = 0x5008,
        /// <summary>
        /// The print flags bleed width scale
        /// </summary>
        PrintFlagsBleedWidthScale = 0x5009,
        /// <summary>
        /// The halftone lpi
        /// </summary>
        HalftoneLPI = 0x500A,
        /// <summary>
        /// The halftone lpi unit
        /// </summary>
        HalftoneLPIUnit = 0x500B,
        /// <summary>
        /// The halftone degree
        /// </summary>
        HalftoneDegree = 0x500C,
        /// <summary>
        /// The halftone shape
        /// </summary>
        HalftoneShape = 0x500D,
        /// <summary>
        /// The halftone misc
        /// </summary>
        HalftoneMisc = 0x500E,
        /// <summary>
        /// The halftone screen
        /// </summary>
        HalftoneScreen = 0x500F,
        /// <summary>
        /// The JPEG quality
        /// </summary>
        JPEGQuality = 0x5010,
        /// <summary>
        /// The grid size
        /// </summary>
        GridSize = 0x5011,
        /// <summary>
        /// The thumbnail format
        /// </summary>
        ThumbnailFormat = 0x5012,
        /// <summary>
        /// The thumbnail width
        /// </summary>
        ThumbnailWidth = 0x5013,
        /// <summary>
        /// The thumbnail height
        /// </summary>
        ThumbnailHeight = 0x5014,
        /// <summary>
        /// The thumbnail color depth
        /// </summary>
        ThumbnailColorDepth = 0x5015,
        /// <summary>
        /// The thumbnail planes
        /// </summary>
        ThumbnailPlanes = 0x5016,
        /// <summary>
        /// The thumbnail raw bytes
        /// </summary>
        ThumbnailRawBytes = 0x5017,
        /// <summary>
        /// The thumbnail size
        /// </summary>
        ThumbnailSize = 0x5018,
        /// <summary>
        /// The thumbnail compressed size
        /// </summary>
        ThumbnailCompressedSize = 0x5019,
        /// <summary>
        /// The color transfer function
        /// </summary>
        ColorTransferFunction = 0x501A,
        /// <summary>
        /// The thumbnail data
        /// </summary>
        ThumbnailData = 0x501B,
        /// <summary>
        /// The thumbnail image width
        /// </summary>
        ThumbnailImageWidth = 0x5020,
        /// <summary>
        /// The thumbnail image height
        /// </summary>
        ThumbnailImageHeight = 0x502,
        /// <summary>
        /// The thumbnail bits per sample
        /// </summary>
        ThumbnailBitsPerSample = 0x5022,
        /// <summary>
        /// The thumbnail compression
        /// </summary>
        ThumbnailCompression = 0x5023,
        /// <summary>
        /// The thumbnail photometric interp
        /// </summary>
        ThumbnailPhotometricInterp = 0x5024,
        /// <summary>
        /// The thumbnail image description
        /// </summary>
        ThumbnailImageDescription = 0x5025,
        /// <summary>
        /// The thumbnail equip make
        /// </summary>
        ThumbnailEquipMake = 0x5026,
        /// <summary>
        /// The thumbnail equip model
        /// </summary>
        ThumbnailEquipModel = 0x5027,
        /// <summary>
        /// The thumbnail strip offsets
        /// </summary>
        ThumbnailStripOffsets = 0x5028,
        /// <summary>
        /// The thumbnail orientation
        /// </summary>
        ThumbnailOrientation = 0x5029,
        /// <summary>
        /// The thumbnail samples per pixel
        /// </summary>
        ThumbnailSamplesPerPixel = 0x502A,
        /// <summary>
        /// The thumbnail rows per strip
        /// </summary>
        ThumbnailRowsPerStrip = 0x502B,
        /// <summary>
        /// The thumbnail strip bytes count
        /// </summary>
        ThumbnailStripBytesCount = 0x502C,
        /// <summary>
        /// The thumbnail resolution x
        /// </summary>
        ThumbnailResolutionX = 0x502D,
        /// <summary>
        /// The thumbnail resolution y
        /// </summary>
        ThumbnailResolutionY = 0x502E,
        /// <summary>
        /// The thumbnail planar configuration
        /// </summary>
        ThumbnailPlanarConfig = 0x502F,
        /// <summary>
        /// The thumbnail resolution unit
        /// </summary>
        ThumbnailResolutionUnit = 0x5030,
        /// <summary>
        /// The thumbnail transfer function
        /// </summary>
        ThumbnailTransferFunction = 0x5031,
        /// <summary>
        /// The thumbnail software used
        /// </summary>
        ThumbnailSoftwareUsed = 0x5032,
        /// <summary>
        /// The thumbnail date time
        /// </summary>
        ThumbnailDateTime = 0x5033,
        /// <summary>
        /// The thumbnail artist
        /// </summary>
        ThumbnailArtist = 0x5034,
        /// <summary>
        /// The thumbnail white point
        /// </summary>
        ThumbnailWhitePoint = 0x5035,
        /// <summary>
        /// The thumbnail primary chromaticities
        /// </summary>
        ThumbnailPrimaryChromaticities = 0x5036,
        /// <summary>
        /// The thumbnail y cb cr coefficients
        /// </summary>
        ThumbnailYCbCrCoefficients = 0x5037,
        /// <summary>
        /// The thumbnail y cb cr subsampling
        /// </summary>
        ThumbnailYCbCrSubsampling = 0x5038,
        /// <summary>
        /// The thumbnail y cb cr positioning
        /// </summary>
        ThumbnailYCbCrPositioning = 0x5039,
        /// <summary>
        /// The thumbnail reference black white
        /// </summary>
        ThumbnailRefBlackWhite = 0x503A,
        /// <summary>
        /// The thumbnail copy right
        /// </summary>
        ThumbnailCopyRight = 0x503B,
        /// <summary>
        /// The luminance table
        /// </summary>
        LuminanceTable = 0x5090,
        /// <summary>
        /// The chrominance table
        /// </summary>
        ChrominanceTable = 0x5091,
        /// <summary>
        /// The frame delay
        /// </summary>
        FrameDelay = 0x5100,
        /// <summary>
        /// The loop count
        /// </summary>
        LoopCount = 0x5101,
        /// <summary>
        /// The pixel unit
        /// </summary>
        PixelUnit = 0x5110,
        /// <summary>
        /// The pixel per unit x
        /// </summary>
        PixelPerUnitX = 0x5111,
        /// <summary>
        /// The pixel per unit y
        /// </summary>
        PixelPerUnitY = 0x5112,
        /// <summary>
        /// The palette histogram
        /// </summary>
        PaletteHistogram = 0x5113,
        /// <summary>
        /// The exif exposure time
        /// </summary>
        ExifExposureTime = 0x829A,
        /// <summary>
        /// The exif f number
        /// </summary>
        ExifFNumber = 0x829D,
        /// <summary>
        /// The exif exposure prog
        /// </summary>
        ExifExposureProg = 0x8822,
        /// <summary>
        /// The exif spectral sense
        /// </summary>
        ExifSpectralSense = 0x8824,
        /// <summary>
        /// The exif iso speed
        /// </summary>
        ExifISOSpeed = 0x8827,
        /// <summary>
        /// The exif oecf
        /// </summary>
        ExifOECF = 0x8828,
        /// <summary>
        /// The exif ver
        /// </summary>
        ExifVer = 0x9000,
        /// <summary>
        /// The exif dt original
        /// </summary>
        ExifDTOrig = 0x9003,
        /// <summary>
        /// The exif dt digitized
        /// </summary>
        ExifDTDigitized = 0x9004,
        /// <summary>
        /// The exif comp configuration
        /// </summary>
        ExifCompConfig = 0x9101,
        /// <summary>
        /// The exif comp BPP
        /// </summary>
        ExifCompBPP = 0x9102,
        /// <summary>
        /// The exif shutter speed
        /// </summary>
        ExifShutterSpeed = 0x9201,
        /// <summary>
        /// The exif aperture
        /// </summary>
        ExifAperture = 0x9202,
        /// <summary>
        /// The exif brightness
        /// </summary>
        ExifBrightness = 0x9203,
        /// <summary>
        /// The exif exposure bias
        /// </summary>
        ExifExposureBias = 0x9204,
        /// <summary>
        /// The exif maximum aperture
        /// </summary>
        ExifMaxAperture = 0x9205,
        /// <summary>
        /// The exif subject dist
        /// </summary>
        ExifSubjectDist = 0x9206,
        /// <summary>
        /// The exif metering mode
        /// </summary>
        ExifMeteringMode = 0x9207,
        /// <summary>
        /// The exif light source
        /// </summary>
        ExifLightSource = 0x9208,
        /// <summary>
        /// The exif flash
        /// </summary>
        ExifFlash = 0x9209,
        /// <summary>
        /// The exif focal length
        /// </summary>
        ExifFocalLength = 0x920A,
        /// <summary>
        /// The exif maker note
        /// </summary>
        ExifMakerNote = 0x927C,
        /// <summary>
        /// The exif user comment
        /// </summary>
        ExifUserComment = 0x9286,
        /// <summary>
        /// The exif dt subsec
        /// </summary>
        ExifDTSubsec = 0x9290,
        /// <summary>
        /// The exif dt original ss
        /// </summary>
        ExifDTOrigSS = 0x9291,
        /// <summary>
        /// The exif dt dig ss
        /// </summary>
        ExifDTDigSS = 0x9292,
        /// <summary>
        /// The exif FPX ver
        /// </summary>
        ExifFPXVer = 0xA000,
        /// <summary>
        /// The exif color space
        /// </summary>
        ExifColorSpace = 0xA001,
        /// <summary>
        /// The exif pix x dim
        /// </summary>
        ExifPixXDim = 0xA002,
        /// <summary>
        /// The exif pix y dim
        /// </summary>
        ExifPixYDim = 0xA003,
        /// <summary>
        /// The exif related wav
        /// </summary>
        ExifRelatedWav = 0xA004,
        /// <summary>
        /// The exif interop
        /// </summary>
        ExifInterop = 0xA005,
        /// <summary>
        /// The exif flash energy
        /// </summary>
        ExifFlashEnergy = 0xA20B,
        /// <summary>
        /// The exif spatial fr
        /// </summary>
        ExifSpatialFR = 0xA20C,
        /// <summary>
        /// The exif focal x resource
        /// </summary>
        ExifFocalXRes = 0xA20E,
        /// <summary>
        /// The exif focal y resource
        /// </summary>
        ExifFocalYRes = 0xA20F,
        /// <summary>
        /// The exif focal resource unit
        /// </summary>
        ExifFocalResUnit = 0xA210,
        /// <summary>
        /// The exif subject loc
        /// </summary>
        ExifSubjectLoc = 0xA214,
        /// <summary>
        /// The exif exposure index
        /// </summary>
        ExifExposureIndex = 0xA215,
        /// <summary>
        /// The exif sensing method
        /// </summary>
        ExifSensingMethod = 0xA217,
        /// <summary>
        /// The exif file source
        /// </summary>
        ExifFileSource = 0xA300,
        /// <summary>
        /// The exif scene type
        /// </summary>
        ExifSceneType = 0xA301,
        /// <summary>
        /// The exif cfa pattern
        /// </summary>
        ExifCfaPattern = 0xA302,
        /// <summary>
        /// The GPS ver
        /// </summary>
        GpsVer = 0x0,
        /// <summary>
        /// The GPS latitude reference
        /// </summary>
        GpsLatitudeRef = 0x1,
        /// <summary>
        /// The GPS latitude
        /// </summary>
        GpsLatitude = 0x2,
        /// <summary>
        /// The GPS longitude reference
        /// </summary>
        GpsLongitudeRef = 0x3,
        /// <summary>
        /// The GPS longitude
        /// </summary>
        GpsLongitude = 0x4,
        /// <summary>
        /// The GPS altitude reference
        /// </summary>
        GpsAltitudeRef = 0x5,
        /// <summary>
        /// The GPS altitude
        /// </summary>
        GpsAltitude = 0x6,
        /// <summary>
        /// The GPS GPS time
        /// </summary>
        GpsGpsTime = 0x7,
        /// <summary>
        /// The GPS GPS satellites
        /// </summary>
        GpsGpsSatellites = 0x8,
        /// <summary>
        /// The GPS GPS status
        /// </summary>
        GpsGpsStatus = 0x9,
        /// <summary>
        /// The GPS GPS measure mode
        /// </summary>
        GpsGpsMeasureMode = 0xA,
        /// <summary>
        /// The GPS GPS dop
        /// </summary>
        GpsGpsDop = 0xB,
        /// <summary>
        /// The GPS speed reference
        /// </summary>
        GpsSpeedRef = 0xC,
        /// <summary>
        /// The GPS speed
        /// </summary>
        GpsSpeed = 0xD,
        /// <summary>
        /// The GPS track reference
        /// </summary>
        GpsTrackRef = 0xE,
        /// <summary>
        /// The GPS track
        /// </summary>
        GpsTrack = 0xF,
        /// <summary>
        /// The GPS img dir reference
        /// </summary>
        GpsImgDirRef = 0x10,
        /// <summary>
        /// The GPS img dir
        /// </summary>
        GpsImgDir = 0x11,
        /// <summary>
        /// The GPS map datum
        /// </summary>
        GpsMapDatum = 0x12,
        /// <summary>
        /// The GPS dest lat reference
        /// </summary>
        GpsDestLatRef = 0x13,
        /// <summary>
        /// The GPS dest lat
        /// </summary>
        GpsDestLat = 0x14,
        /// <summary>
        /// The GPS dest long reference
        /// </summary>
        GpsDestLongRef = 0x15,
        /// <summary>
        /// The GPS dest long
        /// </summary>
        GpsDestLong = 0x16,
        /// <summary>
        /// The GPS dest bear reference
        /// </summary>
        GpsDestBearRef = 0x17,
        /// <summary>
        /// The GPS dest bear
        /// </summary>
        GpsDestBear = 0x18,
        /// <summary>
        /// The GPS dest dist reference
        /// </summary>
        GpsDestDistRef = 0x19,
        /// <summary>
        /// The GPS dest dist
        /// </summary>
        GpsDestDist = 0x1A
    }

}

