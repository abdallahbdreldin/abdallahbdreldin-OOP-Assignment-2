namespace SRPLap.CheckoutBasket
{
    public class GiftService
    {
        public bool GiftWrap { get; set; }
        public void EnableGiftWrap() => GiftWrap = true;

        public string GiftMessageCard(string fromName, CheckoutBasket basket)
        {
            // Customer-facing copy will change with marketing, not with totals.
            var items = string.Join(", ", basket.Lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {PricingCalculator.GrandTotal(basket):C}\n";
        }
    }
}
