using System;
using System.IO.Ports;

namespace Pressure.Domain
{
    public class SerialReader
    {
        SerialPort Port { get; set; }
        public Parity Parity { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public int ReadTimeout { get; set; }
        public string PortName { get; set; }
        public bool PortIsOpen => Port.IsOpen;

        public SerialReader(string portName, Parity parity, int baudRate, int dataBits, StopBits stopBits, int readTimeout)
        {
            PortName = portName;
            Parity = parity;
            BaudRate = baudRate;
            DataBits = dataBits;
            StopBits = stopBits;
            ReadTimeout = readTimeout;
            Port = GetSerialPort();
        }
        
        //temp - these should be injected
        public SerialReader(string portName)
        {
            PortName = portName;
            Parity = Parity.None;
            BaudRate = 9600;
            DataBits = 8;
            StopBits = StopBits.One;
            ReadTimeout = 100;
            Port = GetSerialPort();
        }

        SerialPort GetSerialPort()
        {
            var port =  new SerialPort()
            {
                PortName = PortName,
                Parity = Parity,
                BaudRate = BaudRate,
                DataBits = DataBits,
                StopBits = StopBits,
                ReadTimeout = ReadTimeout,
                
            };
            port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            return port;
        }

        public bool OpenPort()
        {
            try
            {                
                if(!Port.IsOpen)
                    Port.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void ClosePort()
        {
            Port.Close();
        }
        
        public SerialData ReadLineData()
        {
            var data = Port.ReadLine();
            return new SerialData(DateTimeOffset.UtcNow, data);
        }

        public string ReadLine()
        {
            return Port.ReadLine();
        }
    }
}
