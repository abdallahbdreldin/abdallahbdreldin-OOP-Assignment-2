namespace SRPLap.CourseEnrollmentDesk
{
    public class CourseEnrollmentDesk
    {
        private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
        public HashSet<string> Seats => _seated;
        private readonly Waitlist _waitlist;
        public int Capacity { get; }
        public bool HasAvailableSeat => Seats.Count < Capacity;
        public string CourseCode { get; }


        public CourseEnrollmentDesk(string courseCode, int capacity, Waitlist waitlist)
        {
            CourseCode = courseCode;
            Capacity = capacity;
            _waitlist = waitlist;
        }

        public string Register(string studentEmail)
        {
            if (string.IsNullOrWhiteSpace(studentEmail))
                throw new ArgumentException("email");

            var email = studentEmail.Trim();

            if (Seats.Contains(email) || _waitlist.IsContain(email))
                return "ALREADY_REGISTERED";

            if (Seats.Count < Capacity)
            {
                Seats.Add(email);
                return "SEATED";
            }

            _waitlist.Add(email);
            return $"WAITLIST:{_waitlist.Count}";
        }

        public void PromoteFromWaitingList()
        {
            if (!HasAvailableSeat) return;

            var student = _waitlist.Dequeue();

            if (student is not null) Seats.Add(student);
        }
    }
}
