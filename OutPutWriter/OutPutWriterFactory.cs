using OutPutWriter.Enums;
using OutPutWriter.Interfaces;
using Pressure.EF;
using System;

namespace OutPutWriter
{
    public static class OutPutWriterFactory
    {
        public static IOutputWriter GetOutputWriter(OutputType type, string outputDirectory = null)
        {
            switch (type)
            {
                case OutputType.CSV:
                    if (outputDirectory is null)
                        throw new Exception($"A Csv writer requires an output directory");

                    return new CsvWriter(outputDirectory);
                case OutputType.Database:
                    return new PressureReadingRepository();
                default:
                    throw new Exception("Invalid output type");
            }
        }
    }
}
