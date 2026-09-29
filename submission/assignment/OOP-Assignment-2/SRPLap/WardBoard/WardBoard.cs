namespace SRPLap.WardBoard
{
    public sealed class WardBoard
    {
        private readonly Dictionary<int, string> _bedPatients = new();
        public IReadOnlyDictionary<int, string> Beds => _bedPatients;

        public void AssignBed(int bed, string patientId)
        {
            if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
            if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

            _bedPatients[bed] = patientId.Trim().ToUpperInvariant();
        }
    }
}
