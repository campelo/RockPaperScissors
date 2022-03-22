using RockPaperScissors;

bool play = true;
while (play)
{
    Console.Clear();
    Console.WriteLine("Make your choice:");
    Console.WriteLine("1 - Human vs CPU");
    Console.WriteLine("2 - Human vs Human");
    Console.WriteLine("3 - CPU vs CPU");
    Console.WriteLine("0 - Quit");
    string? choice = Console.ReadLine();
    int humanPlayers = -1;
    switch (choice)
    {
        case "1":
            humanPlayers = 1;
            break;
        case "2":
            humanPlayers = 2;
            break;
        case "3":
            humanPlayers = 0;
            break;
        case "0":
            play = false;
            break;
        default:
            Console.WriteLine("Please choose a valid option. Hit ENTER to retry...");
            Console.ReadLine();
            break;
    }
    if (humanPlayers >= 0)
    {
        new Game(3).StartGame(humanPlayers);
    }
}