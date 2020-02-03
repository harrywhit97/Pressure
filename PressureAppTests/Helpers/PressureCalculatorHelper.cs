using PressureCore.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PressureAppTests.Helpers
{
    public static class PressureCalculatorHelper
    {
        public static PressureCalculator BuildCalulator(bool setDefaults = true)
        {
            var calculator = new PressureCalculator();

            if (setDefaults)
                SetDefaults(calculator);

            return calculator;
        }

        static void SetDefaults(PressureCalculator pressureCalculator)
        {
            pressureCalculator.ArduinoMaxVoltage = 5;
            pressureCalculator.ArduinoTotalIntervals = 1024;
            pressureCalculator.BARMax = 16;
            pressureCalculator.MaxVoltage = 4.24M;
        }

    }
}
