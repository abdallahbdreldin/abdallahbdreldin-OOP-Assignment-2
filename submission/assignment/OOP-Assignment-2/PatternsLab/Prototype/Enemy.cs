namespace PatternsLab.Prototype;

public abstract class Enemy
{
    private readonly string _modelData;

    public string Name { get; set; } = null!;
    public int Health { get; set; }
    public Weapon Weapon { get; set; } = null!;
    public List<string> Abilities { get; set; } = new();

    public string ModelId => _modelData;

    protected Enemy()
    {
        Console.WriteLine("...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    protected Enemy(Enemy other)
    {
        _modelData = other._modelData;

        Name = other.Name;
        Health = other.Health;

        Weapon = new Weapon
        {
            Name = other.Weapon.Name,
            Damage = other.Weapon.Damage
        };

        Abilities = new List<string>(other.Abilities);
    }

    public abstract Enemy Clone();
}