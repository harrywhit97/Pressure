using System;

namespace PressureCore.Concrete
{
    public class PressureCalculator
    {
        /// <summary>
        /// Voltage on arduino at 10V/16bar
        /// </summary>
        public double MaxVoltage { get; set; }
        public int ArduinoMaxVoltage { get; set; }
        public double BARMax { get; set; }
        public int ArduinoTotalIntervals { get; set; }

        public double CalculatePSI(int RawReading)
        {            
            return Calculate(RawReading, BARtoPSI(BARMax));
        }

        public double CalculateBAR(int RawReading)
        {
            return Calculate(RawReading, BARMax);
        }

        double Calculate(int RawReading, double maxP)
        {
            return Math.Round(((RawReading / ArduinoTotalIntervals) * (maxP / MaxVoltage)) * ArduinoMaxVoltage, 1, MidpointRounding.AwayFromZero);
        }

        double BARtoPSI(double BAR)
        {
            var BARtoPSIRatio = 14.504;
            return BAR * BARtoPSIRatio;
        }
    }
}
