namespace SRPLap.CourseEnrollmentDesk
{
    public class Invoice
    {
        public decimal Tuition { get; }

        public Invoice(decimal tuition)
        {
            Tuition = tuition;
        }

        public string TuitionInvoiceLine(CourseEnrollmentDesk courseEnrollmentDesk, string studentEmail)
        {
            if (!courseEnrollmentDesk.Seats.Contains(studentEmail)) return $"{courseEnrollmentDesk.CourseCode},WAITLIST,0.00";
            var vat = Math.Round(Tuition * 0.14m, 2);
            return $"{courseEnrollmentDesk.CourseCode},TUITION,{Tuition:0.00},VAT,{vat:0.00},TOTAL,{(Tuition + vat):0.00}";
        }
    }
}
