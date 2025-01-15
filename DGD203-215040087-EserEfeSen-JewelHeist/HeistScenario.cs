using System;

namespace JewelHeistGame
{
    public static class HeistScenario
    {
        public static void RunHeist(Player player, Inventory inventory)
        {
            int punishment = player.Punishment;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("HEIST SCENARIO: The big robbery begins!");
            Console.ResetColor();
            Console.WriteLine($"Master Thief: {player.Name}\n");

            // Q1
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) You break into the jeweler's shop. Do you:");
            Console.WriteLine("   a) Go straight for the biggest diamond.");
            Console.WriteLine("   b) Search the back room for a safe.");
            Console.WriteLine("   c) Grab whatever you can from the nearest display.");
            Console.ResetColor();
            Console.Write("Choice (a/b/c)? ");
            string choice1 = Console.ReadLine().ToLower();

            if (choice1 == "a")
            {
                punishment += 4;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You chose the biggest diamond, drawing immediate attention.\n");
            }
            else if (choice1 == "b")
            {
                punishment += 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You looked for the safe, carefully but time-consuming.\n");
            }
            else if (choice1 == "c")
            {
                punishment += 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You grabbed random valuables, causing chaos and suspicion.\n");
            }
            Console.ResetColor();

            // Q2
            if (choice1 == "b")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("2) The safe has a keypad lock. Do you:");
                Console.WriteLine("   a) Try to crack the code yourself.");
                Console.WriteLine("   b) Use your AccessCard to open it.");
                Console.WriteLine("   c) Search the shop for the code.");
                Console.ResetColor();

                Console.Write("Choice (a/b/c)? ");
                string choice2 = Console.ReadLine().ToLower();

                if (choice2 == "a")
                {
                    punishment += 2;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You attempted to crack the code. It takes time, but you succeed.\n");
                }
                else if (choice2 == "b")
                {
                    if (inventory.HasItem("AccessCard"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You swipe the AccessCard. The safe opens smoothly without trouble!\n");
                    }
                    else
                    {
                        punishment += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You don't have the AccessCard! The safe remains locked, alarm intensifies.\n");
                    }
                }
                else if (choice2 == "c")
                {
                    punishment += 3;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You spend extra time searching for the code. Eventually, you find it.\n");
                }
                Console.ResetColor();
            }
            else
            {
                // If choice1 != b, proceed with the original scenario
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("2) As you grab items, you hear the police sirens. Do you:");
                Console.WriteLine("   a) Keep grabbing more loot.");
                Console.WriteLine("   b) Escape through the back door.");
                Console.WriteLine("   c) Pretend to be a customer locked inside.");
                Console.ResetColor();
                Console.Write("Choice (a/b/c)? ");
                string choice2 = Console.ReadLine().ToLower();

                if (choice2 == "a")
                {
                    punishment += 2;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You acted quickly, slightly reducing suspicion.\n");
                }
                else if (choice2 == "b")
                {
                    punishment += 4;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your escape was delayed, increasing your punishment.\n");
                }
                else if (choice2 == "c")
                {
                    punishment += 3;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your trickery delayed the inevitable, drawing extra scrutiny.\n");
                }
                Console.ResetColor();
            }

            // Q3
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3) While escaping, you encounter a locked exit. Do you:");
            Console.WriteLine("   a) Pick the lock.");
            Console.WriteLine("   b) Break it down.");
            Console.WriteLine("   c) Look for another exit.");
            Console.ResetColor();
            Console.Write("Choice (a/b/c)? ");
            string choice3 = Console.ReadLine().ToLower();

            if (choice3 == "a")
            {
                punishment += 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You showed skill, minimizing suspicion.\n");
            }
            else if (choice3 == "b")
            {
                punishment += 4;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You made a loud commotion, raising suspicion.\n");
            }
            else if (choice3 == "c")
            {
                punishment += 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You spent extra time finding another way.\n");
            }
            Console.ResetColor();

            // Q4
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("4) Outside, the police are in hot pursuit. Do you:");
            Console.WriteLine("   a) Try to lose them in an alley.");
            Console.WriteLine("   b) Hijack a car and drive away.");
            Console.WriteLine("   c) Attempt to talk your way out.");
            Console.ResetColor();
            Console.Write("Choice (a/b/c)? ");
            string choice4 = Console.ReadLine().ToLower();

            if (choice4 == "a")
            {
                punishment += 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You found temporary cover, but it wasn't very effective.\n");
            }
            else if (choice4 == "b")
            {
                punishment += 5;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hijacking a car added reckless driving charges.\n");
            }
            else if (choice4 == "c")
            {
                punishment += 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Surrendering lowered your punishment somewhat.\n");
            }
            Console.ResetColor();

            // Final sentencing
            player.Punishment = punishment;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nMr. {player.Name}, your total punishment score is {punishment}.");
            if (punishment <= 7)
            {
                Console.WriteLine("You got off with a light sentence. Maybe rethink your career path!");
                Console.WriteLine($"You are sentenced to {punishment} years in prison.");
            }
            else if (punishment <= 12)
            {
                Console.WriteLine("You received a moderate sentence. Luck wasn't entirely on your side.");
                Console.WriteLine($"You are sentenced to {punishment} years in prison.");
            }
            else
            {
                Console.WriteLine("You got the maximum sentence. Crime doesn't pay, does it?");
                Console.WriteLine($"You are sentenced to {punishment} years in prison.");
            }
            Console.ResetColor();

            // Mark the heist as completed
            player.IsHeistDone = true;
        }
    }
}