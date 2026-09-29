namespace SRPLap.WarehousePickList
{
    public class WarehousePickList
    {
        private readonly List<PickItem> _items = new();

        public IReadOnlyList<PickItem> Items => _items;


        public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        {
            _items.Add(new PickItem(sku, aisle, bin, qtyNeeded, qtyOnHand));
        }
    }
}
