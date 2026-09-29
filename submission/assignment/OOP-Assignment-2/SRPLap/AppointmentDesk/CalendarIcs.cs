namespace SRPLap.AppointmentDesk
{
    public static class CalendarIcs
    {
        public static string ToIcs(AppointmentDesk appointmentDesk, DateTimeOffset slot, string patientName, string clinician)
        {
            var uid = Guid.NewGuid();
            var end = slot.AddMinutes(appointmentDesk.SlotMinutes);
            return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
                   $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
                   $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
        }
    }
}
