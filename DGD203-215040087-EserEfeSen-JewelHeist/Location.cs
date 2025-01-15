using System;
using System.Collections.Generic;

namespace JewelHeistGame
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, (int x, int y)> Exits { get; set; }
        public Action<Player, Inventory> Interaction { get; set; }

        public Location()
        {
            Exits = new Dictionary<string, (int, int)>();
        }

        public void Interact(Player player, Inventory inventory)
        {
            Interaction?.Invoke(player, inventory);
        }
    }
}
