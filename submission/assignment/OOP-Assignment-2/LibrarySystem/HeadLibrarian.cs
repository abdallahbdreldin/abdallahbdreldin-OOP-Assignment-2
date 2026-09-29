namespace LibrarySystem
{
    public class HeadLibrarian : Staff
    {
        public HeadLibrarian(
            int personId,
            string fullName,
            string phoneNumber,
            DateTime hireDate,
            decimal monthlySalary)
            : base(personId, fullName, phoneNumber, hireDate, monthlySalary, 400m)
        {
        }

        public void ChangeLateFee(LibraryItem item, decimal newFee)
        {
            item.UpdateBaseFee(newFee);
        }

        public void WithdrawItem(LibraryItem item)
        {
            item.Withdraw();
        }

        public void RestoreItem(LibraryItem item)
        {
            item.Restore();
        }
    }
}
