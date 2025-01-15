using System;
using System.Collections.Generic;

namespace JewelHeistGame
{
    public class Inventory
    {
        private List<string> items;

        public Inventory()
        {
            items = new List<string>();
        }

        public void AddItem(string item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                Console.WriteLine($"You picked up: {item}");
            }
            else
            {
                Console.WriteLine($"You already have {item}.");
            }
        }

        public bool HasItem(string item) => items.Contains(item);

        public void ShowItems()
        {
            Console.WriteLine("=== Your Inventory ===");
            if (items.Count == 0)
            {
                Console.WriteLine("No items.");
            }
            else
            {
                foreach (var i in items)
                {
                    Console.WriteLine($" - {i}");
                }
            }
        }

        public void ClearItems()
        {
            items.Clear();
        }

        public List<string> GetItems()
        {
            return items;
        }
    }
}
