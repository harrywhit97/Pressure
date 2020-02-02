using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using Domain.Models;
using OutPutWriter;
using PressureCore.Concrete;
using OutPutWriter.Enums;
using OutPutWriter.Interfaces;
using System.IO.Ports;

namespace Pressure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetPorts();
            Readings = new List<PressureReading>();
            OutputWriter = OutPutWriterFactory.GetOutputWriter(OutputWriterType, WriteFolder);

            //find these numbers elsewhere - maybe appconfig
            Calculator = new PressureCalculator(4.24, 16, 5, 024);
        }

        SerialReader Reader;
        System.Timers.Timer aTimer;
        readonly IList<PressureReading> Readings;
        const int BatchSize = 100;
        const OutputType  OutputWriterType = OutputType.CSV;
        const string WriteFolder = @"C:\Users\rap\Desktop\DATA\";
        readonly PressureCalculator Calculator;
        readonly IOutputWriter OutputWriter; 

        public void But_Start_Click(object sender, EventArgs e)
        {
            try
            {
                tbox_CurPBar.Text = "";
                tbox_CurPPsi.Text = "";
                tbox_Time.Text = "";
                but_Start.Visible = false;
                Reader = new SerialReader(cmbo_Ports.Text);
                Reader.OpenPort();
                SetTimer(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void But_EndSave_Click(object sender, EventArgs e)
        {
            Reader.ClosePort();
            SaveReadings(Readings);
        }

        void But_Check_Click(object sender, EventArgs e)
        {
            Reader = new SerialReader(cmbo_Ports.Text);
            string message;

            Reader.OpenPort();

            message = Reader.PortIsOpen ? $"Port {Reader.PortName} has been opened"
                                                : $"Port {Reader.PortName} could not be opened";
            Reader.ClosePort();

            MessageBox.Show(message);
        }

        void GetPorts()
        {
            cmbo_Ports.DataSource = SerialPort.GetPortNames();
        }

        void SetTimer(int timerLength)
        {
            aTimer = new System.Timers.Timer(timerLength);
            aTimer.Elapsed += ReadAndParseData;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        void ReadAndParseData(object source, ElapsedEventArgs e)
        {
            var serialData = Reader.ReadData(DateTimeOffset.UtcNow);
            var readings = SerialDataToPressureReading(serialData);
            readings.ForEach(x => Readings.Add(x));

            if(Readings.Count >= BatchSize)
                SaveReadings(Readings);
        }

        void SaveReadings(IList<PressureReading> readings)
        {
            if (OutputWriter.SavePressureReadings(readings))
                Readings.Clear();
            else
                MessageBox.Show("Error writing to file");
        }

        List<PressureReading> SerialDataToPressureReading(PressureCore.Domain.SerialData serialData)
        {
            var readings = new List<PressureReading>();

            foreach (var key in serialData.Data.Keys)
            {
                var rawValue = serialData.Data[key];
                var reading = new PressureReading
                {
                    SensorName = key,
                    RawValue = rawValue,
                    TimeStamp = serialData.TimeStamp,
                    PSI = Calculator.CalculatePSI(rawValue),
                    BAR = Calculator.CalculateBAR(rawValue)
                };
                readings.Add(reading);
            }
            return readings;
        }
    }
}