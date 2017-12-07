using System.Collections.Generic;

namespace patterns.Builder
{
    public class House
    {
        private List<string> _items;

        public House()
        {
            _items = new List<string>();
        }

        public void Add(string item)
        {
            _items.Add(item);
        }

        public void Show()
        {
            foreach (var item in _items)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
