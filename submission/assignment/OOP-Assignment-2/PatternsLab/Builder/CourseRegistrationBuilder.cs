namespace PatternsLab.Builder;

public class CourseRegistrationBuilder
{
    // Required
    private readonly string _studentEmail;
    private readonly string _courseCode;
    private readonly string _accessMode;

    // Optional
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;

    public CourseRegistrationBuilder(
        string studentEmail,
        string courseCode,
        string accessMode)
    {
        _studentEmail = studentEmail;
        _courseCode = courseCode;
        _accessMode = accessMode;
    }

    public CourseRegistrationBuilder WithGroupCode(string groupCode)
    {
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder WithDiscountCode(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder SendWhatsApp()
    {
        _sendWhatsApp = true;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome()
    {
        _sendEmailWelcome = true;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string note)
    {
        _mentorNote = note;
        return this;
    }

    public CourseRegistrationBuilder WithPreferredStart(DateOnly date)
    {
        _preferredStart = date;
        return this;
    }

    public CourseRegistration Build()
    {
        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart
        );
    }
}