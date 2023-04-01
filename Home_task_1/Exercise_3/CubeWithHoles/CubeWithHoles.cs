using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWithHoles
{
    internal enum HoleType
    {
        Horizontal, Vertical, Deep, Diagonal
    }

    internal class Hole
    {
        public HoleType Type { get; private set; }
        public uint[] StartIndex { get; private set; }
        public uint[] EndIndex { get; private set; }

        public Hole(HoleType type, uint[] startIndex, uint[] endIndex)
        {
            Type = type;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Type + " line \n");

            sb.Append("Start Index [");
            for (int i = 0; i < StartIndex.Length - 1; i++)
            {
                sb.Append(StartIndex[i] + ", ");
            }
            sb.Append(StartIndex[StartIndex.Length - 1] + "] \n");

            sb.Append("End Index [");
            for (int i = 0; i < EndIndex.Length - 1; i++)
            {
                sb.Append(EndIndex[i] + ", ");
            }
            sb.Append(EndIndex[EndIndex.Length - 1] + "] \n");

            return sb.ToString();
        }
    }

    internal class CubeWithHoles
    {
        private uint _size;
        private int[,,] _cube;

        private List<Hole> _holes;
        public CubeWithHoles(uint size = 3)
        {
            _size = size;
            _cube = new int[_size, _size, _size];
            _holes = new List<Hole>();

            Fill();
        }

        public void FindHoles()
        {
            int countHorizontalLine = 0;
            int countVerticalLine = 0;
            int countDeepLine = 0;

            for (uint i = 0; i < _size; i++)
            {
                for (uint j = 0; j < _size; j++)
                {
                    for (uint k = 0; k < _size; k++)
                    {
                        if (_cube[i, j, k] == 0)
                            countHorizontalLine++;

                        if (_cube[i, k, j] == 0)
                            countVerticalLine++;

                        if (_cube[k, j, i] == 0)
                            countDeepLine++;

                        if (countHorizontalLine == _size)
                        {
                            var hole = new Hole(HoleType.Horizontal, new uint[] { i, j, k + 1 - _size }, new uint[] { i, j, k }); 
                            _holes.Add(hole);
                        }

                        if (countVerticalLine == _size)
                        {
                            var hole = new Hole(HoleType.Vertical, new uint[] { i,  k + 1 - _size, j }, new uint[] { i, k, j });
                            _holes.Add(hole);
                        }

                        if (countDeepLine == _size)
                        {
                            var hole = new Hole(HoleType.Deep, new uint[] {k + 1 - _size, j, i }, new uint[] { k, j, i });
                            _holes.Add(hole);
                        }
                    }
                    countHorizontalLine = 0;
                    countVerticalLine = 0;
                    countDeepLine = 0;
                }
            }

            //треба виключати складові отворів для розрядностей більше 3
            if (_size % 2 == 0)
                FindDiagonalEven();
            else
                FindDiagonalOdd();
        }

        private void FindDiagonalOdd()
        {
            uint middle = _size / 2;
            for (uint i = 0; i < _size; i++)
            {
                for (uint j = 0; j < _size; j++)
                {
                    for (uint k = 0; k < _size; k++)
                    {
                        if (_cube[k, j, i] == 0
                          && _cube[middle, j, middle] == 0
                          && k != middle
                          && ((_cube[k, j, k] == 0 && _cube[_size - 1 - k, j, _size - 1 - k] == 0)
                          || (_cube[_size - 1 - k, j, k] == 0 && _cube[k, j, _size - 1 - k] == 0)))
                        {
                            if (_cube[k, j, k] == 0 && _holes.Find(h => Enumerable.SequenceEqual(h.StartIndex, new uint[] { _size - 1 - k, j, _size - 1 - k })) == null)
                            {
                                _holes.Add(new Hole(HoleType.Diagonal, new uint[] { k, j, k }, new uint[] { _size - 1 - k, j, _size - 1 - k }));
                            }
                            if (_cube[_size - 1 - k, j, k] == 0 && _holes.Find(h => Enumerable.SequenceEqual(h.StartIndex, new uint[] { _size - 1 - k, j, k })) == null)
                            {
                                _holes.Add(new Hole(HoleType.Diagonal, new uint[] { k, j, _size - 1 - k }, new uint[] { _size - 1 - k, j, k }));
                            }
                        }
                    }
                }
            }
        }

        private void FindDiagonalEven()
        {
            for (uint i = 0; i < _size; i++)
            {
                for (uint j = 0; j < _size; j++)
                {
                    for (uint k = 0; k < _size; k++)
                    {
                        if (_cube[k, j, i] == 0
                          && ((_cube[k, j, k] == 0 && _cube[_size - 1 - k, j, _size - 1 - k] == 0)
                          || (_cube[_size - 1 - k, j, k] == 0 && _cube[k, j, _size - 1 - k] == 0)))
                        {
                            if (_cube[k, j, k] == 0 && _holes.Find(h => Enumerable.SequenceEqual(h.StartIndex, new uint[] { _size - 1 - k, j, _size - 1 - k })) == null)
                            {
                                _holes.Add(new Hole(HoleType.Diagonal, new uint[] { k, j, k }, new uint[] { _size - 1 - k, j, _size - 1 - k }));
                            }
                            if (_cube[_size - 1 - k, j, k] == 0 && _holes.Find(h => Enumerable.SequenceEqual(h.StartIndex, new uint[] { _size - 1 - k, j, k })) == null)
                            {
                                _holes.Add(new Hole(HoleType.Diagonal, new uint[] { k, j, _size - 1 - k }, new uint[] { _size - 1 - k, j, k }));
                            }
                        }
                    }
                }
            }
        }

        private void Fill()
        {
            var rand = new Random();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        _cube[i, j, k] = rand.Next(0, 2);
                    }
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        sb.Append(_cube[i, j, k] + " ");
                    }
                    sb.Append("\n");
                }
                sb.Append("\n");
            }

            if (_holes.Count == 0) FindHoles();

            foreach (Hole hole in _holes)
            {
                sb.Append(hole + "\n");
            }

            return sb.ToString();
        }
    }
}
