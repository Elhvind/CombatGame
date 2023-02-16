var game = Game.Start();

while (game.Active)
{
    PrintMenu();

    string action;
    switch (game.SelectAction())
    {
        case { Key: ConsoleKey.A }:
            action = game.CurrentPlayer.Attack(game.OtherPlayer);
            break;

        case { Key: ConsoleKey.H }:
            action = game.CurrentPlayer.Heal();
            break;

        default:
            continue;
    }

    game.LogAction(action);

    game.EndTurn();
}

void PrintMenu()
{
    Console.Clear();
    foreach (var player in game.Players)
    {
        Console.ForegroundColor = player.Color;
        Console.WriteLine($"""
        --- Player ---
        Name: {player.Name}
        HP:   {player.Health:00}
        DMG:  {player.MinDamage}-{player.MaxDamage}
        Heal: {player.MinHeal}-{player.MaxHeal}
        """);
        Console.ResetColor();
    }
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"""
        --- Action ---
        A  -  Attack
        H  -  Heal
        --------------
        """);
    Console.ResetColor();
}
