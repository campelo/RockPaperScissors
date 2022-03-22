namespace RockPaperScissors
{
    public class AvailableChoice
    {
        public string Name { get; }
        public List<AvailableChoice> LosesTo = new List<AvailableChoice>();
        public List<AvailableChoice> WinsAgainst = new List<AvailableChoice>();

        public AvailableChoice(string name)
        {
            this.Name = name;
        }

        public override string ToString() => Name;
    }
}
