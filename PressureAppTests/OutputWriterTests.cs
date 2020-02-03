using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutPutWriter;
using OutPutWriter.Enums;
using Pressure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace PressureAppTests
{
    [TestClass]
    public class OutputWriterTests
    {
        [TestMethod]
        public void TestPersist()
        {
            // Arrange
            var repo = new PressureReadingRepository();
            var reading = new PressureReading()
            {
                SensorName = "A",
                RawValue = 1,
                BAR = 2,
                PSI = 3,
                TimeStamp = DateTimeOffset.Now
            };

            var list = new List<PressureReading>() { reading };
        }
    }
}
