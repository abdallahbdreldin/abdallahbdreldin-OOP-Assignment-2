namespace SRPLap.SupportTicket
{
    public static class SlaPolicy
    {
        public static DateTimeOffset SlaDeadline(string priority, DateTimeOffset openedAt)
        {
            var hours = priority switch
            {
                "P1" => 4,
                "P2" => 24,
                _ => 72
            };
            return openedAt.AddHours(hours);
        }

        public static bool IsBreached(DateTimeOffset now, string priority, DateTimeOffset openedAt) {

            return now > SlaDeadline(priority, openedAt);
        }
    }
}
