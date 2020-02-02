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
using System.Configuration;
using System.ComponentModel;

namespace Pressure
{
    public partial class Form1 : Form
    {
        SerialReader Reader;
        string PortName => cmbo_Ports.Text;
        System.Timers.Timer ReadTimer;
        readonly IList<PressureReading> Readings;
        readonly int BatchSize;
        readonly OutputType OutputWriterType;
        readonly string OutputDestinationFolder;
        readonly PressureCalculator Calculator;
        readonly IOutputWriter OutputWriter;
        readonly int ReadFrequencyInMilliseconds;

        public Form1()
        {
            BatchSize = GetAppSettingAndConvert<int>(nameof(BatchSize));
            ReadFrequencyInMilliseconds = GetAppSettingAndConvert<int>(nameof(ReadFrequencyInMilliseconds));
            OutputDestinationFolder = GetAppSetting(nameof(OutputDestinationFolder));

            InitializeComponent();
            GetPorts();

            Readings = new List<PressureReading>();
            OutputWriter = OutPutWriterFactory.GetOutputWriter(OutputWriterType, OutputDestinationFolder);
            Calculator = BuildPressureCalculator();
            OutputWriterType = OutputType.CSV;
        }

        PressureCalculator BuildPressureCalculator()
        {
            return new PressureCalculator()
            {
                MaxVoltage = GetAppSettingAndConvert<double>(nameof(PressureCalculator.MaxVoltage)),
                ArduinoMaxVoltage = GetAppSettingAndConvert<int>(nameof(PressureCalculator.ArduinoMaxVoltage)),
                ArduinoTotalIntervals = GetAppSettingAndConvert<int>(nameof(PressureCalculator.ArduinoTotalIntervals)),
                BARMax = GetAppSettingAndConvert<double>(nameof(PressureCalculator.BARMax))
            };
        }

        T GetAppSettingAndConvert<T>(string settingName)
        {
            var setting = GetAppSetting(settingName);

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(setting);                    
            }
            catch
            {
                throw new Exception($"{settingName} is not a {typeof(T).ToString()} in the configuration setings");
            }
        }

        string GetAppSetting(string settingName)
        {
            var setting = ConfigurationManager.AppSettings.Get(settingName);

            if (setting is null)
                throw new Exception($"{settingName} could not be found in the configuration settings");

            return setting;
        }

        public void But_Start_Click(object sender, EventArgs e)
        {
            try
            {
                tbox_CurPBar.Text = "";
                tbox_CurPPsi.Text = "";
                tbox_Time.Text = "";
                but_Start.Visible = false;
                Reader = new SerialReader(PortName);
                Reader.OpenPort();
                SetTimer(ReadFrequencyInMilliseconds);
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
            ReadTimer = new System.Timers.Timer(timerLength);
            ReadTimer.Elapsed += ReadAndParseData;
            ReadTimer.AutoReset = true;
            ReadTimer.Enabled = true;
        }

        void ReadAndParseData(object source, ElapsedEventArgs e)
        {
            var line = Reader.ReadLine();
            var readings = RawDataProcessor.ParseRawDataToPressureReadings(line, Calculator, DateTimeOffset.UtcNow);
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
    }
}