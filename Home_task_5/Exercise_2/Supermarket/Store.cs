using System;
using System.Collections.Generic;
using System.Linq;
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
        //  "|Технічний відділ||Комп'ютери|||Аксесуари||Побутова техніка|Продуктовий відділ||Молочний відділ||М'ясний відділ"
        public void CreateStructure(string str)
        {
            List<(string, int)> structure = CountNesting(str);
            List<List<(string, int)>> result = new List<List<(string, int)>>();

            //int count = 0;
            //var res = GetRange(structure, result[count].Count, 1);

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
                }
                index += 1;
                result.Add(structure.GetRange(index, structure.Count - nextIndex + 1));
            }

            List<List<StoreSection>> storeSections = new List<List<StoreSection>>();
            List<StoreSection> sections = new List<StoreSection>();
            foreach (var item in result)
            {
                foreach (var s in item)
                {
                    sections.Add(new StoreSection(s.Item1));
                }
                storeSections.Add(sections);
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
