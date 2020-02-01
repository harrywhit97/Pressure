using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using System.Management;
using Pressure.Domain;

namespace Pressure
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            
            InitializeComponent();
            getPorts();
        }

        #region Setup
        private SerialPort Port;
        private string serialData;
        private double in_data;
        private TimeSpan timeElapsed;
        int i = 0;
        Stopwatch stopwatch = new Stopwatch();
        List<string> Data_Arr = new List<string>();
        Object lockingObj = new Object();

        public void chkPort()
        {
            if (Port == null)
            {
                Port = new SerialPort
                {
                    PortName = cmbo_Ports.Text,
                    Parity = Parity.None,
                    BaudRate = 9600,
                    DataBits = 8,
                    StopBits = StopBits.One
                };
                Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                Port.ReadTimeout = 100;

                try
                {
                    Port.Open();
                    MessageBox.Show(String.Format("Port {0} has been opened",  Port.PortName));
                }

                catch (Exception ex3)
                {
                    MessageBox.Show(ex3.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show(String.Format("Port {0} is currently open, restart application to change", Port.PortName));
            }
        }

        #endregion
        #region Button Assignment
        public void but_Start_Click(object sender, EventArgs e)
        {


            try
            {
                stopwatch.Start();
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
                Port.Close();
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
            //chkPort();

            var reader = new SerialReader(cmbo_Ports.Text);
            string message;


            reader.OpenPort();
            message = reader.PortIsOpen ? $"Port {reader.PortName} has been opened" 
                                                : $"Port {reader.PortName} could not be opened";
            //reader.ClosePort();

            MessageBox.Show(message);
        }



        #endregion
        #region UI
        private void getPorts()
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
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            lock (lockingObj)
            {
                int dataInterval = 60;
                try
                {
                    serialData = Port.ReadLine();
                    in_data = Convert.ToDouble(serialData);
                    if ((i - 1) % dataInterval == 0)
                    {
                        Data_Arr.Add(string.Join(",", convertData(in_data)));
                    }

                    this.BeginInvoke(new EventHandler(displaydata_event));
                    i++;
                }
                catch (Exception ex4)
                {
                    MessageBox.Show(ex4.Message, "Error");
                }
            }
        }

        private string[] convertData(double in_data)
        {
            double voltMax = 4.24;  //Voltage on arduino at 10V/16bar
            double ardMax = 5;      //Max voltage into arduino
            double barMaxP = 16;
            double psiMaxP = 232;
            double psiCur;
            double barCur;
            double ardTotIntervals = 1024;
            string[] dataOut = new string[4];

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





        

        
    }
}  
  


