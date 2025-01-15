using System;

namespace JewelHeistGame
{
    public static class VanScenario
    {
        public static void RunVanScenario(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("GETAWAY VAN: This is your final chance to escape!");
            Console.ResetColor();

            Console.WriteLine($"\nMr. {player.Name}, you jump into the van with your loot.");
            Console.WriteLine("The police are right behind you, sirens blaring!\n");

            // We have one question with three choices:
            // Only 'b' leads to a successful escape,
            // 'a' and 'c' lead to capture.

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) You start the van and see a roadblock ahead. Do you:");
            Console.WriteLine("   a) Smash through the barricade at full speed.");
            Console.WriteLine("   b) Veer off to a side alley you see on the left.");
            Console.WriteLine("   c) Abandon the van and try to run on foot.");
            Console.ResetColor();

            Console.Write("Choice (a/b/c)? ");
            string choice1 = Console.ReadLine().ToLower();

            // We'll reuse the HeistScenario-style sentencing:
            int punishment = player.Punishment;

            if (choice1 == "b")
            {
                // SUCCESSFUL ESCAPE
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYou slip into the side alley. The police cars overshoot the turn!");
                Console.WriteLine("You manage to lose them and safely leave the city with the loot.");
                Console.ResetColor();

                // If you want no additional punishment, do nothing.
                // If you want a minor bonus or something, you can do: punishment += 0;

                Console.WriteLine("Congratulations, you have successfully escaped!");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();

                // Mark the Van scenario as done
                player.IsVanDone = true;
                // Optionally store updated punishment back
                player.Punishment = punishment;
            }
            else
            {
                // CAPTURED SCENARIO
                Console.ForegroundColor = ConsoleColor.Red;
                if (choice1 == "a")
                {
                    Console.WriteLine("\nYou slam into the barricade! The van is disabled, and the police swarm you.");
                }
                else if (choice1 == "c")
                {
                    Console.WriteLine("\nYou abandon the van, but the police quickly surround you on foot.");
                }
                else
                {
                    // If user typed something else (not a/b/c), 
                    // we treat as a failed scenario:
                    Console.WriteLine("\nIn your confusion, you hesitate and the police catch you swiftly!");
                }

                Console.WriteLine("You have been captured and the loot is confiscated!");
                Console.ResetColor();

                // We can apply an extra punishment for failing the Van scenario
                punishment += 5; // e.g. +5 for being captured

                // Now we do final sentencing exactly like the Heist scenario:
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

                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();

                // If you want, you could mark the game as ended or 
                // leave Van scenario incomplete. Typically, if the user is captured, 
                // we can consider the game over:
                // player.IsVanDone = false; // or just do nothing
            }
        }
    }
}
