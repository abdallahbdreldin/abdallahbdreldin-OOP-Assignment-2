namespace LibrarySystem
{
    public class Staff : Person
    {
        private decimal ResponsibilityAllowance { get; }

        public DateTime HireDate { get; }
        public decimal MonthlySalary { get; private set; }

        protected Staff(int personId, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary, decimal responsibilityAllowance)
            : base(personId, fullName, phoneNumber)
        {
            HireDate = hireDate;
            MonthlySalary = monthlySalary;
            ResponsibilityAllowance = responsibilityAllowance;
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0m)
            {
                throw new ArgumentException("Raise percentage must be positive.");
            }

            MonthlySalary = MonthlySalary + (MonthlySalary * percentage / 100m);
        }

        public decimal GetMonthlyPay()
        {
            return MonthlySalary + ResponsibilityAllowance;
        }
    }
}
