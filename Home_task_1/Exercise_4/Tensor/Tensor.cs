using System.Text;

namespace Tensor
{// Ідея в тому, що Ви маєте користувачу дати можливість працювати з різною вимірністю в зручній для нього формі,
    //а Ви використовуєте ідею, що в пам'яті скільки б не було вимірів, все зведеться до одновимірної системи...Це так. Але користувач має мати ілюзію роботи з вимірністю...
    
    internal class Tensor
    {
        private int[] _data;
        private int[] _shape;
        private int _elementsCount;
        public int Count { get { return _elementsCount; } }

        private int[] _elementsOnAxis;

        public Tensor(params int[] shape)
        {
            _shape = shape;
            _elementsCount = GetElementsCount();
            _data = new int[_elementsCount];
            _elementsOnAxis = GetElementsOnAxis();

            Fill();
        }

        public void Fill()
        {
            for (int i = 0; i < _elementsCount; i++)
            {
                _data[i] = i;
            }
        }

        public void Fill(int value)
        {
            for (int i = 0; i < _elementsCount; i++)
            {
                _data[i] = value;
            }
        }
        private int GetElementsCount()
        {
            int elements = 1;
            for (int i = 0; i < _shape.Length; i++)
            {
                elements *= _shape[i];
            }
            return elements;
        }

        private int[] GetElementsOnAxis()
        {
            int elements = 1;
            var elementsOnAxis = new int[_shape.Length];
            for (int i = _shape.Length - 1; i >= 0; i--)
            {
                elementsOnAxis[i] = elements;
                elements *= _shape[i];
            }
            return elementsOnAxis;
        }

        private int GetIndex(params int[] indices)
        {
            int index = 0;
            for (int i = 0; i < indices.Length; i++)
            {
                index += indices[i] * _elementsOnAxis[i];
            }
            return index;
        }

        public int this[params int[] indices]
        {
            get
            {
                return _data[GetIndex(indices)];
            }
            set
            {
                _data[GetIndex(indices)] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (_shape.Length == 1)
            {
                for (int i = 0; i < _elementsCount; i++)
                {
                    sb.Append(_data[i] + "\t"); //_elementsOnAxis[_shape.Length - 1] == 1
                }
            }
            else if (_shape.Length == 2)
            {
                for (int i = 0; i < _elementsCount; i++)
                {
                    sb.Append(_data[i] + "\t");
                    if ((i + 1) % _shape[_shape.Length - 1] == 0) //_elementsOnAxis[_shape.Length - 2]
                        sb.Append("\n");
                }
            }
            else
            {
                for (int i = 0; i < _elementsCount; i++)
                {
                    sb.Append(_data[i] + "\t"); 
                    if ((i + 1) % _shape[_shape.Length - 1] == 0) 
                        sb.Append("\n");

                    for (int j = _elementsOnAxis.Length - 3; j >= 0; j--)
                    {
                        if ((i + 1) % _elementsOnAxis[j] == 0)
                            sb.Append("\n");
                    }
                }
            }
            return sb.ToString().Trim();
        }
    }
}
