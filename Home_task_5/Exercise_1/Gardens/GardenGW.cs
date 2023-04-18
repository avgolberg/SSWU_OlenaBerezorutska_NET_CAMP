using System;
using System.Collections.Generic;
using System.Text;

namespace Gardens
{
    class GardenGW
    {
        private Random random = new Random();

        private List<Location> _trees;
        private List<Location> _fence = new List<Location>();

        private double _fieldWidth;
        private double _fieldHeight;
        private int _treesCount;

        public double FenceLength { get; private set; }

        public GardenGW(List<Location> trees)
        {
            _trees = new List<Location>(trees);
            _treesCount = trees.Count;

            AddFence();
        }
        public GardenGW(int width, int height, int treesCount)
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
            ConvexHull(_trees, _treesCount);
            FenceLength = CalculateDistance(_fence);
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

        private double Orientation(Location p, Location q, Location r)
        {
            double val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private void ConvexHull(List<Location> trees, int n)
        {
            if (n < 3) return;

            int l = 0;
            for (int i = 1; i < n; i++)
                if (trees[i].X < trees[l].X)
                    l = i;

            int p = l, q;
            do
            {
                _fence.Add(trees[p]);

                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    if (Orientation(trees[p], trees[i], trees[q]) == 2)
                        q = i;
                }

                p = q;

            } while (p != l);
        }

        private double CalculateDistance(List<Location> fence)
        {
            double result = 0;
            for (int i = 0; i < fence.Count - 1; i++)
            {
                result += GetDistance(fence[i].X, fence[i].Y, fence[i + 1].X, fence[i + 1].Y);
            }
            result += GetDistance(fence[fence.Count - 1].X, fence[fence.Count - 1].Y, fence[0].X, fence[0].Y);
            return result;
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static bool operator >(GardenGW garden1, GardenGW GardenGW)
        {
            return garden1.FenceLength > GardenGW.FenceLength;
        }
        public static bool operator <(GardenGW garden1, GardenGW GardenGW)
        {
            return garden1.FenceLength < GardenGW.FenceLength;
        }
        public static bool operator >=(GardenGW garden1, GardenGW GardenGW)
        {
            return garden1.FenceLength >= GardenGW.FenceLength;
        }
        public static bool operator <=(GardenGW garden1, GardenGW GardenGW)
        {
            return garden1.FenceLength <= GardenGW.FenceLength;
        }
        public static bool operator ==(GardenGW garden1, GardenGW GardenGW)
        {
            return garden1.FenceLength == GardenGW.FenceLength;
        }
        public static bool operator !=(GardenGW garden1, GardenGW GardenGW)
        {
            return !(garden1 == GardenGW);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Location item in _trees)
            {
                sb.Append(item.ToString() + "\n");
            }
            sb.Append($"Fence Length: {FenceLength:f}\n");
            sb.Append("Fence: " + string.Join(", ", _fence) + "\n");
            return sb.ToString();
        }
    }
}
