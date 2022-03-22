namespace RockPaperScissors
{
    public class Player
    {
        public Player(string name, bool isBot)
            : this(name, isBot, false) { }

        public Player(string name, bool isBot, bool fullyRandom)
        {
            this.Name = name;
            this.IsBot = isBot;
            this.FullyRandom = fullyRandom;
        }

        public string Name { get; }
        public bool IsBot { get; }
        public bool FullyRandom { get; }
        public int Points { get; private set; } = 0;
        public AvailableChoice CurrentChoice { get; set; }

        public void AddPoint() => this.Points++;

    }
}
