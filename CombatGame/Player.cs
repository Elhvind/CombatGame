namespace CombatGame;

public class Player
{
    private static readonly Random Random = new();

    public Player(string name, ConsoleColor color)
    {
        Name = name;
        Color = color;
        Health = 25;
        MinDamage = 2;
        MaxDamage = 6;
        MinHeal = 2;
        MaxHeal = 6;
    }

    public ConsoleColor Color { get; }

    public bool Alive => Health > 0;

    public string Name { get; }

    public int Health { get; private set; }

    public int MinDamage { get; private set; }

    public int MaxDamage { get; private set; }

    public int MinHeal { get; private set; }

    public int MaxHeal { get; private set; }

    public string Attack(Player other)
    {
        var damage = Random.Next(MinDamage, MaxDamage);
        other.Health -= damage;
        return $"{Name} attacks {other.Name} for {damage}.";
    }

    public string Heal()
    {
        var heal = Random.Next(MinHeal, MaxHeal);
        Health += heal;
        return $"{Name} heals for {heal}.";
    }
}
