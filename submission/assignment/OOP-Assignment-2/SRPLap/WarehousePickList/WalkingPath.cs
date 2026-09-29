namespace SRPLap.WarehousePickList
{
    public static class WalkingPath
    {
        public static IReadOnlyList<PickItem> WalkingOrder(WarehousePickList warehousePickList)
        {
            return warehousePickList.Items
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Where(i => Math.Min(i.QtyNeeded, i.QtyOnHand) > 0)
                .Select(l => new PickItem(
                    l.Sku,
                    l.Aisle,
                    l.Bin,
                    Math.Min(l.QtyNeeded, l.QtyOnHand),
                    l.QtyOnHand))
                .ToList();
        }
    }
}
