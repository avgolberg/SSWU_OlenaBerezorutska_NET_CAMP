using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ElectricityAccounting
{
    class ElectricityAccounting
    {
        private const int QUARTER = 3;

        private string _separator = " | ";
        private double _price;
        private int _consumersCount;

        private List<string> _lines = new List<string>();
        private List<ElectricityRecord> _records = new List<ElectricityRecord>();

        public ElectricityAccounting(string path, double price, string separator = " | ")
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"{nameof(path)} can not be null or white space", nameof(path));

            if (price <= 0)
                throw new ArgumentException($"{nameof(price)} can not 0 or negative", nameof(price));

            if (string.IsNullOrWhiteSpace(separator))
                throw new ArgumentException($"{nameof(separator)} not be null or white space", nameof(separator));

            if (!File.Exists(path))
                throw new ArgumentException("File does not exist", nameof(path));

            _lines.AddRange(File.ReadLines(path));
            if (_lines.Count == 0) throw new ArgumentException($"{nameof(_lines)} can not be empty", nameof(_lines));

            _price = price;
            _separator = separator;
            ParseData();
        }
        private void ParseData()
        {
            int secondIndex;
            string[] split;
            foreach (string line in _lines)
            {
                secondIndex = line.IndexOf(_separator, line.IndexOf(_separator) + 1);
                split = line.Substring(secondIndex).Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                if (string.IsNullOrWhiteSpace(line.Split(_separator)[0]))
                    throw new ArgumentException($"Address can not be null or white space");

                if (string.IsNullOrWhiteSpace(line.Split(_separator)[1]))
                    throw new ArgumentException($"Owner can not be null or white space");

                double meterInput;
                if (!double.TryParse(split[0], out meterInput))
                    throw new ArgumentException($"Meter input {split[0]} was not converted sucessfully");

                double meterOutput;
                if (!double.TryParse(split[1], out meterOutput))
                    throw new ArgumentException($"Meter output {split[1]} was not converted sucessfully");

                DateTime dateTime;
                if (!DateTime.TryParse(split[2], out dateTime))
                    throw new ArgumentException($"Date {split[2]} was not converted sucessfully");

                ElectricityRecord electricityRecord = new ElectricityRecord(line.Split(_separator)[0], line.Split(_separator)[1], meterInput, meterOutput, dateTime, _price);

                _records.Add(electricityRecord);
            }

            _consumersCount = _records.GroupBy(r => r.Address).Count();
        }
        public void ChangePrice(double price)
        {
            if (price <= 0)
                throw new ArgumentException($"{nameof(price)} can not 0 or negative", nameof(price));

            foreach (ElectricityRecord record in _records)
            {
                record.ChangePrice(price);
            }
        }
        private string PrintAll()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (ElectricityRecord record in _records)
            {
                if (i % (QUARTER * _consumersCount) == 0)
                {
                    sb.Append(string.Format("\nЗвіт за {0} квартал\n\n", _records[i + 1].Quarter));
                    sb.Append(ElectricityRecord.Header);
                }

                if (i % _consumersCount == 0)
                    sb.Append("\n");

                sb.Append(record.ToString() + "\n");
                i++;
            }

            return sb.ToString().Trim();
        }

        private string PrintShort(List<ElectricityRecord> records)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (ElectricityRecord item in records)
            {
                if (i % QUARTER == 0)
                {
                    sb.Append(string.Format("\nЗвіт за {0} квартал  (кв. {1}, власник - {2})\n", item.Quarter, item.Apartment, item.Owner));
                    sb.Append(ElectricityRecord.ShortHeader);
                }
                sb.Append(item.ShortFormat());
                sb.Append("\n");
                i++;
            }
            return sb.ToString().Trim();
        }

        public string PrintBy(int apartment)
        {
            return PrintShort(_records.FindAll(e => e.Apartment == apartment));
        }
        public string PrintBy(int apartment, int year, int quarter)
        {
            return PrintShort(_records.FindAll(e => e.Apartment == apartment && e.MeterReadingDate.Year == year && e.Quarter == quarter));
        }
        public string PrintBy(string address)
        {
            return PrintShort(_records.FindAll(e => e.Address == address));
        }
        public string PrintBy(string address, int year, int quarter)
        {
            return PrintShort(_records.FindAll(e => e.Address == address && e.MeterReadingDate.Year == year && e.Quarter == quarter));
        }

        public string LargestDebtSurname()
        {
            var consumers = _records.GroupBy(r => r.Address);
            double max = consumers.Max(c => c.Sum(e => e.Debt));
            var consumerRecords = consumers.First(r => r.Sum(e => e.Debt) == max).Select(r => r).ToList();
            return consumerRecords[0].Surname;
        }
        public List<int> NotUsedElectricityApartments()
        {
            List<int> result = new List<int>();
            var consumerRecords = _records.GroupBy(r => r.Address).Where(r => r.Any(e => e.Debt == 0)).Select(g => g.Key).ToList();
            foreach (var item in consumerRecords)
                result.Add(_records.Find(r => r.Address == item).Apartment);

            return result;
        }

        public double TotalDebtSum(string address, int quarter)
        {
            var consumers = _records.GroupBy(r => r.Address).Where(r => r.Key == address).SelectMany(g => g.Where(c => c.Quarter == quarter));
            return consumers.Sum(c => c.Debt);
        }

        public string TotalExpenses(int quarter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} квартал\n", quarter));
            sb.Append(string.Format("{0, -10} {1, -12} {2, -12}\n", "Квартира", "Власник", "До сплати"));

            var consumers = _records.GroupBy(r => r.Address).Select(g => g.Key).ToList();
            foreach (var item in consumers)
            {
                var c = _records.Find(r => r.Address == item);
                sb.Append(string.Format("{0, -10} {1, -12} {2, -12:C2}\n", c.Apartment, c.Surname, TotalDebtSum(c.Address, quarter)));
            }
            return sb.ToString().Trim();
        }

        public string DaysPast()
        {
            StringBuilder sb = new StringBuilder();
            var max = _records.Max(r => r.MeterReadingDate);
            int days = (DateTime.Now - max).Days;
            sb.Append(string.Format("З моменту останнього зняття показників пройшло {0} днів\n", days));
            return sb.ToString();
        }

        public override string ToString()
        {
            return PrintAll();
        }
    }
}
