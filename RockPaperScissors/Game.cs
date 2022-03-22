namespace RockPaperScissors
{
    public class Game
    {
        private readonly int _rounds;
        private readonly int _victoryPoints;
        private Player player1;
        private Player player2;

        public Game(int rounds)
        {
            this._rounds = rounds;
            _victoryPoints = (int)Math.Ceiling(rounds / 2M);
        }

        public void StartGame(int humanPlayers)
        {
            InitPlayers(humanPlayers);

            for (int i = 0; i < _rounds && player1.Points < _victoryPoints && player2.Points < _victoryPoints; i++)
            {
                ChooseOption(player1);
                ChooseOption(player2);
                ShowRoundWinner(ref i);
            }
            ShowFinalWinner();
        }

        private void ShowFinalWinner()
        {
            Console.Clear();
            Player winner = player1.Points > player2.Points ? player1 : player2;
            Console.WriteLine($"{winner.Name} won :) Congratulations! Hit ENTER to continue...");
            Console.ReadLine();
        }

        private void ShowRoundWinner(ref int i)
        {
            Console.Clear();
            Console.WriteLine($"{player1.Name} chose {player1.CurrentChoice}");
            Console.WriteLine($"{player2.Name} chose {player2.CurrentChoice}");

            if (player1.CurrentChoice == player2.CurrentChoice)
            {
                Console.WriteLine($"It's a tie...");
                i--;
                Console.ReadLine();
                return;
            }
            Player roundWinner;
            if (player1.CurrentChoice.WinsAgainst.Contains(player2.CurrentChoice))
            {
                roundWinner = player1;
            }
            else
            {
                roundWinner = player2;
            }
            roundWinner.AddPoint();
            Console.WriteLine($"{roundWinner.Name} won this round. Hit ENTER to continue...");
            Console.ReadLine();
        }

        private void ChooseOption(Player player)
        {
            if (player.IsBot)
            {
                DoBotChoice(player);
            }
            else
            {
                DoHumanChoice(player);
            }
        }

        private void DoBotChoice(Player player)
        {
            if (player.CurrentChoice == null || player.FullyRandom)
            {
                player.CurrentChoice = GameHelper.Instance.PickRandomChoice();
            }
            else
            {
                player.CurrentChoice = player.CurrentChoice.LosesTo.First();
            }
        }

        private static void DoHumanChoice(Player player)
        {
            bool choiceMade = false;
            while (!choiceMade)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name} choose your option: ");
                int i = 1;
                GameHelper.Instance.AvailableChoices.ForEach(choice =>
                {
                    Console.WriteLine($"{i} - {choice}");
                    i++;
                });
                string? option = Console.ReadLine();
                int selectedOption = -1;
                if (!int.TryParse(option, out selectedOption) || selectedOption < 1 || selectedOption > GameHelper.Instance.AvailableChoices.Count)
                {
                    Console.WriteLine($"Please choose a valid option. Hit ENTER to continue...");
                    Console.ReadLine();
                }
                else
                {
                    player.CurrentChoice = GameHelper.Instance.AvailableChoices[selectedOption - 1];
                    choiceMade = true;
                }
            }
        }

        private void InitPlayers(int humanPlayers)
        {
            player1 = new Player("Player 1", humanPlayers <= 0);
            humanPlayers--;
            player2 = new Player("Player 2", humanPlayers <= 0, player1.IsBot);
        }
    }
}
