namespace PatternsLab.Prototype;

public class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }

    private Orc(Orc other) : base(other) { }

    public override Enemy Clone() => new Orc(this);
}
