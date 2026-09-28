namespace SRPLap.KitchenTicket
{
    public class MenuItem
    {
        public string Name { get; set; } = "";
        public List<string> Ingredients { get; set; } = new();
        public int PrepMinutes { get; set; }
    }
}
