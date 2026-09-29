namespace SRPLap.GradeBook
{
    public static class GradingPolicy
    {
        public static string Letter(GradeBook gradeBook, string studentId)
        {
            var avg = gradeBook.Average(studentId);
            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";
            return "F";
        }

        public static bool MeetsHonorRoll(GradeBook gradeBook, string studentId)
        {
            return gradeBook.Average(studentId) >= 85 && Letter(gradeBook, studentId) is "A" or "B";
        }
    }
}
