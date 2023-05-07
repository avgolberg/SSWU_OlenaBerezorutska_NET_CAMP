using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TrafficLights;

namespace TrafficLightsWinForms
{
    public partial class FormDisplay : Form, IDisplayTrafficPattern
    {
        // private System.Windows.Forms.Timer timer;

        private ITrafficPattern _trafficPattern;
        public FormDisplay(ITrafficPattern trafficPattern, double interval = 1000)
        {
            InitializeComponent();

            _trafficPattern = trafficPattern;
        }

        public ITrafficPattern GetTrafficPattern()
        {
            return _trafficPattern;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Show();
        }

        public new void Show()
        {
            List<string> trafficLights = new List<string>();
            var split = _trafficPattern.ToString().Split('\n');
            //var split = _trafficPattern.ToString().Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (string tl in split)
            {
                if(!string.IsNullOrWhiteSpace(tl))
                    trafficLights.Add(tl.Split(' ')[1]);
            }

            tl1.Image = GetTrafficLightImage(trafficLights[0].ToLower());
            tl2.Image = GetTrafficLightImage(trafficLights[1].ToLower());
            tl3.Image = GetTrafficLightImage(trafficLights[2].ToLower());
            tl4.Image = GetTrafficLightImage(trafficLights[3].ToLower());
        }

        private Image GetTrafficLightImage(string color)
        {
            return Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            $@"..\..\Images\{color}.png"));
        }
    }
}
