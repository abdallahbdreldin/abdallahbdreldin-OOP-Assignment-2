namespace PatternsLab.Singleton
{
    public class DatabaseService
    {
        public AppConfig Config => AppConfig.Instance;

        public void Connect() =>
            Console.WriteLine($"Connecting to {Config.DbConnection}");
    }
}
