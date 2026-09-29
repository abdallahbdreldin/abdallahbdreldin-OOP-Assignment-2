namespace LibrarySystem
{
    public class Librarian : Staff
    {
        public Librarian(int personId, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary)
            : base(personId, fullName, phoneNumber, hireDate, monthlySalary, 0m)
        {
        }

        public void ProcessReturn(Loan loan, DateTime date)
        {
            loan.MarkReturned(date);
        }

        public void MarkItemAsLost(Loan loan)
        {
            loan.MarkLost();
        }
    }
}
