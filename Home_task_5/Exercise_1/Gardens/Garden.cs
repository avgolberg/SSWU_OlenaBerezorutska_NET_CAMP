using System;
using System.Collections.Generic;
using System.Text;

namespace Gardens
{
    class Garden
    {
        private Random random = new Random();

        private List<Location> _trees;
        private List<int> _order;
        private List<int> _bestOrder;

        private double _fieldWidth;
        private double _fieldHeight;
        private int _treesCount;

        public double FenceLength { get; private set; }

        public Garden(List<Location> trees)
        {
            _trees = new List<Location>(trees);
            _treesCount = trees.Count;

            AddFence();
        }
        public Garden(int width, int height, int treesCount)
        {
            _fieldWidth = width;
            _fieldHeight = height;
            _treesCount = treesCount;

            _trees = new List<Location>();
            Fill();

            AddFence();
        }

        private void AddFence()
        {
            _order = new List<int>();
            for (int i = 0; i < _treesCount; i++)
                _order.Add(i);

            FenceLength = FindMinimumFence();
        }

        private void Fill()
        {
            double x, y;
            for (int i = 0; i < _treesCount; i++)
            {
                x = random.NextDouble() * _fieldWidth;
                y = random.NextDouble() * _fieldHeight;
                _trees.Add(new Location(x, y));
            }
        }

        private double FindMinimumFence()
        {
            double distance;
            _bestOrder = new List<int>(_order);
            double min = CalculateDistance(_order);

            while (NextOrder(_order))
            {
                distance = CalculateDistance(_order);
                if (distance < min)
                {
                    min = distance;
                    _bestOrder = new List<int>(_order);
                }
            }
            return min;
        }
        private bool NextOrder(List<int> order)
        {
            if (order.Count <= 1)
                return false;

            int largestI = -1, largestJ = -1;

            for (int i = 0; i < order.Count - 1; i++)
            {
                if (order[i] < order[i + 1])
                    largestI = i;
            }

            if (largestI == -1)
                return false;

            for (int j = 0; j < order.Count; j++)
            {
                if (order[largestI] < order[j])
                    largestJ = j;
            }

            Swap(order, largestI, largestJ);

            order.Reverse(largestI + 1, _order.Count - 1 - largestI);

            return true;
        }

        private void Swap(List<int> data, int left, int right)
        {
            int temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }

        private double CalculateDistance(List<int> order)
        {
            double result = 0;
            for (int i = 0; i < _treesCount - 1; i++)
            {
                result += GetDistance(_trees[order[i]].X, _trees[order[i]].Y, _trees[order[i + 1]].X, _trees[order[i + 1]].Y);
            }
            result += GetDistance(_trees[order[_treesCount - 1]].X, _trees[order[_treesCount - 1]].Y, _trees[order[0]].X, _trees[order[0]].Y);
            return result;
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static bool operator >(Garden garden1, Garden garden2)
        {
            return garden1.FenceLength > garden2.FenceLength;
        }
        public static bool operator <(Garden garden1, Garden garden2)
        {
            return garden1.FenceLength < garden2.FenceLength;
        }
        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return garden1.FenceLength >= garden2.FenceLength;
        }
        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return garden1.FenceLength <= garden2.FenceLength;
        }
        public static bool operator ==(Garden garden1, Garden garden2)
        {
            return garden1.FenceLength == garden2.FenceLength;
        }
        public static bool operator !=(Garden garden1, Garden garden2)
        {
            return !(garden1 == garden2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Location item in _trees)
            {
                sb.Append(item.ToString() + "\n");
            }
            sb.Append($"Fence Length: {FenceLength:f}\n");
            sb.Append("Fence: " + string.Join(", ", _bestOrder) + "\n");
            return sb.ToString();
        }
    }

    class Location
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X:f}, {Y:f})";
        }
    }
}
