using System;
using System.IO;
using Beyova.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beyova.MediaExtension.UnitTest
{
    [TestClass]
    public class ExifOperatorUnitTest
    {
        [TestMethod]
        public void ReadExif()
        {
            var path = Path.Combine(EnvironmentCore.ApplicationBaseDirectory, @"TestData\IMG_1864.JPG");
            var exifOperator = ExifOperator.CreateOperator(path);
            var exifInfo=exifOperator.ReadAsExifInfo();

            Assert.IsNotNull(exifInfo);
        }
    }
}
