namespace SRPLap.SubscriptionBilling
{
    public static class DunningEmail
    {
        public static string Generate(SubscriptionBilling subscriptionBilling, string customerName, DateOnly asOf)
        {
            var amount = ProrationCalculator.Prorate(subscriptionBilling, asOf);
            var invoice = InvoiceNumberGenerator.Next(subscriptionBilling);
            var severity = subscriptionBilling.FailedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({subscriptionBilling.FailedPayments} failures).\n";
        }
    }
}
