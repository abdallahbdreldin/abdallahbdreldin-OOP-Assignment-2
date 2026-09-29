namespace SRPLap.SupportTicket
{
    public static class PublicReply
    {
        public static string DraftPublicReply(int id, string agentName, string priority, DateTimeOffset openedAt)
        {
            var apology = priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
            return $"Hi,\n{apology}\nTicket {id} is with {agentName}. Next update before {SlaPolicy.SlaDeadline(priority, openedAt):u}.\n";
        }
    }
}
