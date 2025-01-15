using System;

namespace JewelHeistGame
{
    public class Game
    {
        private bool isRunning = true;
        private Map map;
        private Player player;
        private Inventory inventory;

        public Game()
        {
            map = new Map();
            player = new Player();
            inventory = new Inventory();
        }

        public void Run()
        {
            while (isRunning)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=== GREAT JEWEL HEIST (Main Menu) ===");
            Console.ResetColor();

            Console.WriteLine("1) New Game");
            Console.WriteLine("2) Credits");
            Console.WriteLine("3) Exit");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose an option: ");
            Console.ResetColor();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Press ENTER to continue.");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }

        private void StartNewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("What is your name, Master Thief? ");
            Console.ResetColor();

            string name = Console.ReadLine();
            player.Name = name;
            player.Punishment = 0;
            player.IsHeistDone = false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nAlright, Mr. {player.Name}, you begin your grand plan...");
            Console.ResetColor();

            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();

            Explore();
        }

        private void ShowCredits()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== CREDITS ===");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game by Eser Efe ŞEN - 215040087");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" - Microsoft C# Documentation");
            Console.WriteLine(" - StackOverflow Community");
            Console.WriteLine(" - ChatGPT (OpenAI)");
            Console.WriteLine(" - Teacher's hints and materials");
            Console.ResetColor();

            Console.WriteLine("Press ENTER to return to menu.");
            Console.ReadLine();
        }

        private void Explore()
        {
            bool inGame = true;
            player.PositionX = 0;
            player.PositionY = 0;

            while (inGame)
            {
                Console.Clear();
                Location currentLocation = map.GetLocation(player.PositionX, player.PositionY);

                if (currentLocation == null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You are in an unremarkable area. No location found.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"You are at: {currentLocation.Name}");
                    Console.ResetColor();

                    Console.WriteLine(currentLocation.Description);

                    if (currentLocation.Exits.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nPossible directions you can go:");
                        foreach (var exit in currentLocation.Exits.Keys)
                        {
                            Console.WriteLine($" - {exit}");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("There are no obvious exits from here.");
                        Console.ResetColor();
                    }

                    currentLocation.Interact(player, inventory);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Commands: north, south, east, west, inventory, heist, exit");
                Console.ResetColor();

                Console.Write("What do you do? ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        MovePlayer(command);
                        break;

                    case "inventory":
                        inventory.ShowItems();
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadLine();
                        break;

                    case "heist":
                        {
                            Location loc = map.GetLocation(player.PositionX, player.PositionY);
                            if (loc != null && loc.Name == "Jeweler's Shop")
                            {
                                // 1) Heist
                                HeistScenario.RunHeist(player, inventory);

                                // 2) Polis kovalamacası
                                PoliceChaseScenario.RunChase(player);

                                // 3) Van'a kaçış
                                VanScenario.RunVanScenario(player);

                                // Oyun sonu
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYour big adventure is now over. Returning to main menu...");
                                Console.ResetColor();
                                Console.WriteLine("Press ENTER to continue.");
                                Console.ReadLine();

                                // Explore döngüsünden çık
                                inGame = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There's no heist to do here...");
                                Console.ResetColor();
                                Console.ReadLine();
                            }
                            break;
                        }

                    case "exit":
                        inGame = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unknown command. Press ENTER to continue.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void MovePlayer(string direction)
        {
            Location currentLocation = map.GetLocation(player.PositionX, player.PositionY);
            if (currentLocation == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No valid location here. Press ENTER to continue.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            if (currentLocation.Exits.ContainsKey(direction))
            {
                var newCoords = currentLocation.Exits[direction];
                player.PositionX = newCoords.x;
                player.PositionY = newCoords.y;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You cannot go {direction} from here!");
                Console.ResetColor();
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
            }
        }
    }
}
