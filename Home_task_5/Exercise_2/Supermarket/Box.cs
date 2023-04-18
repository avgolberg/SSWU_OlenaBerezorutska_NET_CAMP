using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Box
    {
        public string Title { get; private set; }
        public Size Size { get; private set; }
        public List<Box> Boxes { get; private set; }
        public List<string> History { get; private set; }

        public Box(string title, Product product)
        {
            Title = title;
            Size = new Size(product.Size.Length, product.Size.Width, product.Size.Height);
        }

        public Box(string title, List<Box> boxes)
        {
            Title = title;
            Boxes = new List<Box>(boxes);
            if (History == null)
                History = new List<string>();
            History.Add(string.Join("\n ", boxes));
            Size = new Size(Boxes.Max(b => b.Size.Length), Boxes.Max(b => b.Size.Width), Boxes.Sum(b => b.Size.Height));
        }
        public override string ToString()
        {
            if(History!=null)
                return $"Box \"{Title}\" ({Size})\n ({string.Join(" ", History)})";
            else
                return $"Box \"{Title}\" ({Size})";
        }
    }
}
