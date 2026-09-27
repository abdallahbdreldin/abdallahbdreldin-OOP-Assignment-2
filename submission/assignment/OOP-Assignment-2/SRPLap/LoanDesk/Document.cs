namespace SRPLap.LoanDesk
{
    public static class Document
    {
        public static IReadOnlyList<string> RequiredDocuments(LoanDesk loanDesk)
        {
            var docs = new List<string> { "National ID", "Proof of income (3 months)" };
            if (loanDesk.RequestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
            if (loanDesk.HasCollateral) docs.Add("Collateral ownership deed");
            if (loanDesk.EmploymentMonths < 12) docs.Add("Employer letter");
            if (!RiskScorer.IsEligible(loanDesk)) docs.Add("Manual underwriter referral form");
            return docs;
        }
    }
}
