namespace PatternsLab.Builder
{
    public static class RegistrationCallSites
    {
        public static CourseRegistration CreateLiveStudent()
        {
            return new CourseRegistrationBuilder(
                    "sara@mail.com",
                    "SEF-101",
                    "LiveGroup")
                .WithGroupCode("G1")
                .WithDiscountCode("EARLY10")
                .SendWhatsApp()
                .SendEmailWelcome()
                .WithMentorNote("Needs evening slot")
                .WithPreferredStart(new DateOnly(2026, 10, 1))
                .Build();
        }

        public static CourseRegistration CreateVideosOnly()
        {
            return new CourseRegistrationBuilder(
                    "ali@mail.com",
                    "SEF-101",
                    "VideosOnly")
                .SendEmailWelcome()
                .Build();
        }
    }
}
