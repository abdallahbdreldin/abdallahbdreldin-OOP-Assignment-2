namespace SRPLap.CheckoutBasket
{
    public static class PricingCalculator
    {
        public static decimal SubTotal(CheckoutBasket basket)
            => basket.Lines.Sum(l => l.Price * l.Qty);

        public static decimal DiscountAmount(CheckoutBasket basket)
        {
            if (string.IsNullOrWhiteSpace(basket.CouponCode))
                return 0m;

            var t = basket.CouponCode.Trim().ToUpperInvariant();

            if (t.StartsWith("SAVE") &&
                int.TryParse(t[4..], out var pct) &&
                pct is > 0 and <= 50)
            {
                return Math.Round(SubTotal(basket) * pct / 100m, 2);
            }

            if (t == "WELCOME10")
                return Math.Min(10m, SubTotal(basket));

            return 0m;
        }

        public static decimal GrandTotal(CheckoutBasket basket)
        {
            var total = SubTotal(basket) - DiscountAmount(basket);

            if (basket.GiftWrap)
                total += 4.99m;

            return Math.Max(0m, total);
        }
    }
}
