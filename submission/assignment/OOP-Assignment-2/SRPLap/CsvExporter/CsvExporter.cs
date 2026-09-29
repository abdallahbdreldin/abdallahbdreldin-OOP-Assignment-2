namespace SRPLap.CsvExporter
{
    public static class CsvExporter
    {
        public static string Export(List<string> rows)
        {
            return string.Join('\n', rows);
        }
    }
}
