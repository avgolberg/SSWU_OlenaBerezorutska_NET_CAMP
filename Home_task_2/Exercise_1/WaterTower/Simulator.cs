using System;

namespace WaterTower
{
    class Simulator
    {
        private WaterTower _waterTower;
        private User _user;

        public Simulator(double maxWaterLevel, double pumpPower, double userConsuption)
        {
            _waterTower = new WaterTower(maxWaterLevel, new Pump(pumpPower));
            _user = new User(userConsuption);

            _user.WaterIsNeeded += OnWaterIsNeeded;
        }

       // Не думаю, що це метод цього класу.Симулятор мав би надавати користувачу можливість стартувати та закінчувати спостереження, активувати користувача іт.д. що можна було б 
        // що можна було б зробити у вигляді меню.
        public void OnWaterIsNeeded(object source, EventArgs e)
        {
            //supply water to user
        }

        public void Simulate()
        {

        }
    }
}
