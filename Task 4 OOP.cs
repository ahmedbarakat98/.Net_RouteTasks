//Part 01 : Theoretical Questions

//Q1: What is the difference between static binding and dynamic binding? When does each one happen?
//A1:Static Binding Happens at compile time and The compiler decides which method will be called Used mainly with method overloading
//but Dynamic Binding Happens at runtime and The object type decides which method will be called

//Q2 :  What is the difference between method overloading and method overriding?
//A2 : Method Overloading Same method name, different parameters and Happens in the same class usually in Compile-time polymorphism
// but Method Overriding Same method name, same parameters Happens between parent and child classes in Happens between parent and child classes

//Q3 : What keywords are used for Method Overriding? What does each one mean ?
//A3 :  virtual : Used in the parent class to allow a method to be overridden.
// override : Used in the child class to override the parent method.

//Part 02 : Practical (Extending the Movie Ticket Booking System)

using System;

class Ticket
{
    private static int nextId = 1;

    public int TicketId { get; private set; }
    public string MovieName { get; set; }
    public decimal Price { get; private set; }

    public decimal PriceAfterTax
    {
        get { return Price * 1.14m; }
    }

    public Ticket(string movieName, decimal price)
    {
        TicketId = nextId++;
        MovieName = movieName;
        Price = price;
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }


    public void SetPrice(decimal basePrice, decimal multiplier)
    {
        Price = basePrice * multiplier;
    }



    public virtual void PrintTicket()
    {
        Console.WriteLine(
            $"Ticket #{TicketId} | {MovieName} | Price: {Price:0.##} EGP | After Tax: {PriceAfterTax:0.00} EGP"
        );
    }
}

class StandardTicket : Ticket
{
    public string SeatNumber { get; set; }

    public StandardTicket(string movieName, decimal price, string seatNumber)
        : base(movieName, price)
    {
        SeatNumber = seatNumber;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();
        Console.WriteLine($"  Seat: {SeatNumber}");
    }
}

class VIPTicket : Ticket
{
    public bool LoungeAccess { get; set; }
    public decimal ServiceFee { get; set; }

    public VIPTicket(string movieName, decimal price, bool loungeAccess, decimal serviceFee)
        : base(movieName, price)
    {
        LoungeAccess = loungeAccess;
        ServiceFee = serviceFee;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();

        string loungeText = LoungeAccess ? "Yes" : "No";

        Console.WriteLine($"  Lounge: {loungeText} | Service Fee: {ServiceFee:0.##} EGP");
    }
}

class IMAXTicket : Ticket
{
    public bool Imax { get; set; }

    public IMAXTicket(string movieName, decimal price, bool imax)
        : base(movieName, price)
    {
        Imax = imax;
    }

    public override void PrintTicket()
    {
        base.PrintTicket();

        string imaxText = Imax ? "Yes" : "No";

        Console.WriteLine($"  IMAX: {imaxText}");
    }
}

class Cinema
{
    private Ticket[] tickets;
    private int ticketCount;

    public Cinema(int capacity)
    {
        tickets = new Ticket[capacity];
        ticketCount = 0;
    }

    public void OpenCinema()
    {
        Console.WriteLine("========== Cinema Opened ==========");
        Console.WriteLine("Projector started.");
    }

    public void CloseCinema()
    {
        Console.WriteLine();
        Console.WriteLine("========== Cinema Closed ==========");
        Console.WriteLine("Projector stopped");
    }

    public void AddTicket(Ticket ticket)
    {
        if (ticketCount < tickets.Length)
        {
            tickets[ticketCount] = ticket;
            ticketCount++;
        }
        else
        {
            Console.WriteLine("Cinema ticket list is full.");
        }
    }

    public void PrintAllTickets()
    {
        for (int i = 0; i < ticketCount; i++)
        {
            tickets[i].PrintTicket();
        }
    }
}

class Program
{
    static void ProcessTicket(Ticket t)
    {
        t.PrintTicket();
    }

    static void Main(string[] args)
    {
        Cinema cinema = new Cinema(10);

        cinema.OpenCinema();

        StandardTicket standardTicket = new StandardTicket("Inception", 100m, "A-5");
        VIPTicket vipTicket = new VIPTicket("Avengers", 200m, true, 50m);
        IMAXTicket imaxTicket = new IMAXTicket("Dune", 180m, false);

        Console.WriteLine();
        Console.WriteLine("========== SetPrice Test ==========");

        Console.WriteLine("Setting price directly: 150");
        standardTicket.SetPrice(150m);

        Console.WriteLine("Setting price with multiplier: 100 x 1.5 = 150");
        standardTicket.SetPrice(100m, 1.5m);

        cinema.AddTicket(standardTicket);
        cinema.AddTicket(vipTicket);
        cinema.AddTicket(imaxTicket);

        Console.WriteLine();
        Console.WriteLine("========== All Tickets ==========");
        cinema.PrintAllTickets();

        Console.WriteLine();
        Console.WriteLine("========== Process Single Ticket ==========");
        ProcessTicket(vipTicket);

        cinema.CloseCinema();
    }
}
