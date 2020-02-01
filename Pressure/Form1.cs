using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using Pressure.Domain;
using System.Timers;
using System.Text;

namespace Pressure
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            GetPorts();
            CsvString = new StringBuilder();
        }

        SerialReader Reader;
        System.Timers.Timer aTimer;
        StringBuilder CsvString;

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
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void But_EndSave_Click(object sender, EventArgs e)
        {
            Reader.ClosePort();
            Write(CsvString.ToString());
            CsvString.Clear();
        }

        void Write(string data)
        {
            try
            {
                string pathfile = @"C:\Users\rap\Desktop\DATA\";
                string filename = "New_Data.txt";               


                System.IO.File.WriteAllText(pathfile + filename, data);
                MessageBox.Show("Data has been saved to " + pathfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void but_Check_Click(object sender, EventArgs e)
        {
            Reader = new SerialReader(cmbo_Ports.Text);
            string message;


            Reader.OpenPort();
            message = Reader.PortIsOpen ? $"Port {Reader.PortName} has been opened"
                                                : $"Port {Reader.PortName} could not be opened";
            Reader.ClosePort();

            MessageBox.Show(message);
        }

        private void GetPorts()
        {
            cmbo_Ports.DataSource = SerialPort.GetPortNames();
        }

        private void SetTimer(int timerLength)
        {
            aTimer = new System.Timers.Timer(timerLength);
            aTimer.Elapsed += ReadAndParseData;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void ReadAndParseData(Object source, ElapsedEventArgs e)
        {
            var serialData = Reader.ReadLineData();
            var readings = SerialDataToPressureReading(serialData);
            readings.ForEach(x => CsvString.Append($"{x.ToString()}\n"));
        }

        List<PressureReading> SerialDataToPressureReading(Domain.SerialData serialData)
        {
            var readings = new List<PressureReading>();

            foreach (var key in serialData.Data.Keys)
                readings.Add(new PressureReading(key, serialData.Data[key], serialData.TimeStamp));

            return readings;
        }
    }
}