namespace SRPLap.SubscriptionBilling
{
    public class SubscriptionBilling
    {
        public string CustomerId { get; } = null!;
        public decimal MonthlyPrice { get; }
        public DateOnly PeriodStart { get; }
        public DateOnly PeriodEnd { get; }

        public int FailedPayments { get; private set; }

        public void RegisterFailedPayment()
        {
            FailedPayments++;
        }
    }
}
