namespace JewelHeistGame
{
    public class Player
    {
        /// <summary>
        /// The name of the player (Master Thief).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Overall "punishment" points, increases based on heist choices.
        /// </summary>
        public int Punishment { get; set; }

        /// <summary>
        /// Whether the main Heist scenario has been completed.
        /// </summary>
        public bool IsHeistDone { get; set; }

        /// <summary>
        /// Whether the Police Chase scenario has been completed.
        /// </summary>
        public bool IsChaseDone { get; set; }

        /// <summary>
        /// Whether the Van Escape scenario has been completed.
        /// </summary>
        public bool IsVanDone { get; set; }

        /// <summary>
        /// Whether the game is over (player has been captured or successfully escaped).
        /// </summary>
        public bool IsGameOver { get; set; }

        /// <summary>
        /// The player's current position X on the map.
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// The player's current position Y on the map.
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Whether the player has already spoken with the NPC in the Back Alley (single-use conversation).
        /// </summary>
        public bool HasTalkedToAlleyNPC { get; set; }

        /// <summary>
        /// Default constructor sets initial values.
        /// </summary>
        public Player()
        {
            Name = "Unknown";
            Punishment = 0;
            IsHeistDone = false;
            IsChaseDone = false;
            IsVanDone = false;
            IsGameOver = false;
            PositionX = 0;
            PositionY = 0;
            HasTalkedToAlleyNPC = false;
        }
    }
}
