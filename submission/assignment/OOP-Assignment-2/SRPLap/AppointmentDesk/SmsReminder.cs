namespace SRPLap.AppointmentDesk
{
    public static class SmsReminder
    {
        public static string Send(AppointmentDesk appointmentDesk, DateTimeOffset slot, string clinicPhone)
        {
            return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
        }
    }
}
