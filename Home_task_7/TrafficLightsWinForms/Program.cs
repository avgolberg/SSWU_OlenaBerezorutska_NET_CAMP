using System;
using System.Windows.Forms;
using TrafficLights;

namespace TrafficLightsWinForms
{// сумарний бал 97.
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new FormDisplay(new ForwardMovement(3, 2, 3));

            IntersectionSimulator simulator = new IntersectionSimulator(form);

            simulator.Start();

            Application.Run(form);

            simulator.Stop();
        }
    }
}
