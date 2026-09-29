namespace SRPLap.SubscriptionBilling
{
    public static class ProrationCalculator
    {
        public static decimal Prorate(SubscriptionBilling subscriptionBilling, DateOnly activeFrom)
        {
            if (activeFrom <= subscriptionBilling.PeriodStart) return subscriptionBilling.MonthlyPrice;
            if (activeFrom >= subscriptionBilling.PeriodEnd) return 0m;
            var totalDays = subscriptionBilling.PeriodEnd.DayNumber - subscriptionBilling.PeriodStart.DayNumber;
            if (totalDays <= 0) return subscriptionBilling.MonthlyPrice;
            var used = subscriptionBilling.PeriodEnd.DayNumber - activeFrom.DayNumber;
            return Math.Round(subscriptionBilling.MonthlyPrice * used / totalDays, 2);
        }
    }
}
