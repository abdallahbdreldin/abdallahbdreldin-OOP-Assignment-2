namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentMember student = new StudentMember(1, "Mona Student", "0100000001");
            PremiumMember premium = new PremiumMember(2, "Omar Premium", "0100000002", 10m);
            Book book = new Book("B-100", "Clean Code", 2m);
            DVD dvd = new DVD("D-200", "Library Documentary", 2m);
            Magazine magazine = new Magazine("M-300", "Science Weekly", 2m);

            Console.WriteLine("Rejected operations:");
            TryInvalidIdentity();
            book.Withdraw();
            TryBorrowWithdrawnItem(student, book);
            book.Restore();

            Loan studentLoan = student.BorrowItem(book, new DateTime(2026, 9, 1));
            TryBorrowAlreadyLoanedItem(premium, book);

            student.BorrowItem(new Book("B-101", "Second", 1m), new DateTime(2026, 9, 1));
            student.BorrowItem(new Book("B-102", "Third", 1m), new DateTime(2026, 9, 1));
            TryStudentFourthLoan(student);

            Librarian librarian = new Librarian(10, "Laila Librarian", "0100000010", new DateTime(2020, 1, 1), 6000m);
            HeadLibrarian headLibrarian = new HeadLibrarian(11, "Hassan Head", "0100000011", new DateTime(2018, 1, 1), 8000m);
            Shelver shelver = new Shelver(12, "Salma Shelver", "0100000012", new DateTime(2023, 1, 1), 5000m, "Fiction");
            TryInvalidRaise(librarian);
            TryInvalidFee(headLibrarian, magazine);

            Console.WriteLine();
            Console.WriteLine("Staff monthly pay:");
            List<Staff> staffMembers = new List<Staff>();
            staffMembers.Add(librarian);
            staffMembers.Add(headLibrarian);
            staffMembers.Add(shelver);

            foreach (Staff staffMember in staffMembers)
            {
                Console.WriteLine(staffMember.FullName + ": " + staffMember.GetMonthlyPay());
            }

            Console.WriteLine();
            Console.WriteLine("Item loan periods and daily late fees:");
            List<LibraryItem> items = new List<LibraryItem>();
            items.Add(book);
            items.Add(dvd);
            items.Add(magazine);

            foreach (LibraryItem libraryItem in items)
            {
                Console.WriteLine(libraryItem.Title + ": " + libraryItem.GetLoanPeriodDays() + " days, fee " + libraryItem.GetDailyLateFee());
            }

            Loan premiumLoan = premium.BorrowItem(dvd, new DateTime(2026, 9, 1));
            premiumLoan.MarkReturned(new DateTime(2026, 9, 13));

            Console.WriteLine();
            Console.WriteLine("Premium DVD return:");
            Console.WriteLine("Due date: " + premiumLoan.DueDate.ToShortDateString());
            Console.WriteLine("Late fee: " + premiumLoan.LateFee);
            Console.WriteLine("Reading points: " + premium.ReadingPoints);

            TryReturnTwice(premiumLoan);
            TryMarkReturnedLoanLost(premiumLoan);
            TryInvalidReturnDate(premium);

            Console.WriteLine();
            Console.WriteLine("Original student loan status: " + studentLoan.Status);
        }

        private static void TryInvalidIdentity()
        {
            try
            {
                new StudentMember(0, "", "");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryBorrowWithdrawnItem(Member member, LibraryItem item)
        {
            try
            {
                member.BorrowItem(item, new DateTime(2026, 9, 1));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryBorrowAlreadyLoanedItem(Member member, LibraryItem item)
        {
            try
            {
                member.BorrowItem(item, new DateTime(2026, 9, 2));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryStudentFourthLoan(StudentMember student)
        {
            try
            {
                student.BorrowItem(new Book("B-103", "Fourth", 1m), new DateTime(2026, 9, 1));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryInvalidRaise(Staff staff)
        {
            try
            {
                staff.GiveRaise(0m);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryInvalidFee(HeadLibrarian headLibrarian, LibraryItem item)
        {
            try
            {
                headLibrarian.ChangeLateFee(item, 0m);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryReturnTwice(Loan loan)
        {
            try
            {
                loan.MarkReturned(new DateTime(2026, 9, 14));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryMarkReturnedLoanLost(Loan loan)
        {
            try
            {
                loan.MarkLost();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void TryInvalidReturnDate(PremiumMember member)
        {
            Loan loan = member.BorrowItem(new Magazine("M-400", "Dates", 1m), new DateTime(2026, 9, 10));

            try
            {
                loan.MarkReturned(new DateTime(2026, 9, 9));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
