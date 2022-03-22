namespace RockPaperScissors
{
    public sealed class GameHelper
    {
        private static GameHelper? instance = null;

        private readonly List<AvailableChoice> availableChoices = new List<AvailableChoice>();

        public static GameHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameHelper();
                }
                return instance;
            }
        }

        private GameHelper()
        {
            InitAllChoices();
        }

        private void InitAllChoices()
        {
            AvailableChoice rock = new AvailableChoice("rock");
            AvailableChoice paper = new AvailableChoice("paper");
            AvailableChoice scissors = new AvailableChoice("scissors");
            AvailableChoice flamethrower = new AvailableChoice("flamethrower");

            rock.LosesTo.Add(paper);
            
            paper.LosesTo.Add(scissors);
            paper.LosesTo.Add(flamethrower);

            scissors.LosesTo.Add(rock);

            flamethrower.LosesTo.Add(rock);
            flamethrower.LosesTo.Add(scissors);

            availableChoices.Add(rock);
            availableChoices.Add(paper);
            availableChoices.Add(scissors);
            availableChoices.Add(flamethrower);
        }

        public AvailableChoice PickRandomChoice()
        {
            Random random = new Random();
            int i = random.Next(availableChoices.Count);
            return availableChoices[i];
        }

        public List<AvailableChoice> AvailableChoices => availableChoices;

    }
}
