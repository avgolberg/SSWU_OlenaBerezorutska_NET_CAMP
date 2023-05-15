using System;
using System.Windows.Forms;
using TrafficLights;
using TrafficLightsWinForms.Displays;

namespace TrafficLightsWinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //НЕ обов'язково створювати завжди нову форму для візуалізації перехрестя, залежачи від патерну руху
            //Окрім прив'язки до візуальних об'єктів, вони є однаковими
            //Можна зробити універсальну версію, виконавши генерацію візуальних об'єктів у коді (фон, кількість і розташування світлофорів, їхній вид (з дод. секцією чи ні), початковий стан 

            //var form = new FormDisplay(new ForwardMovement(3, 1, 2));
            var form = new ComplexIntersectionForm(new ComplexMovement(3, 1, 2));

            IntersectionSimulator simulator = new IntersectionSimulator(form);

            simulator.Start();

            Application.Run(form);

            simulator.Stop();
        }
    }
}
