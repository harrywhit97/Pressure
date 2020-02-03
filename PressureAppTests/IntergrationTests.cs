using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PressureAppTests.Helpers;
using PressureCore.Concrete;
using PressureCore.Interfaces;

namespace PressureAppTests
{
    [TestClass]
    public class IntergrationTests
    {

        [TestMethod]
        public void End_to_end_works_with_2_sensors()
        {
            // Arrange
            var serialReader = new Mock<ISerialReader>();
            serialReader.Setup(x => x.ReadLine()).Returns("A1,123,A2,594");

            var calculator = PressureCalculatorHelper.BuildCalulator();
            var timestamp = new DateTimeOffset(2020, 02, 02, 0, 0, 0, TimeSpan.Zero);
            // Act
            RawDataProcessor.ParseRawDataToPressureReadings(serialReader.Object.ReadLine(), calculator,timestamp);
            

            // Assert
        }

    }
}
