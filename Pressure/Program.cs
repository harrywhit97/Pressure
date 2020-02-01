using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Pressure
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      [STAThread]
        static void Main()
        {
            Application.Run(new Form1());


        }
    }
}

