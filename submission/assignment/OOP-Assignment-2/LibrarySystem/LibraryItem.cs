namespace LibrarySystem
{
    public class LibraryItem
    {
        private decimal LateFeeMultiplier { get; }

        public string CatalogNumber { get; }
        public string Title { get; }
        public decimal BaseLateFee { get; private set; }
        public bool IsWithdrawn { get; private set; }
        public bool IsOnLoan { get; private set; }
        private int _loanPeriodDays { get; }

        protected LibraryItem(string catalogNumber, string title, decimal baseLateFee, int loanPeriodDays, decimal lateFeeMultiplier)
        {
            if (string.IsNullOrEmpty(catalogNumber))
            {
                throw new ArgumentException("Catalog number cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }

            if (baseLateFee <= 0m)
            {
                throw new ArgumentException("Base late fee must be positive.");
            }

            CatalogNumber = catalogNumber;
            Title = title;
            BaseLateFee = baseLateFee;
            _loanPeriodDays = loanPeriodDays;
            LateFeeMultiplier = lateFeeMultiplier;
        }

        public int GetLoanPeriodDays()
        {
            return _loanPeriodDays;
        }

        public decimal GetDailyLateFee()
        {
            return BaseLateFee * LateFeeMultiplier;
        }

        public void Withdraw()
        {
            IsWithdrawn = true;
        }

        public void Restore()
        {
            IsWithdrawn = false;
        }

        public void UpdateBaseFee(decimal newFee)
        {
            if (newFee <= 0m)
            {
                throw new ArgumentException("New late fee must be positive.");
            }

            BaseLateFee = newFee;
        }

        internal void SetOnLoan(bool isOnLoan)
        {
            IsOnLoan = isOnLoan;
        }
    }
}
