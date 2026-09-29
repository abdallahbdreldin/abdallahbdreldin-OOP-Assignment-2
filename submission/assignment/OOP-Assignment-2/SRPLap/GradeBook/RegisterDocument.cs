namespace SRPLap.GradeBook
{
    public static class RegisterDocument
    {
        public static string TranscriptPlain(GradeBook gradeBook, string studentId, string fullName)
        {
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {gradeBook.Average(studentId)}\n" +
                $"Letter: {GradingPolicy.Letter(gradeBook, studentId)}\nHonor: {GradingPolicy.MeetsHonorRoll(gradeBook, studentId)}\n";
        }
    }
}
