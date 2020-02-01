using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Domain
{
    public static class PressureCalculator
    {
        const double MaxVoltage = 4.24;  //Voltage on arduino at 10V/16bar
        const int ArdMax = 5;      //Max voltage into arduino
        const int barMaxP = 16;
        const int psiMaxP = 232;
        const int ardTotIntervals = 1024;
        public static double CalculatePSI(int RawReading)
        {
            return Calculate(RawReading, psiMaxP);
        }

        public static double CalculateBAR(int RawReading)
        {
            return Calculate(RawReading, barMaxP);
        }

        static double Calculate(int RawReading, int maxP)
        {
            return Math.Round(((RawReading / ardTotIntervals) * (maxP / MaxVoltage)) * ArdMax, 1, MidpointRounding.AwayFromZero);
        }
    }
}
