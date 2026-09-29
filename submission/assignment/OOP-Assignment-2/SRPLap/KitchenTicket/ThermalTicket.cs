namespace SRPLap.KitchenTicket
{
    public static class ThermalTicket
    {
        public static string Build(KitchenTicket ticket, int orderNumber)
        {
            var width = 32;
            var line = new string('=', width);
            var body = string.Join('\n', ticket.Items.Select(i => $"* {i.Name.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var allergens = AllergenDetector.DetectAllergens(ticket);
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {EstimationCalculator.EstimatedReadyMinutes(ticket, 2)} MIN\n{body}\n{allergyLine}\n{line}\n";
        }

        public static string ExpoLaneHint(KitchenTicket ticket)
        {
            return AllergenDetector.DetectAllergens(ticket).Count > 0 ? "LANE-ALLERGY" : EstimationCalculator.EstimatedReadyMinutes(ticket, 2) > 20 ? "LANE-SLOW" : "LANE-FAST";
        }
    }
}
