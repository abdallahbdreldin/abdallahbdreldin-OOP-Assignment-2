namespace SRPLap.WardBoard
{
    public sealed class PagerLog
    {
        private readonly List<string> _pagerLog = new();

        public void AddCodeYellow(int bed)
        {
            _pagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }

        public IReadOnlyList<string> DrainPagerLog()
        {
            var copy = _pagerLog.ToList();
            _pagerLog.Clear();
            return copy;
        }
    }
}
