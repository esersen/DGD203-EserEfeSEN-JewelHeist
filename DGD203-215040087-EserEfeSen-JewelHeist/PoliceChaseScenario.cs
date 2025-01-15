using System;

namespace JewelHeistGame
{
    public static class PoliceChaseScenario
    {
        public static void RunChase(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("POLICE CHASE: The sirens are blaring, and they're hot on your trail!");
            Console.ResetColor();

            Console.WriteLine($"\nMr. {player.Name}, you dash out of the jeweler's shop and see patrol cars converging.");
            Console.WriteLine("You need to make some quick decisions to evade capture.\n");

            int extraPunishment = 0;

            // Q1
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) A police car blocks the main road. Do you:");
            Console.WriteLine("   a) Ram the police car and force your way through.");
            Console.WriteLine("   b) Swerve onto a narrow side street.");
            Console.WriteLine("   c) Take a hostage to negotiate.");
            Console.ResetColor();
            Console.Write("Choice (a/b/c)? ");
            string choice1 = Console.ReadLine().ToLower();

            if (choice1 == "a")
            {
                extraPunishment += 4;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You smash into the police car, creating chaos and more charges.\n");
            }
            else if (choice1 == "b")
            {
                extraPunishment += 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You quickly veer into a side street, temporarily losing them.\n");
            }
            else if (choice1 == "c")
            {
                extraPunishment += 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Taking a hostage escalates the situation drastically.\n");
            }
            Console.ResetColor();

            // Q2
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2) You see flashing lights ahead. More cops inbound. Do you:");
            Console.WriteLine("   a) Hide in a nearby warehouse.");
            Console.WriteLine("   b) Try to outrun them in a stolen sports car.");
            Console.WriteLine("   c) Surrender and hope for leniency.");
            Console.ResetColor();
            Console.Write("Choice (a/b/c)? ");
            string choice2 = Console.ReadLine().ToLower();

            if (choice2 == "a")
            {
                extraPunishment += 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You hide in the warehouse for a while, eventually sneaking out.\n");
            }
            else if (choice2 == "b")
            {
                extraPunishment += 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You grab a fast car, but the risk and charges increase.\n");
            }
            else if (choice2 == "c")
            {
                // Player surrenders
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou surrender to the authorities... chase ends abruptly.\n");
                Console.ResetColor();

                // No extra punishment for surrendering
                // Update player punishment
                player.Punishment += extraPunishment;

                // Calculate final sentencing
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Mr. {player.Name}, your total punishment score is {player.Punishment}.");
                if (player.Punishment <= 7)
                {
                    Console.WriteLine("You got off with a light sentence. Maybe rethink your career path!");
                    Console.WriteLine($"You are sentenced to {player.Punishment} years in prison.");
                }
                else if (player.Punishment <= 12)
                {
                    Console.WriteLine("You received a moderate sentence. Luck wasn't entirely on your side.");
                    Console.WriteLine($"You are sentenced to {player.Punishment} years in prison.");
                }
                else
                {
                    Console.WriteLine("You got the maximum sentence. Crime doesn't pay, does it?");
                    Console.WriteLine($"You are sentenced to {player.Punishment} years in prison.");
                }
                Console.ResetColor();

                // Mark the game as over
                player.IsGameOver = true;

                Console.WriteLine("\nPress ENTER to exit the game.");
                Console.ReadLine();

                // Terminate the application
                Environment.Exit(0);
            }
            Console.ResetColor();

            // After Q2, if not surrendered, proceed to VanScenario
            Console.WriteLine("You managed to slip away from the immediate pursuit... for now.");
            Console.WriteLine("Press ENTER to continue to your getaway van!");
            Console.ReadLine();
        }
    }
}
