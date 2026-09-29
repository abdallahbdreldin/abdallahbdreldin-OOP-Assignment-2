namespace PatternsLab.Prototype;

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }

    private Elf(Elf other) : base(other) { }

    public override Enemy Clone() => new Elf(this);
}