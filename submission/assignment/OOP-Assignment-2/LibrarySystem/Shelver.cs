namespace LibrarySystem
{
    public class Shelver : Staff
    {
        public string Section { get; private set; }

        public Shelver(int personId, string fullName, string phoneNumber, DateTime hireDate, decimal monthlySalary, string section)
            : base(personId, fullName, phoneNumber, hireDate, monthlySalary, 0m)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("Section cannot be null or empty.");
            }

            Section = section;
        }

        public void ReassignSection(string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("Section cannot be null or empty.");
            }

            Section = section;
        }
    }
}
