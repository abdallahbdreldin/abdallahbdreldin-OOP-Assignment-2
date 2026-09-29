namespace SRPLap.CourseEnrollmentDesk
{
    public class Waitlist
    {
        private readonly List<string> _waitlist = new();

        public bool IsContain(string email) =>
            _waitlist.Contains(email, StringComparer.OrdinalIgnoreCase);

        public void Add(string email) => _waitlist.Add(email);

        public int Count => _waitlist.Count;

        public int WaitlistPosition(string studentEmail)
        {
            var idx = _waitlist.FindIndex(x => x.Equals(studentEmail, StringComparison.OrdinalIgnoreCase));
            return idx < 0 ? -1 : idx + 1;
        }

        public string? Dequeue()
        {
            if (_waitlist.Count == 0)
                return null;

            var student = _waitlist[0];
            _waitlist.RemoveAt(0);
            return student;
        }
    }
}
