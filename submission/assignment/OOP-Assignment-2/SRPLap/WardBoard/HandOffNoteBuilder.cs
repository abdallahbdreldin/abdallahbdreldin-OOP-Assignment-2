namespace SRPLap.WardBoard
{
    public static class HandOffNoteBuilder
    {
        public static string Build(int bed, string patientId, int acuity)
        {
            var tone = acuity >= 8 ? "ESCALATE": acuity >= 4
                     ? "WATCH": "STABLE";

             return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patientId} · acuity={acuity} · {tone}";
        }
    }
}
