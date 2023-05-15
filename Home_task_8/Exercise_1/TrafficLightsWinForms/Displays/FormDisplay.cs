using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TrafficLights;

namespace TrafficLightsWinForms
{
    public partial class FormDisplay : Form, IDisplayTrafficPattern
    {
        // private System.Windows.Forms.Timer timer;

        private TrafficPattern _trafficPattern;
        public FormDisplay(TrafficPattern trafficPattern, double interval = 1000)
        {
            InitializeComponent();

            _trafficPattern = trafficPattern;
        }

        public TrafficPattern GetTrafficPattern()
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
            List<ITrafficLight> trafficLights = (List<ITrafficLight>)_trafficPattern.TrafficLights;

            tl1.Image = GetTrafficLightImage(trafficLights[0]);
            tl2.Image = GetTrafficLightImage(trafficLights[1]);
            tl3.Image = GetTrafficLightImage(trafficLights[2]);
            tl4.Image = GetTrafficLightImage(trafficLights[3]);
        }

        private Image GetTrafficLightImage(ITrafficLight trafficLight)
        {
            string mainColor = trafficLight.Color.Color.ToLower();
            if (trafficLight is AdditionalSectionsTrafficLight tl)
            {
                try
                {
                    string additionalColor = tl.AdditionalSections.ToList()[0].Color.Color.ToLower();
                    return Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"..\..\Images\{mainColor}_{additionalColor}.jpg"));
                }
                catch
                {
                    return Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"..\..\Images\{mainColor}WithAdditional.jpg"));
                }
            }

            return Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"..\..\Images\{mainColor}.png"));
        }
    }
}
