namespace SRPLap.WarehousePickList
{
    public static class WmsXml
    {
        public static string WmsXmlBatch(WarehousePickList warehousePickList, string batchId)
        {
            var parts = StockAllocator.Allocate(warehousePickList).Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
        }
    }
}
