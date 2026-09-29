namespace SRPLap.CourseEnrollmentDesk
{
    public static class WelcomePacket
    {
        public static string WelcomePacketMarkdown(CourseEnrollmentDesk courseEnrollmentDesk, Waitlist waitlist, string studentEmail, string studentName)
        {
            var status = courseEnrollmentDesk.Seats.Contains(studentEmail) ? "confirmed seat" : $"waitlist #{waitlist.WaitlistPosition(studentEmail)}";
            return $"# Welcome to {courseEnrollmentDesk.CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseEnrollmentDesk.CourseCode.ToLowerInvariant()}\n";
        }
    }
}
