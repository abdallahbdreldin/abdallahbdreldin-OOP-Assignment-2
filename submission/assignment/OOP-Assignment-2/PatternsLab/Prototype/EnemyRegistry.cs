namespace PatternsLab.Prototype;

public class EnemyRegistry
{
    private readonly Dictionary<string, Enemy> _prototypes = new();

    public void Register(string key, Enemy prototype)
    {
        _prototypes[key] = prototype;
    }

    public Enemy Create(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"Prototype '{key}' not found.");

        return prototype.Clone();
    }
}