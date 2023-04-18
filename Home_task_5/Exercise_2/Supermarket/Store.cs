using System.Collections.Generic;
using System.Text;

namespace Supermarket
{

    class Store : IPackable
    {
        public string Name { get; private set; }
        public List<StoreSection> StoreSections { get; private set; }
        public Store(string name)
        {
            Name = name;
        }
        public void AddSection(StoreSection section)
        {
            if (section == null)
                return;

            if (StoreSections == null)
                StoreSections = new List<StoreSection>();

            StoreSections.Add(section);
        }

        public Box Pack()
        {
            List<Box> Boxes = new List<Box>();
            foreach (StoreSection section in StoreSections)
            {
                if (section.GetProductsCount() > 0)
                    Boxes.Add(section.Pack());
            }
            return new Box(Name, Boxes);
        }

        public void CreateStructure(string str)
        {
            List<(string, int)> structure = CountNesting(str);
            List<List<(string, int)>> result = new List<List<(string, int)>>();

            int index = 0;
            int nextIndex = 1;

            while (true)
            {
                index = structure.FindIndex(index, i => i.Item2 == 1);
                if (index == -1) break;
                nextIndex = structure.FindIndex(index + 1, i => i.Item2 == 1);
                if (nextIndex == -1)
                {
                    result.Add(structure.GetRange(index, structure.Count - index));
                    break;
                }
                result.Add(structure.GetRange(index, nextIndex- index));
                index += 1;
            }

            List<List<StoreSection>> storeSections = new List<List<StoreSection>>();
            List<StoreSection> sections = new List<StoreSection>();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[i].Count; j++)
                {
                    sections.Add(new StoreSection(result[i][j].Item1));
                }
                storeSections.Add(sections);
                sections = new List<StoreSection>();
            }

            int rootJ = 0;
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[i].Count - 1; j++)
                {
                    if (result[i][j].Item2 < result[i][j + 1].Item2)
                    {
                        storeSections[i][j].AddSubsection(storeSections[i][j + 1]);
                    }
                    else
                    {
                        storeSections[i][rootJ].AddSubsection(storeSections[i][j+1]);
                    }
                }
            }

            for (int i = 0; i < storeSections.Count; i++)
            {
                AddSection(storeSections[i][0]);
            }
        }

        private List<(string, int)> CountNesting(string str)
        {
            List<(string, int)> result = new List<(string, int)>();
            var parts = str.Split("|");
            int counter = -1;
            foreach (string item in parts)
            {
                if (string.IsNullOrWhiteSpace(item))
                    counter++;
                else
                {
                    result.Add((item, counter + 1));
                    counter = 0;
                }
            }
            return result;
        }

        public void Buy(Product product, string path)
        {
            foreach (StoreSection section in StoreSections)
            {
                if (path.Contains(section.Name))
                {
                    section.AddProduct(product, path);
                }
            }
        }

        public override string ToString()
        {
            if (StoreSections != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Store: {Name} ({StoreSections.Count}):\n");
                foreach (StoreSection item in StoreSections)
                {
                    sb.Append(item.ToString() + "\n");
                }
                return sb.ToString().Trim();
            }

            return $"Store: {Name}";
        }
    }
}
