namespace SRPLap.KitchenTicket
{
    public class KitchenTicket
    {
        private readonly List<MenuItem> _items = new();

        public IReadOnlyList<MenuItem> Items => _items;

        public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
        {
            _items.Add(new MenuItem
            {
                Name = item,
                Ingredients = ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(),
                PrepMinutes = prepMinutes
            });
        }
    }
}
