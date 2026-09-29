namespace LibrarySystem
{
    public class Loan
    {
        private static int _nextLoanId = 1;

        public int LoanId { get; }
        public DateTime BorrowDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; private set; }
        public Member Member { get; }
        public LibraryItem Item { get; }
        public LoanStatus Status { get; private set; }
        public decimal LateFee
        {
            get
            {
                if (Status != LoanStatus.Returned || !ReturnDate.HasValue || ReturnDate.Value <= DueDate)
                {
                    return 0m;
                }

                DateTime actualReturnDate = ReturnDate.Value;
                int lateDays = (actualReturnDate.Date - DueDate.Date).Days;
                decimal feeBeforeDiscount = lateDays * Item.GetDailyLateFee();
                return feeBeforeDiscount - (feeBeforeDiscount * Member.DiscountPercentage / 100m);
            }
        }

        internal Loan(Member member, LibraryItem item, DateTime borrowDate)
        {
            Member = member;
            Item = item;
            BorrowDate = borrowDate;
            DueDate = borrowDate.AddDays(item.GetLoanPeriodDays());
            LoanId = _nextLoanId;
            _nextLoanId++;
            Status = LoanStatus.Borrowed;
        }

        public void MarkReturned(DateTime returnDate)
        {
            if (Status != LoanStatus.Borrowed)
            {
                throw new InvalidOperationException("Only a borrowed loan can be returned.");
            }

            if (returnDate < BorrowDate)
            {
                throw new ArgumentException("Return date cannot be earlier than the borrow date.");
            }

            ReturnDate = returnDate;
            Status = LoanStatus.Returned;
            Item.SetOnLoan(false);
        }

        public void MarkLost()
        {
            if (Status != LoanStatus.Borrowed)
            {
                throw new InvalidOperationException("Only a borrowed loan can be marked as lost.");
            }

            Status = LoanStatus.Lost;
            Item.SetOnLoan(false);
        }

        public decimal CalculateLateFee()
        {
            return LateFee;
        }
    }
}
