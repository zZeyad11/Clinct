using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Process> y = new List<Process>();
            foreach (var x in Process.GetProcesses())
            {
                if (x.ProcessName.Equals(Process.GetCurrentProcess().ProcessName) && x.Id != Process.GetCurrentProcess().Id)
                {
                    y.Add(x);
                }
            }
            if (y.Count.Equals(0))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else { Error error = new Error("There Is Already Instance Opened"); error.ShowInTaskbar = false; error.ShowDialog(); Process.GetCurrentProcess().Kill(); }
        }
    }
}
