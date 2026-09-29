namespace LibrarySystem
{
    public class Member : Person
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public IReadOnlyList<Loan> Loans
        {
            get { return _loans; }
        }

        public int MaxLoans { get; }
        public decimal DiscountPercentage { get; }

        protected Member(int personId, string fullName, string phoneNumber, int maxLoans, decimal discountPercentage)
            : base(personId, fullName, phoneNumber)
        {
            MaxLoans = maxLoans;
            DiscountPercentage = discountPercentage;
        }

        public Loan BorrowItem(LibraryItem item, DateTime date)
        {
            if (item.IsWithdrawn)
            {
                throw new InvalidOperationException("A withdrawn item cannot be borrowed.");
            }

            if (item.IsOnLoan)
            {
                throw new InvalidOperationException("An item already on loan cannot be borrowed.");
            }

            if (GetActiveLoanCount() >= MaxLoans)
            {
                throw new InvalidOperationException("This member has reached the active loan limit.");
            }

            Loan loan = new Loan(this, item, date);
            _loans.Add(loan);
            item.SetOnLoan(true);
            return loan;
        }

        public void ReturnItem(int loanId, DateTime date)
        {
            foreach (Loan loan in _loans)
            {
                if (loan.LoanId == loanId)
                {
                    loan.MarkReturned(date);
                    return;
                }
            }

            throw new ArgumentException("The loan does not belong to this member.");
        }

        private int GetActiveLoanCount()
        {
            int activeLoans = 0;

            foreach (Loan loan in _loans)
            {
                if (loan.Status == LoanStatus.Borrowed)
                {
                    activeLoans++;
                }
            }

            return activeLoans;
        }
    }
}
