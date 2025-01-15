using System;
// ESER EFE ŞEN - 215040087
class JewelHeistGame
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Welcome to the Great Jewel Heist Plan!");
        Console.ResetColor();
        Console.Write("What is your name, Master Thief?");
        string name = Console.ReadLine();
        Console.WriteLine($"Alright, Mr. {name}, let's see how your heist unfolds.\n");

        int punishment = 0;

        // Soru1
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("1. You break into the jeweler's shop. Do you:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("   a) Move towards the display case that contains the biggest diamond.");
        Console.WriteLine("   b) Look for the safe in the back room.");
        Console.WriteLine("   c) Take as much as you can carry from the nearest display.");
        Console.ResetColor();
        Console.Write("Choose your action (a, b, or c): ");
        string choice1 = Console.ReadLine().ToLower();

        if (choice1 == "a")
        {
            punishment += 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You chose to go for the biggest diamond, which attracted attention.\n");
        }
        else if (choice1 == "b")
        {
            punishment += 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You chose to look for the safe, showing careful planning but taking time.\n");
        }
        else if (choice1 == "c")
        {
            punishment += 3;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You grabbed random items, creating chaos but drawing suspicion.\n");
        }

        Console.ResetColor();


        // Soru2
        if (choice1 == "a")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("2. The alarm triggers as you smash the display. Do you:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   a) Run immediately.");
            Console.WriteLine("   b) Grab the diamond and hide in the shop.");
            Console.WriteLine("   c) Try to disable the alarm system.");
            Console.ResetColor();
        }
        else if (choice1 == "b")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("2. The safe is locked with a keypad. Do you:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   a) Try to crack the code yourself.");
            Console.WriteLine("   b) Use explosives to open it.");
            Console.WriteLine("   c) Search for the code elsewhere in the shop.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("2. As you grab the items, you hear police sirens. Do you:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   a) Continue grabbing more loot.");
            Console.WriteLine("   b) Escape through the back door.");
            Console.WriteLine("   c) Pretend to be a customer who got locked inside.");
            Console.ResetColor();
        }
        Console.Write("Choose your action (a, b, or c): ");
        string choice2 = Console.ReadLine().ToLower();

        if (choice2 == "a")
        {
            punishment += 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You acted quickly, reducing suspicion.\n");
        }
        else if (choice2 == "b")
        {
            punishment += 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your actions delayed your escape, increasing your punishment.\n");
        }
        else if (choice2 == "c")
        {
            punishment += 3;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your trickery delayed the inevitable but attracted scrutiny.\n");
        }
        Console.ResetColor();

        // Soru3
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("3. While escaping, you encounter a locked exit. Do you:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("   a) Pick the lock.");
        Console.WriteLine("   b) Break the door down.");
        Console.WriteLine("   c) Look for another way out.");
        Console.ResetColor();
        Console.Write("Choose your action (a, b, or c): ");
        string choice3 = Console.ReadLine().ToLower();

        if (choice3 == "a")
        {
            punishment += 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You showed skill and reduced your punishment.\n");
        }
        else if (choice3 == "b")
        {
            punishment += 4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Breaking the door caused noise and added suspicion.\n");
        }
        else if (choice3 == "c")
        {
            punishment += 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Looking for another exit cost you valuable time.\n");
        }
        Console.ResetColor();

        // Soru4
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("4. You are finally outside but being chased by the police. Do you:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("   a) Try to lose them in a nearby alley.");
        Console.WriteLine("   b) Hijack a car and drive away.");
        Console.WriteLine("   c) Surrender and try to talk your way out.");
        Console.ResetColor();
        Console.Write("Choose your action (a, b, or c): ");
        string choice4 = Console.ReadLine().ToLower();

        if (choice4 == "a")
        {
            punishment += 3;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The alley gave you a temporary lead but wasn’t effective.\n");
        }
        else if (choice4 == "b")
        {
            punishment += 5;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hijacking a car added reckless charges.\n");
        }
        else if (choice4 == "c")
        {
            punishment += 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Surrendering reduced your punishment.\n");
        }
        Console.ResetColor();

        // HapisCezası
        int prisonYears = punishment;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMr. {name}, your sentences have been calculated.");

        if (prisonYears <= 7)
        {
            Console.WriteLine("You got off with a light sentence. Maybe rethink your career path! Allah saved you.");
            Console.WriteLine($"You are sentenced to {prisonYears} years in prison.");
        }
        else if (prisonYears <= 12)
        {
            Console.WriteLine("You received a moderate sentence. Luck wasn’t entirely on your side. Good luck :)");
            Console.WriteLine($"You are sentenced to {prisonYears} years in prison.");
        }
        else if (prisonYears <= 15)
        {
            Console.WriteLine("You got the maximum sentence. Crime doesn’t pay, does it? (You got what you deserved, crime machine.)");
            Console.WriteLine($"You are sentenced to {prisonYears} years in prison.");
        }
        Console.ResetColor();
    }
}
