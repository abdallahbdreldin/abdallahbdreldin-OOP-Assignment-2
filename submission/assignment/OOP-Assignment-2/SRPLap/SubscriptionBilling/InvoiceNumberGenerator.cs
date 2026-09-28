namespace SRPLap.SubscriptionBilling
{
    public static class InvoiceNumberGenerator
    {
        private static int _invoiceSeq = 1000;

        public static string Next(SubscriptionBilling billing)
        {
            var number = ++_invoiceSeq;
            return $"INV-{billing.PeriodStart:yyyyMM}-{number:D5}";
        }
    }
}
