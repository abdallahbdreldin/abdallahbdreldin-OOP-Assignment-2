namespace LibrarySystem
{
    public class PremiumMember : Member
    {
        public int ReadingPoints
        {
            get
            {
                int returnedLoans = 0;

                foreach (Loan loan in Loans)
                {
                    if (loan.Status == LoanStatus.Returned)
                    {
                        returnedLoans++;
                    }
                }

                return returnedLoans * 5;
            }
        }

        public PremiumMember(int personId, string fullName, string phoneNumber, decimal discountPercentage)
            : base(personId, fullName, phoneNumber, 10, discountPercentage)
        {
            if (discountPercentage < 0m || discountPercentage > 100m)
            {
                throw new ArgumentException("Discount percentage must be from 0 to 100.");
            }
        }
    }
}
