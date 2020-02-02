using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PressureCore.Concrete;
using System;

namespace PressureAppTests
{
    [TestClass]
    public class PressureCoreTests
    {
        [TestMethod]
        public void RawDataProcessor_parses_data_correctly()
        {
            // Arrange
            var rawData = "A1,209,A2,549";
            var timestamp = new DateTimeOffset(2020, 02, 02, 0, 0, 0, TimeSpan.Zero);

            var calculatorMock = new Mock<PressureCalculator>();
            calculatorMock.Setup(x => x.CalculateBAR(It.IsAny<int>())).Returns(10);
            calculatorMock.Setup(x => x.CalculatePSI(It.IsAny<int>())).Returns(11);

            // Act
            var readings = RawDataProcessor.ParseRawDataToPressureReadings(rawData, calculatorMock.Object, timestamp);

            // Assert
            readings.Count.Should().Be(2);
            var reading = readings[0];

            reading.RawValue.Should().Be(209);
            reading.TimeStamp.Should().Be(timestamp);
            reading.SensorName.Should().Be("A1");
            reading.BAR.Should().Be(10);
            reading.PSI.Should().Be(11);

            reading = readings[1];
            reading.RawValue.Should().Be(549);
            reading.TimeStamp.Should().Be(timestamp);
            reading.SensorName.Should().Be("A2");
            reading.BAR.Should().Be(10);
            reading.PSI.Should().Be(11);
        }

        [TestMethod]
        public void PressureCalculator_correctly_calculates_PSI()
        {
            // Arrange
            var calculator = new PressureCalculator()
            {
                ArduinoMaxVoltage = 5,
                ArduinoTotalIntervals = 1024,
                BARMax = 16,
                MaxVoltage = 4.24
            };

            // Act
            var psi = calculator.CalculatePSI(723);

            // Assert
            psi.Should().Be(1);
        }
    }
}
