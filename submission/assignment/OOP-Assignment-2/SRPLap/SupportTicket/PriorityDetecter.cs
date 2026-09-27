namespace SRPLap.SupportTicket
{
    public class PriorityDetecter
    {
        public string Priority { get; private set; } = "P3";

        public void RecalculatePriorityFromText(string subject, string body)
        {
            var blob = (subject + " " + body).ToLowerInvariant();
            if (blob.Contains("down") || blob.Contains("outage") || blob.Contains("cannot login"))
                Priority = "P1";
            else if (blob.Contains("urgent") || blob.Contains("asap") || blob.Contains("blocked"))
                Priority = "P2";
            else
                Priority = "P3";
        }
    }
}
