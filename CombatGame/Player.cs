namespace CombatGame;

public class Player
{
    private static readonly Random RandomNumberGenerator = new();

    public Player(string name)
    {
        Name = name;
        Health = 25;
        MinDamage = 1;
        MaxDamage = 6;
        CriticalChance = 15;
    }

    public string Name { get; private set; }

    public int Health { get; private set; }

    public int MinDamage { get; private set; }

    public int MaxDamage { get; private set; }

    public int CriticalChance { get; private set; }

    public bool Alive => Health > 0;

    public string Attack(Player other)
    {
        var damage = RandomNumberGenerator.Next(MinDamage, MaxDamage);

        var criticalHit = RandomNumberGenerator.Next(0, 100) <= CriticalChance;



        other.Health -= damage;

        return $"{Name} attacks {other.Name} for {damage} damage.";
    }

    public string Heal()
    {
        var heal = 3;
        Health += heal;

        return $"{Name} heals for {heal}.";
    }
}
