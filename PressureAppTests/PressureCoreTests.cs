using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PressureAppTests.Helpers;
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
            calculatorMock.Setup(x => x.CalculateBAR(It.IsAny<decimal>())).Returns(10.0M);
            calculatorMock.Setup(x => x.CalculatePSI(It.IsAny<decimal>())).Returns(11.0M);

            // Act
            var readings = RawDataProcessor.ParseRawDataToPressureReadings(rawData, calculatorMock.Object, timestamp);

            // Assert
            readings.Count.Should().Be(2);
            var reading = readings[0];

            reading.RawValue.Should().Be(209);
            reading.TimeStamp.Should().Be(timestamp);
            reading.SensorName.Should().Be("A1");
            reading.BAR.Should().Be(10.0M);
            reading.PSI.Should().Be(11M);

            reading = readings[1];
            reading.RawValue.Should().Be(549M);
            reading.TimeStamp.Should().Be(timestamp);
            reading.SensorName.Should().Be("A2");
            reading.BAR.Should().Be(10.0M);
            reading.PSI.Should().Be(11.0M);
        }

        [TestMethod]
        public void PressureCalculator_correctly_calculates_PSI()
        {
            // Arrange
            var calculator = PressureCalculatorHelper.BuildCalulator();

            // Act
            var psi = calculator.CalculatePSI(700M);

            // Assert
            psi.Should().Be(187.1M);
        }

        [TestMethod]
        public void PressureCalculator_correctly_calculates_BAR()
        {
            // Arrange
            var calculator = PressureCalculatorHelper.BuildCalulator();

            // Act
            var BAR = calculator.CalculateBAR(700M);

            // Assert
            BAR.Should().Be(12.9M);
        }
    }
}
