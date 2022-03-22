namespace RockPaperScissors
{
    public class AvailableChoice
    {
        public string Name { get; }

        //Another option to do the same thing that LosesTo do, or you can keep both of them for specific requirements...
        //public List<AvailableChoice> WinsAgainst = new List<AvailableChoice>();

        public List<AvailableChoice> LosesTo = new List<AvailableChoice>();

        public AvailableChoice(string name)
        {
            this.Name = name;
        }

        public override string ToString() => Name;
    }
}
