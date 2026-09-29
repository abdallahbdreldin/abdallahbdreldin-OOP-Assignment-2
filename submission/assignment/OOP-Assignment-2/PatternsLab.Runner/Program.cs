using PatternsLab.Builder;
using PatternsLab.Prototype;
using PatternsLab.Singleton;
using System.Diagnostics;

namespace PatternsLab.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SINGLETON: AFTER ===\n");

            var db = new DatabaseService();
            var ui = new UiService();

            db.Config.Theme = "Dark";
            Console.WriteLine("Admin changed theme to Dark.\n");

            ui.Render();

            Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
            Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");

            Console.WriteLine("\n=== PROTOTYPE: AFTER ===\n");

            var registry = new EnemyRegistry();
            registry.Register("orc", new Orc());
            registry.Register("elf", new Elf());

            var sw = Stopwatch.StartNew();
            var army = new List<Enemy>();

            for (int i = 1; i <= 5; i++)
            {
                var orc = registry.Create("orc");
                orc.Name = $"Orc-{i}";
                army.Add(orc);
            }

            sw.Stop();

            Console.WriteLine($"Created 5 cloned orcs in {sw.ElapsedMilliseconds} ms\n");

            Enemy original = registry.Create("orc");
            original.Name = "Boss Orc";

            Enemy copy = original.Clone();

            Console.WriteLine($"Original model id: {original.ModelId}");
            Console.WriteLine($"Copy model id:     {copy.ModelId}");

            copy.Weapon.Damage = 999;

            Console.WriteLine("\nChanged COPY weapon damage to 999");
            Console.WriteLine($"Original weapon damage: {original.Weapon.Damage}");
            Console.WriteLine($"Copy weapon damage:     {copy.Weapon.Damage}");

            copy.Abilities.Add("Fire Breath");

            Console.WriteLine($"\nOriginal abilities: {string.Join(", ", original.Abilities)}");
            Console.WriteLine($"Copy abilities:     {string.Join(", ", copy.Abilities)}");

            Console.WriteLine("\n=== BUILDER: AFTER ===\n");

            Console.WriteLine(RegistrationCallSites.CreateLiveStudent());
            Console.WriteLine();
            Console.WriteLine(RegistrationCallSites.CreateVideosOnly());
        }
    }
}
