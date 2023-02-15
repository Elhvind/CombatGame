using CombatGame;

var consoleLog = new List<(int turn, string action)>();

var turn = 1;
var currentPlayerIndex = 0;

var players = new Player[3]
{
    new Player("TonaldDrump"),
    new Player("Elhvind"),
    new Player("Mivsen"),
};

while (players.Count(p => p.Alive) > 1)
{
    PrintMenu(true);

    Console.Write("Select Action: ");

    var currentPlayer = players[currentPlayerIndex];
    var alivePlayers = players.Where(x => x.Alive && x.Name != currentPlayer.Name);

    string action;

    switch (Console.ReadKey())
    {
        case { Key: ConsoleKey.A }:
            Console.WriteLine();
            for (int i = 0; i < players.Length; i++)
            {
                var player = players[i];
                if (player.Alive && currentPlayerIndex != i)
                {
                    Console.WriteLine($"{i + 1}: {player.Name}");
                }
            }

            Console.Write("Select player to attack: ");
            int.TryParse(Console.ReadLine(), out var selectedPlayerIndex);

            var selectedPlayer = players[selectedPlayerIndex - 1];

            action = currentPlayer.Attack(selectedPlayer);
            break;

        case { Key: ConsoleKey.H }:
            Console.WriteLine();
            action = currentPlayer.Heal();
            break;

        default:
            continue;
    }

    consoleLog.Add((turn, action));

    Console.WriteLine();
    Console.WriteLine(action);
    Console.WriteLine();
    Console.WriteLine("Press <Enter> to end turn!");
    Console.ReadLine();

    AdvancePlayerTurn();
}

PrintMenu(false);

void AdvancePlayerTurn()
{
    var playerCount = players!.Length;
    if (playerCount > 1)
        currentPlayerIndex += 1;

    if (currentPlayerIndex == playerCount)
        currentPlayerIndex = 0;

    turn += 1;
}

void PrintMenu(bool showActions)
{
    const string divider = """---------------------------""";

    Console.Clear();
    Console.WriteLine(divider);

    for (int i = 0; i < players.Length; i++)
    {
        Console.WriteLine($"""
            Player {i + 1} {(currentPlayerIndex == i ? "(Active)" : "")}
            Name: {players[i].Name}
            HP:   {players[i].Health:00}
            {divider}
            """);
    }

    if (showActions)
    {
        Console.WriteLine($"""
            Actions:
            A - Attack
            H - Heal
            {divider}
            """);
    }
    else
    {
        foreach (var consoleLogItem in consoleLog)
        {
            Console.WriteLine($"{consoleLogItem.turn}: {consoleLogItem.action}");
        }
    }
}
