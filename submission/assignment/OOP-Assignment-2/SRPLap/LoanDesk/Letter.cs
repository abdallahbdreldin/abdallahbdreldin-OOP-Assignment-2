namespace SRPLap.LoanDesk
{
    public static class Letter
    {
        public static string DecisionLetter(string applicantName, LoanDesk loanDesk)
        {
            // Legal/comms wording ≠ underwriting math.
            if (RiskScorer.IsEligible(loanDesk))
            {
                return $"Dear {applicantName},\nYour request for {loanDesk.RequestedAmount:C} is pre-approved (risk {RiskScorer.RiskScore(loanDesk):0}).\n" +
                       $"Please upload: {string.Join("; ", Document.RequiredDocuments(loanDesk))}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {loanDesk.RequestedAmount:C} at this time.\n" +
                   $"Reference risk={RiskScorer.RiskScore(loanDesk):0}. You may reapply after improving documentation.\n";
        }
    }
}
