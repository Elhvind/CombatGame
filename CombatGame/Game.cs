namespace CombatGame;

public class Game
{
    private readonly List<(int turn, string action)> _log;
    private readonly Player _player1;
    private readonly Player _player2;

    private Game(Player player1, Player player2)
    {
        _log = new();
        Turn = 1;
        _player1 = player1;
        _player2 = player2;
    }

    public bool Active => _player1.Alive && _player2.Alive;

    public Player CurrentPlayer => Turn % 2 == 0 ? _player2 : _player1;

    public Player OtherPlayer => Turn % 2 == 0 ? _player1 : _player2;

    public IReadOnlyList<Player> Players => new List<Player>()
    {
        _player1,
        _player2
    };

    public int Turn { get; private set; }

    public void LogAction(string action)
    {
        Console.WriteLine(action);
        _log.Add((Turn, action));
    }

    public ConsoleKeyInfo SelectAction()
    {
        Console.ForegroundColor = CurrentPlayer.Color;
        Console.Write(CurrentPlayer.Name);
        Console.ResetColor();
        Console.Write(" has to select an action: ");
        var key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }

    public void EndTurn()
    {
        Console.WriteLine();
        Console.WriteLine("Press <Enter> to end turn!");
        Console.ReadLine();
        Turn += 1;
    }

    public static Game Start()
    {
        var player1Color = ConsoleColor.Cyan;
        Console.WriteLine("Enter name of players:");
        Console.Write("Player 1: ");
        Console.ForegroundColor = player1Color;
        var player1Name = Console.ReadLine() ?? "Player 1";
        Console.ResetColor();
        var player1 = new Player(player1Name, player1Color);

        var player2Color = ConsoleColor.Blue;
        Console.Write("Player 2: ");
        Console.ForegroundColor = player2Color;
        var player2Name = Console.ReadLine() ?? "Player 2";
        Console.ResetColor();
        var player2 = new Player(player2Name, player2Color);

        return new Game(player1, player2);
    }
}
