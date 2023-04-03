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
        private uint _middle;

        private List<Hole> _holes;
        public CubeWithHoles(uint size = 5)
        {
            _size = size;
            _middle = _size / 2;
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
                            _holes.Add(new Hole(HoleType.Horizontal, new uint[] { i, j, k + 1 - _size }, new uint[] { i, j, k }));

                        if (countVerticalLine == _size)
                            _holes.Add(new Hole(HoleType.Vertical, new uint[] { i, k + 1 - _size, j }, new uint[] { i, k, j }));

                        if (countDeepLine == _size)
                            _holes.Add(new Hole(HoleType.Deep, new uint[] { k + 1 - _size, j, i }, new uint[] { k, j, i }));
                    }
                    countHorizontalLine = 0;
                    countVerticalLine = 0;
                    countDeepLine = 0;
                }
            }

            if (_size % 2 == 0)
                FindDiagonalEven();
            else
                FindDiagonalOdd();
        }

        private void FindDiagonalOdd()
        {
            for (uint i = 0; i < _size; i++)
            {
                for (uint j = 0; j < _size; j++)
                {
                    for (uint k = 0; k < _size; k++)
                    {
                        if (i == _middle) return;

                        if (_cube[k, j, i] == 0
                          && _cube[_middle, j, _middle] == 0
                          && k != _middle
                          && i != _middle - 1)
                        {
                            if (_cube[i, j, k] == 0 && _cube[_size - 1 - i, j, _size - 1 - k] == 0)
                            {
                                if (!DiagonalHoleExists(new uint[] { i, j, k }, new uint[] { _size - 1 - i, j, _size - 1 - k })
                                    && !DiagonalHoleExists(new uint[] { _size - 1 - i, j, _size - 1 - k }, new uint[] { i, j, k }) 
                                    && NextHolesExists(new uint[] { i, j, k }))
                                {
                                    _holes.Add(new Hole(HoleType.Diagonal, new uint[] { i, j, k }, new uint[] { _size - 1 - i, j, _size - 1 - k }));
                                }
                            }
                            if (_cube[i, j, _size - 1 - k] == 0 && _cube[_size - 1 - i, j, k] == 0)
                            {
                                if (!DiagonalHoleExists(new uint[] { i, j, _size - 1 - k }, new uint[] { _size - 1 - i, j, k })
                                    && !DiagonalHoleExists(new uint[] { _size - 1 - i, j, k }, new uint[] { i, j, _size - 1 - k }) 
                                    && NextHolesExists(new uint[] { i, j, _size - 1 - k }))
                                {
                                    _holes.Add(new Hole(HoleType.Diagonal, new uint[] { i, j, _size - 1 - k }, new uint[] { _size - 1 - i, j, k }));
                                }
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
                        if (i == _middle - 1) return;

                        if (_cube[k, j, i] == 0
                            && _cube[_middle - 1, j, _middle - 1] == 0
                            && _cube[_middle, j, _middle] == 0
                            && k != _middle)
                        {
                            if (_cube[i, j, k] == 0 && _cube[_size - 1 - i, j, _size - 1 - k] == 0)
                            {
                                if (!DiagonalHoleExists(new uint[] { i, j, k }, new uint[] { _size - 1 - i, j, _size - 1 - k })
                                    && !DiagonalHoleExists(new uint[] { _size - 1 - i, j, _size - 1 - k }, new uint[] { i, j, k }) 
                                    && NextHolesExists(new uint[] { i, j, k }))
                                {
                                    _holes.Add(new Hole(HoleType.Diagonal, new uint[] { i, j, k }, new uint[] { _size - 1 - i, j, _size - 1 - k }));
                                }

                            }
                            if (_cube[i, j, _size - 1 - k] == 0 && _cube[_size - 1 - i, j, k] == 0)
                            {
                                if (!DiagonalHoleExists(new uint[] { i, j, _size - 1 - k }, new uint[] { _size - 1 - i, j, k })
                                    && !DiagonalHoleExists(new uint[] { _size - 1 - i, j, k }, new uint[] { i, j, _size - 1 - k }) 
                                    && NextHolesExists(new uint[] { i, j, _size - 1 - k }))
                                {
                                    _holes.Add(new Hole(HoleType.Diagonal, new uint[] { i, j, _size - 1 - k }, new uint[] { _size - 1 - i, j, k }));
                                }

                            }
                        }
                    }
                }
            }
        }
        private bool DiagonalHoleExists(uint[] StartIndex, uint[] EndIndex)
        {
            return _holes.Exists(h => h.Type == HoleType.Diagonal && Enumerable.SequenceEqual(h.StartIndex, StartIndex) && Enumerable.SequenceEqual(h.EndIndex, EndIndex));
        }
        private bool NextHolesExists(uint[] StartIndex)
        {
            for (uint i = StartIndex[0] + 1; i < _size; i++)
            {
                if (StartIndex[0] == StartIndex[2])
                {
                    if (!(_cube[i, StartIndex[1], i] == 0 && _cube[_size - 1 - i, StartIndex[1], _size - 1 - i] == 0))
                        return false;
                }
                else
                {
                    if (!(_cube[i, StartIndex[1], _size - 1 - i] == 0 && _cube[_size - 1 - i, StartIndex[1], i] == 0))
                        return false;
                }
            }
            return true;
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
