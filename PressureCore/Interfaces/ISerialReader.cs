using PressureCore.Domain;
using System;

namespace PressureCore.Interfaces
{
    public interface ISerialReader
    {
        string ReadLine();
        SerialData ReadData(DateTimeOffset now);
    }
}
