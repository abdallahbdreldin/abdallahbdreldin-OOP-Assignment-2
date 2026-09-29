namespace PatternsLab.Singleton
{
    public class UiService
    {
        public AppConfig Config => AppConfig.Instance;

        public void Render() =>
            Console.WriteLine($"UI is using theme: {Config.Theme}");
    }
}
