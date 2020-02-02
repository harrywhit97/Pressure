using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressureCore.Domain;
using System;

namespace PressureAppTests
{
    [TestClass]
    public class PressureCoreTests
    {
        [TestMethod]
        public void SerialData_decodes_correctly()
        {
            // Arrange
            var rawData = "A1,209,A2,549";
            var timestamp = new DateTimeOffset(2020, 02, 02, 0, 0, 0, TimeSpan.Zero);

            // Act
            var serialData = new SerialData(timestamp, rawData);

            // Assert

            var data = serialData.Data;
            data.Keys.Count.Should().Be(2);

            data.ContainsKey("A1").Should().BeTrue();
            data.ContainsKey("A2").Should().BeTrue();

            data["A1"].Should().Be(209);
            data["A2"].Should().Be(549);
        }

        [TestMethod]
        public void PressureCalculator_correctly_calculates_PSI()
        {
            // Arrange
            //var calculator = new PressureCalculator();

            // Act
           

            // Assert
            
        }

        [TestMethod]
        public void test()
        {
            // Arrange


            // Act


            // Assert

        }
    }
}
