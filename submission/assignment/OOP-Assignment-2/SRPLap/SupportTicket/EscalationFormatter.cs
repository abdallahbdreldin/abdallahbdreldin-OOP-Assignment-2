namespace SRPLap.SupportTicket
{
    public static class EscalationFormatter
    {
        public static string InternalEscalationBlurb(int id, string priority, DateTimeOffset openedAt)
        {
            return $"ESCALATE {id} priority={priority} breachAt={SlaPolicy.SlaDeadline(priority, openedAt):u} keywords-scanned=yes";
        }
    }
}
