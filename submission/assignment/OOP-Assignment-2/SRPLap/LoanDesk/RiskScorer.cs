namespace SRPLap.LoanDesk
{
    public static class RiskScorer
    {
        public static decimal RiskScore(LoanDesk loanDesk)
        {
            decimal score = 100m;
            score -= Math.Max(0, 700 - loanDesk.CreditScore) * 0.15m;
            if (loanDesk.EmploymentMonths < 6) score -= 20m;
            if (loanDesk.RequestedAmount > 50_000m && !loanDesk.HasCollateral) score -= 25m;
            if (loanDesk.RequestedAmount > 150_000m) score -= 10m;
            return Math.Clamp(score, 0m, 100m);
        }

        public static bool IsEligible(LoanDesk loanDesk) => RiskScore(loanDesk) >= 55m && loanDesk.CreditScore >= 580;
    }
}
