using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using Pressure.Domain;
using System.Timers;

namespace Pressure
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            
            InitializeComponent();
            GetPorts();
        }

        #region Setup
        SerialReader Reader;
        string portName = cmbo_Ports.Text;
        private string serialData;
        private double in_data;
        private TimeSpan timeElapsed;
        System.Timers.Timer aTimer;
        int i = 0;
        Stopwatch stopwatch = new Stopwatch();
        var Data_Arr = new List<string>();
        Object lockingObj = new Object();
        

        #endregion
        #region Button Assignment
        public void but_Start_Click(object sender, EventArgs e)
        {
            try
            {
                Reader = new SerialReader(cmbo_Ports.Text);
                Reader.OpenPort();
                stopwatch.Start();
                SerialReader.
                tbox_CurPBar.Text = "";
                tbox_CurPPsi.Text = "";
                tbox_Time.Text = "";
                but_Start.Visible = false;
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message, "Error");
            }

        }

        private void but_EndSave_Click(object sender, EventArgs e)
        {
            try
            {
                Reader.ClosePort();
                string pathfile = @"C:\Users\rap\Desktop\DATA\";
                string filename = "New_Data.txt";
                string csv = string.Join("\n", Data_Arr.Select(x => x.ToString()).ToArray());


                System.IO.File.WriteAllText(pathfile + filename, csv);
                MessageBox.Show("Data has been saved to " + pathfile);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
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



        #endregion
        #region UI
        private void GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cmbo_Ports.DataSource = ports;
        }


        private void displaydata_event(object sender, EventArgs e)
        {
            string[] dataOut;
            dataOut = convertData(in_data);
            if (testBegun())
            {
                tbox_Time.Text = dataOut[0];
            }
            else
            {
                tbox_Time.Text = "Test not started";
            }
            tbox_CurPBar.Text = dataOut[1];
            tbox_CurPPsi.Text = dataOut[2];
        }

        private bool testBegun()
        {
            bool result;
            if (stopwatch.IsRunning)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


        #endregion
        #region Data Manipulation


        private string[] convertData(double in_data)
        {
            double voltMax = 4.24;  //Voltage on arduino at 10V/16bar
            double ardMax = 5;      //Max voltage into arduino
            double barMaxP = 16;
            double psiMaxP = 232;
            double psiCur;
            double barCur;
            double ardTotIntervals = 1024;
            var dataOut = new string[4];

            //Convert to bar
            barCur = Math.Round(((in_data / ardTotIntervals) * (barMaxP / voltMax)) * ardMax, 1, MidpointRounding.AwayFromZero);
            //Convert to psi
            psiCur = Math.Round(((in_data / ardTotIntervals) * (psiMaxP / voltMax)) * ardMax, 1, MidpointRounding.AwayFromZero);
            //Get current timestamp
            timeElapsed = RoundSeconds(stopwatch.Elapsed);
            //Compile output array
            dataOut[0] = Convert.ToString(timeElapsed);
            dataOut[1] = Convert.ToString(barCur);
            dataOut[2] = Convert.ToString(psiCur);
            dataOut[3] = Convert.ToString(in_data);

            return dataOut;

        }

        public static TimeSpan RoundSeconds(TimeSpan span)
        {
            return TimeSpan.FromSeconds(Math.Round((span.TotalSeconds)));
        }
        #endregion


        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var serialData = Reader.ReadLineData();
            var readings = SerialDataToPressureReading(serialData);
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
  


