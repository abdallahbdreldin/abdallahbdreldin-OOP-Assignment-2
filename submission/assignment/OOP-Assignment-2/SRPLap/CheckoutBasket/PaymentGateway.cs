namespace SRPLap.CheckoutBasket
{
    public static class PaymentGateway
    {
        public static string AuthorizePaymentStub(string cardLast4, CheckoutBasket basket)
        {
            // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
            var payload = $"{PricingCalculator.GrandTotal(basket):0.00}|{cardLast4}|{basket.Lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
