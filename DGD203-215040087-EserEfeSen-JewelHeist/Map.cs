using System;
using System.Collections.Generic;

namespace JewelHeistGame
{
    public class Map
    {
        private Dictionary<(int, int), Location> locations;

        // Example final location: (2,0) => Getaway Van
        private (int, int) endLocation = (2, 0);

        public Map()
        {
            locations = new Dictionary<(int, int), Location>();

            // ENTRANCE (0,0)
            Location locEntrance = new Location
            {
                Name = "Entrance",
                Description = "A busy street near the jeweler's area.",
                Interaction = null
            };
            // Possible exits from Entrance
            locEntrance.Exits["east"] = (1, 0);
            // 'south' was leading to (0,1), which was null
            // We fix it by creating a real location for (0,1).
            locEntrance.Exits["south"] = (0, 1);

            // JEWELER'S SHOP (1,0)
            Location locJeweler = new Location
            {
                Name = "Jeweler's Shop",
                Description = "The main target of your heist. Shiny displays and a locked safe in the back.",
                Interaction = (player, inventory) =>
                {
                    if (!inventory.HasItem("AccessCard"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You find a mysterious AccessCard on the counter. (AccessCard acquired!)");
                        Console.ResetColor();
                        inventory.AddItem("AccessCard");
                    }
                    else
                    {
                        Console.WriteLine("Nothing else to find here.");
                    }
                }
            };
            locJeweler.Exits["west"] = (0, 0);
            locJeweler.Exits["south"] = (1, 1);
            locJeweler.Exits["east"] = (2, 0);

            // BACK ALLEY (1,1) – Tek seferlik Heist Partner NPC
            Location locAlley = new Location
            {
                Name = "Back Alley",
                Description = "A dark alley. Smells terrible, but might hold secrets.",
                Interaction = (player, inventory) =>
                {
                    if (!player.HasTalkedToAlleyNPC)
                    {
                        player.HasTalkedToAlleyNPC = true;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nA figure steps out of the shadows, approaching you...");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Heist Partner");
                        Console.ResetColor();
                        Console.Write(": ");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\"Psst... The quieter you do the job, the less time you'll serve if caught.\"");
                        Console.ResetColor();

                        Console.WriteLine("He tips his hat and disappears into the darkness.\n");
                    }
                    else
                    {
                        Console.WriteLine("The alley is empty now. Nobody else is around.");
                    }
                }
            };
            locAlley.Exits["north"] = (1, 0);

            // GETAWAY VAN (2,0)
            Location locGetaway = new Location
            {
                Name = "Getaway Van",
                Description = "Your final escape route. If you completed the heist, you can end the game here.",
                Interaction = null
            };
            locGetaway.Exits["west"] = (1, 0);

            // (0,1) -- NEW LOCATION so 'south' from entrance won't be null
            Location locSouth = new Location
            {
                Name = "Empty Street",
                Description = "You find yourself on a quiet, deserted street leading nowhere.",
                Interaction = null
            };
            // Let the user go back north to entrance
            locSouth.Exits["north"] = (0, 0);

            // Now add them all to the dictionary
            locations.Add((0, 0), locEntrance);
            locations.Add((1, 0), locJeweler);
            locations.Add((1, 1), locAlley);
            locations.Add((2, 0), locGetaway);
            locations.Add((0, 1), locSouth); // This fixes the null when going south from (0,0)
        }

        // Lokasyon döndürme
        public Location GetLocation(int x, int y)
        {
            if (locations.ContainsKey((x, y)))
            {
                return locations[(x, y)];
            }
            return null;
        }

        // Final konumu kontrol
        public bool IsEndLocation(int x, int y)
        {
            return (x, y) == endLocation;
        }
    }
}
