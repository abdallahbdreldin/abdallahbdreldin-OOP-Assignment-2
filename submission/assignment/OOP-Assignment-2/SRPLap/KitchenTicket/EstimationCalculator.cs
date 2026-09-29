namespace SRPLap.KitchenTicket
{
    public static class EstimationCalculator
    {
        public static int EstimatedReadyMinutes(KitchenTicket ticket, int openStations)
        {
            if (openStations <= 0) openStations = 1;
            var sequential = ticket.Items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (AllergenDetector.DetectAllergens(ticket).Count > 0) parallel += 3;
            var longest = ticket.Items.Count == 0 ? 0 : ticket.Items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
