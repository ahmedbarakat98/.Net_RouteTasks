//Part 01: Theoretical Questions 

#region Q1
//Q1: What is an interface in C#?
//An interface in C# is a contract that defines what members a class must implement,
//without depending on a specific concrete implementation.
//Benefits of using interfaces :
//1- Loose Coupling : The code depends on an abstraction instead of a specific class.
//2- Easy Testing : Interfaces make unit testing easier because we can replace real classes with fake or mock classes.
//3- Flexibility and Replaceability :We can change the implementation without changing the code that uses it.

#endregion
#region Q2
//Q2: a) What is the problem with this design? Both interfaces contain a method with the same name and same signature
//The problem is that we cannot give each interface a different behavior.
//Calling Greet() as English or Arabic will run the same method.
//b) How would you fix it? We can fix it using explicit interface implementation.
//class Translator : IEnglishSpeaker, IArabicSpeaker
//{void IEnglishSpeaker.Greet(){Console.WriteLine("Hello");}
//void IArabicSpeaker.Greet(){Console.WriteLine("Ahlan");}}
//c) Can you call Greet() directly on a Translator object?
//After applying explicit interface implementation, this will not work:
//Translator translator = new Translator();
//translator.Greet(); // Error
//Because the Greet() methods are implemented explicitly, they are not public methods of the Translator class directly.
//To call each version, we must use the interface type.
#endregion

#region Q3
//Q3: Shallow Copy vs Deep Copy:
//Shallow Copy
//A shallow copy creates a new object, but it copies the fields as they are.
//For value-type fields, values are copied.
//For reference-type fields, only the reference is copied, not the actual object.
// Deep Copy
//A deep copy creates a new object and also creates new instances of any reference-type fields.
#endregion

#region Q4
//Q4: The output :
//Dev - Testing
//QA - Testing
//Explanation :This line creates a shallow copy:
//var e2 = e1.ShallowCopy();
//So e1 and e2 are two different Employee objects.
//But their Dept field points to the same Department object.
//This line only changes the Title of e2:
//e2.Title = "QA";
// so : e1.Title = "Dev" , e2.Title = "QA"
//But this line changes the shared department object:
//e2.Dept.Name = "Testing";
//Since both employees share the same department, both now see: Dept.Name as "Testing".
//Therefore the final output is:
//Dev - Testing
//QA - Testing
#endregion

//Part 02 : Practical (Extending the Movie Ticket Booking System)

#region Answer

//using System.Globalization;

//interface IPrintable
//{
//    void Print();
//}

//interface IBookable
//{
//    bool IsBooked { get; }
//    bool Book();
//    bool Cancel();
//}

//abstract class Ticket(string movieName, decimal price) : IPrintable, IBookable, ICloneable
//{
//    private static int _nextTicketNumber = 1;

//    public int TicketNumber { get; private set; } = _nextTicketNumber++;
//    public string MovieName { get; set; } = movieName;
//    public decimal Price { get; set; } = price;
//    public bool IsBooked { get; private set; }

//    public bool Book()
//    {
//        if (IsBooked)
//            return false;

//        IsBooked = true;
//        return true;
//    }

//    public bool Cancel()
//    {
//        if (!IsBooked)
//            return false;

//        IsBooked = false;
//        return true;
//    }

//    protected decimal CalculatePriceAfterTax()
//    {
//        return Price * 1.14m;
//    }

//    protected string FormatMoney(decimal value)
//    {
//        return value.ToString("0.##", CultureInfo.InvariantCulture);
//    }

//    protected string BookedText()
//    {
//        return IsBooked ? "Yes" : "No";
//    }

//    protected Ticket CloneBase()
//    {
//        Ticket clone = (Ticket)this.MemberwiseClone();

//        clone.TicketNumber = _nextTicketNumber++;

//        clone.IsBooked = false;

//        return clone;
//    }

//    public abstract void Print();

//    public abstract object Clone();
//}

//class StandardTicket : Ticket
//{
//    public string SeatNumber { get; set; }

//    public StandardTicket(string movieName, decimal price, string seatNumber)
//        : base(movieName, price)
//    {
//        SeatNumber = seatNumber;
//    }

//    public override void Print()
//    {
//        Console.WriteLine(
//            $"[Ticket #{TicketNumber}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {FormatMoney(Price)} | After Tax: {FormatMoney(CalculatePriceAfterTax())} | Booked: {BookedText()}"
//        );
//    }

//    public override object Clone()
//    {
//        return (StandardTicket)CloneBase();
//    }
//}

