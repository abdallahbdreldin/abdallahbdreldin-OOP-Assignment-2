namespace SRPLap.CheckoutBasket
{
    public class CheckoutBasket
    {
        private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
        public string? CouponCode { get; private set; }
        public bool GiftWrap { get; private set; }


        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0)
                throw new ArgumentOutOfRangeException(nameof(qty));

            _lines.Add((sku, price, qty));
        }

        public void ApplyCoupon(string? coupon) => CouponCode = coupon;

        public void EnableGiftWrap() => GiftWrap = true;
    }
}
