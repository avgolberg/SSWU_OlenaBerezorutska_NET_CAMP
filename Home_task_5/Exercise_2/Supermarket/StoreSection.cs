using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    class StoreSection : IPackable
    {
        public string Name { get; private set; }
        public List<StoreSection> StoreSections { get; private set; } //посилання = пряма зміна ззовні

        public List<Product> Products { get; private set; }
        private List<Box> Boxes;

        public StoreSection(string name)
        {
            Name = name;
        }

        public int GetProductsCount()
        {
            if (Products != null)
                return Products.Count;
            else return -1;
        }

        public Box Pack()
        {
            Boxes = new List<Box>();
            if (StoreSections != null)
            {
                foreach (StoreSection section in StoreSections)
                {
                    if (section.Products != null && section.Products.Count != 0)
                        Boxes.Add(section.Pack());
                }
            }
            else
            {
                if (Products != null && Products.Count != 0)
                {
                    foreach (Product product in Products)
                    {
                        Boxes.Add(product.Pack());
                    }
                }
            }
            return new Box(Name, Boxes);
        }

        public void AddProduct(Product product, string path)
        {
            if (path.Contains(Name))
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                if (Products == null)
                    Products = new List<Product>();

                Products.Add(product);

                if (StoreSections != null)
                {
                    foreach (StoreSection section in StoreSections)
                    {
                        section.AddProduct(product, path);
                    }
                }
            }
        }

        public void AddSubsection(StoreSection subsection)
        {
            if (subsection == null)
                return;

            if (StoreSections == null)
                StoreSections = new List<StoreSection>();

            StoreSections.Add(subsection);
        }

        public override string ToString()
        {
            if (StoreSections == null)
                return $"{Name}";
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{Name} ({StoreSections.Count})\n");
                foreach (StoreSection item in StoreSections)
                {
                    sb.Append(item.ToString() + "\n");
                }
                return sb.ToString().Trim();
            }
        }
    }
}
