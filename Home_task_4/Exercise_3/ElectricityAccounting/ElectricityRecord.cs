using System;
using System.Globalization;

namespace ElectricityAccounting
{
    class ElectricityRecord
    {// Краще, коли розмірами полів можна керувати ззовні.
        public static string Header = string.Format("{0,-10} {1,-12} {2, -12} {3,-12} {4,-12} {5,-12} {6,-12}", "Квартира", "Власник", "Місяць", "Вхідні", "Вихідні", "До сплати", "Дата зняття");

        public static string ShortHeader = string.Format("{0, -12} {1,-12} {2,-12} {3,-12} {4,-12}\n", "Місяць", "Вхідні", "Вихідні", "До сплати", "Дата зняття");

        public string Address { get; private set; }
        public string Owner { get; private set; }
        public string Surname { get; private set; }
        public int Apartment { get; private set; }
        public double MeterInput { get; private set; }
        public double MeterOutput { get; private set; }
        public double Debt { get; private set; }
        public DateTime MeterReadingDate { get; private set; }
        public int Quarter { get; private set; }

        public ElectricityRecord(string address, string owner, double meterInput, double meterOutput, DateTime meterReadingDate, double price)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"{nameof(address)} can not be null or white space", nameof(address));

            if (string.IsNullOrWhiteSpace(owner))
                throw new ArgumentException($"{nameof(owner)} can not be null or white space", nameof(owner));

            if (meterInput <= 0)
                throw new ArgumentException($"{nameof(meterInput)} can not 0 or negative", nameof(meterInput));

            if (meterOutput <= 0)
                throw new ArgumentException($"{nameof(meterOutput)} can not 0 or negative", nameof(meterOutput));

            Address = address;
            int apartment;
            if (!int.TryParse(Address.Substring(Address.LastIndexOf(".") + 1), out apartment))
                throw new ArgumentException($"Apartment {Address.Substring(Address.LastIndexOf(".") + 1)} was not converted sucessfully");
            Apartment = apartment;

            Owner = owner;
            Surname = Owner.Split()[0];

            MeterInput = meterInput;
            MeterOutput = meterOutput;
            MeterReadingDate = meterReadingDate;
            Debt = CalculateDebt(price);
            Quarter = GetQuarter(MeterReadingDate);
        }
        private double CalculateDebt(double price)
        {
            if (price <= 0)
                throw new ArgumentException($"{nameof(price)} can not 0 or negative", nameof(price));

            return (MeterOutput - MeterInput) * price;
        }
        public void ChangePrice(double price)
        {
            Debt = CalculateDebt(price);
        }

        private int GetQuarter(DateTime date)
        {
            return (date.Month + 2) / 3;
        }

        public string ShortFormat()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0, -12:MMMM} {1,-12} {2,-12} {3,-12:C2} {4,-12:d}", MeterReadingDate, MeterInput, MeterOutput, Debt, MeterReadingDate);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0,-10} {1,-12} {2, -12:MMMM} {3,-12} {4,-12} {5,-12:C2} {6,-12:d}", Apartment, Surname, MeterReadingDate, MeterInput, MeterOutput, Debt, MeterReadingDate);
        }
    }
}
