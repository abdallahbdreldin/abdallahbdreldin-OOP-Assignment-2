namespace SRPLap.SubscriptionBilling
{
    public static class LedgerJournalLine
    {
        public static string Generate(SubscriptionBilling subscriptionBilling, DateOnly activeFrom)
        {
            return $"{subscriptionBilling.CustomerId},{InvoiceNumberGenerator.Next(subscriptionBilling)},{ProrationCalculator.Prorate(subscriptionBilling, activeFrom):0.00},AR-SUB";
        }
    }
}
