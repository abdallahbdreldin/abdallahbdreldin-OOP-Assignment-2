namespace SRPLap.WarehousePickList
{
    public static class StockAllocator
    {
        public static IReadOnlyList<(string Sku, int Allocated)> Allocate(WarehousePickList warehousePickList)
        {
            var result = new List<(string, int)>();
            foreach (var line in warehousePickList.Items)
            {
                var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, alloc));
            }
            return result;
        }
    }
}
