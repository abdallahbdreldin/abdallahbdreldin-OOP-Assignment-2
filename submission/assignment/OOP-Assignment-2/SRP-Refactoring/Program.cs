using System;
using SRPLap.WardBoard;
using SRPLap.CheckoutBasket;
using SRPLap.SupportTicket;
using SRPLap.LoanDesk;
using SRPLap.CourseEnrollmentDesk;
using SRPLap.KitchenTicket;
using SRPLap.SubscriptionBilling;
using SRPLap.WarehousePickList;
using SRPLap.GradeBook;
using SRPLap.AppointmentDesk;

namespace SRP_Refactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
            Console.WriteLine("=================================================");

            var ward = new WardBoard();
            var pager = new PagerLog();
            ward.AssignBed(1, "p-88");
            var patient = ward.Beds[1];
            var acuity = AcuityScorer.Score(130, 89);
            if (acuity >= 8) pager.AddCodeYellow(1);
            Console.WriteLine(HandOffNoteBuilder.Build(1, patient, acuity));
            Console.WriteLine(string.Join(" | ", pager.DrainPagerLog()));

            var basket = new CheckoutBasket();
            basket.AddLine("SKU-1", 40m, 2);
            basket.ApplyCoupon("SAVE10");
            basket.EnableGiftWrap();
            Console.WriteLine($"basket total={PricingCalculator.GrandTotal(basket)} auth={PaymentGateway.AuthorizePaymentStub("4242", basket)}");

            var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);
            var pd = new PriorityDetecter();
            pd.RecalculatePriorityFromText(ticket.Subject, ticket.Body);
            var idParts = ticket.Id.Split('-', StringSplitOptions.RemoveEmptyEntries);
            var numericId = 0;
            if (!int.TryParse(idParts.Length > 0 ? idParts[^1] : "0", out numericId)) numericId = 0;
            Console.WriteLine(PublicReply.DraftPublicReply(numericId, "Nora", pd.Priority, ticket.OpenedAt));

            var loan = new LoanDesk(60_000m, 640, 4, hasCollateral: false);
            Console.WriteLine(Letter.DecisionLetter("Omar", loan));

            var waitlist = new Waitlist();
            var course = new CourseEnrollmentDesk("SEF-101", capacity: 1, waitlist);
            Console.WriteLine(course.Register("a@mail.com"));
            Console.WriteLine(course.Register("b@mail.com"));
            Console.WriteLine(WelcomePacket.WelcomePacketMarkdown(course, waitlist, "b@mail.com", "Bea"));

            var kitchen = new KitchenTicket();
            kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
            Console.WriteLine(ThermalTicket.Build(kitchen, 42));

            var sub = new SubscriptionBilling();
            sub.RegisterFailedPayment();
            Console.WriteLine(DunningEmail.Generate(sub, "Sara", new DateOnly(2026, 9, 20)));

            var pick = new WarehousePickList();
            pick.AddNeed("BOLT", "A", 3, 10, 7);
            pick.AddNeed("NUT", "B", 1, 5, 5);
            Console.WriteLine(PickerScript.Generate(pick));

            var grades = new GradeBook();
            grades.Record("s1", 92);
            grades.Record("s1", 88);
            Console.WriteLine(RegisterDocument.TranscriptPlain(grades, "s1", "Ali"));

            var appt = new AppointmentDesk(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
            var slot = appt.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
            if (slot is null) throw new InvalidOperationException("no slot");
            appt.TryBook(slot.Value);
            Console.WriteLine(SmsReminder.Send(appt, slot.Value, "0100"));

            Console.WriteLine("Done.");
        }
    }
}