//class VipDetails
//{
//    public bool HasLoungeAccess { get; set; }
//    public decimal ServiceFee { get; set; }
//}

//class VIPTicket : Ticket
//{
//    public VipDetails Details { get; set; }

//    public VIPTicket(string movieName, decimal price, bool hasLoungeAccess, decimal serviceFee)
//        : base(movieName, price)
//    {
//        Details = new VipDetails
//        {
//            HasLoungeAccess = hasLoungeAccess,
//            ServiceFee = serviceFee
//        };
//    }

//    public override void Print()
//    {
//        string loungeText = Details.HasLoungeAccess ? "Yes" : "No";

//        Console.WriteLine(
//            $"[Ticket #{TicketNumber}] {MovieName} | VIP | Lounge: {loungeText} | Fee: {FormatMoney(Details.ServiceFee)} | Price: {FormatMoney(Price)} | After Tax: {FormatMoney(CalculatePriceAfterTax())} | Booked: {BookedText()}"
//        );
//    }

//    public override object Clone()
//    {
//        VIPTicket clone = (VIPTicket)CloneBase();

//        // Deep copy for the reference-type field.
//        clone.Details = new VipDetails
//        {
//            HasLoungeAccess = this.Details.HasLoungeAccess,
//            ServiceFee = this.Details.ServiceFee
//        };

//        return clone;
//    }
//}

//class IMAXTicket : Ticket
//{
//    public bool Is3D { get; set; }

//    public IMAXTicket(string movieName, decimal price, bool is3D)
//        : base(movieName, price)
//    {
//        Is3D = is3D;
//    }

//    public override void Print()
//    {
//        string is3DText = Is3D ? "Yes" : "No";

//        Console.WriteLine(
//            $"[Ticket #{TicketNumber}] {MovieName} | IMAX | 3D: {is3DText} | Price: {FormatMoney(Price)} | After Tax: {FormatMoney(CalculatePriceAfterTax())} | Booked: {BookedText()}"
//        );
//    }

//    public override object Clone()
//    {
//        return (IMAXTicket)CloneBase();
//    }
//}

//class Cinema
//{
//    private readonly List<IPrintable> _tickets = new List<IPrintable>();

//    public void Open()
//    {
//        Console.WriteLine("=== Cinema Opened ===");
//    }

//    public void Close()
//    {
//        Console.WriteLine();
//        Console.WriteLine("=== Cinema Closed ===");
//    }

//    public void AddTicket(IPrintable ticket)
//    {
//        _tickets.Add(ticket);
//    }

//    public void PrintAllTickets()
//    {
//        foreach (IPrintable ticket in _tickets)
//        {
//            ticket.Print();
//        }
//    }
//}

//static class BookingHelper
//{
//    public static void PrintAll(IPrintable[] printables)
//    {
//        foreach (IPrintable printable in printables)
//        {
//            printable.Print();
//        }
//    }
//}

#endregion
#region Program.cs 

//using System;
//using System.Collections.Generic;
//using System.Globalization;

//class Program
//{
//    static void Main()
//    {
//        Cinema cinema = new Cinema();

//        cinema.Open();

//        StandardTicket standardTicket = new StandardTicket("Inception", 80, "A5");
//        VIPTicket vipTicket = new VIPTicket("Avengers", 200, true, 50);
//        IMAXTicket imaxTicket = new IMAXTicket("Dune", 130, true);

//        standardTicket.Book();
//        vipTicket.Book();
//        imaxTicket.Book();

//        cinema.AddTicket(standardTicket);
//        cinema.AddTicket(vipTicket);
//        cinema.AddTicket(imaxTicket);

//        Console.WriteLine();
//        Console.WriteLine("--- All Tickets ---");
//        cinema.PrintAllTickets();

//        Console.WriteLine();
//        Console.WriteLine("--- Clone Test ---");

//        VIPTicket clonedVipTicket = (VIPTicket)vipTicket.Clone();
//        clonedVipTicket.MovieName = "Interstellar";

//        Console.Write("Original : ");
//        vipTicket.Print();

//        Console.Write("Clone    : ");
//        clonedVipTicket.Print();

//        standardTicket.Cancel();

//        Console.WriteLine();
//        Console.WriteLine("--- After Cancellation ---");
//        standardTicket.Print();

//        Console.WriteLine();
//        Console.WriteLine("--- BookingHelper.PrintAll ---");

//        IPrintable[] printableTickets =
//        {
//            standardTicket,
//            vipTicket,
//            imaxTicket
//        };

//        BookingHelper.PrintAll(printableTickets);

//        cinema.Close();
//    }
//}
#endregion
