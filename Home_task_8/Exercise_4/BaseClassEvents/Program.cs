using System;
using System.Collections.Generic;

namespace BaseClassEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //Подія - особливий тип делегата, який може бути викликаний тільки з класу, в якому вони оголошені          
            //Рішення: створення protected методу виклику в базовому класі, який обертає подію. Викликаючи або перевизначаючи цей метод виклику, похідні класи можуть викликати подію опосередковано

            var electricCar = new ElectricCar();
            electricCar.SpeedLimit += SpeedHandler;

            var manualCar = new ManualCar();
            manualCar.SpeedLimit += SpeedHandler;

            electricCar.Move(130, 1);
            manualCar.Move(100, 1);
            electricCar.Move(90, 1);
        }

        private static void SpeedHandler(object sender, CarEventArgs e)
        {
            Console.WriteLine($"Speed Limit! Current Speed is: {e.Speed}");
        }
    }
}
