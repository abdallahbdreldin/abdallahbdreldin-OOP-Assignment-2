namespace SRPLap.WarehousePickList
{
    public static class PickerScript
    {
         public static string Generate(WarehousePickList warehousePickList)
        {
            var steps = WalkingPath.WalkingOrder(warehousePickList)
                .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.QtyNeeded} × {s.Sku}");
            var shortfalls = StockAllocator.Allocate(warehousePickList).Where(a =>
            {
                var need = warehousePickList.Items.First(l => l.Sku == a.Sku).QtyNeeded;
                return a.Allocated < need;
            });
            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";
            return string.Join('\n', steps) + "\n" + warn;
        }

    }
}
