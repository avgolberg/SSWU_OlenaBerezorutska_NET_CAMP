using System;

namespace BaseClassEvents
{
    public class ManualCar : Car
    {
        public override void Move(double distance, double time)
        {
            _speed = distance / time;

            if (_speed > 60)
                OnMaxSpeed(new CarEventArgs(_speed));

            //SpeedLimit?.Invoke(this, new CarEventArgs(_speed)); - так не вийде
            //Поза класом, у якому вона визначена, подія може лише додавати чи видаляти посилання, тобто SpeedLimit += обробник
            //- Подія 'event' може відображатися лише ліворуч від += або -= (окрім випадків, коли використовується всередині типу 'type').

        }
        protected override void OnMaxSpeed(CarEventArgs e)
        {
            Console.WriteLine($"ManualCar Speed Limit!");
            // Виклик методу виклику події базового класу.
            base.OnMaxSpeed(e);
        }
    }
}
