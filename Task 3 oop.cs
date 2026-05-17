using System;
using System.Threading.Channels;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema("Galaxy Cinema");
            cinema.OpenCinema();


            StandardTicket standardTicket = new StandardTicket("A-5", "Zaki Chan", 500);
            VIPTicket vipTicket = new VIPTicket(true, 50, "El Nazer", 700);

            cinema.AddTicket(standardTicket);
            cinema.AddTicket(vipTicket);
            cinema.PrintAllTickets();
            cinema.CloseCinema();

        }
    }


    //Part 01 : Theoretical Questions


    //Q1: Identify the type of relationship in each scenario below
    //(Inheritance, Association, Aggregation, Composition, or Dependency):

    //a) A University has Departments. If the university is closed, the departments no longer exist . composition 

    //b) A Driver uses a Car. association 

    //c) A Dog is an Animal. inheritance

    //d) A Team has Players. If the team is deleted, the players still exist. aggregation

    //e) A method receives a Logger as a parameter and calls it inside the method only. dependency



    //Q2 : Answer the following questions about access modifiers and sealed:

    // a) yes . it can access in the same project defferent assembly , but you cant access
    // it through an object instance from outside?

    //b) protected internal Means: accessible from the same assembly OR from derived classes in any assembly
    //private protected Means: accessible only from derived classes inside the same assembly.

    //c) sealed class cannot be inherited ans sealed method cannot be overridden in derived classes.

    //Part 02 : Practical (Extending the Movie Ticket Booking System)

    internal class Ticket
    {
        private string _movieName;
        private decimal _price;
        private readonly int _ticketId;
        private readonly int _totalTickets;
        private static int _nextTicketId = 1;

        public Ticket(string movieName, decimal price)
        {
            _movieName = movieName;
            _price = price;
            _ticketId = _nextTicketId++;
            _totalTickets = _ticketId - 1;
        }

        public int TicketId
        {
            get { return _ticketId; }
        }

        public decimal Price { get { return _price; } }
        public string MovieName { get { return _movieName; } }

        public decimal PriceAfterTax
        {
            get { return _price * 1.14m; }
        }

        public int GetTotalTickets() { return _totalTickets; }

        public override string ToString() => $"Ticket #{_ticketId} | {_movieName} | Price: {_price} EGP | {PriceAfterTax} EGP |";
    }
    internal class StandardTicket : Ticket
    {
        private string _seatNumber;

        public string SeatNumber { get { return _seatNumber; } }
        public StandardTicket(string seatNumber, string movieName, decimal price) : base(movieName, price)
        {
            _seatNumber = seatNumber;
        }

        public override string ToString() => $" {base.ToString()} Seat Number is : {_seatNumber}";

    }
    internal class VIPTicket : Ticket
    {
        private bool _loungeAccess;
        private decimal _serviceFee = 50;

        public VIPTicket(bool loungeAccess, decimal serviceFee, string movieName, decimal price) : base(movieName, price)
        {
            _loungeAccess = loungeAccess;
            _serviceFee = serviceFee;
        }

        public override string ToString() => $" {base.ToString()} Lounge: {(_loungeAccess ? "Yes" : "No")} | Service Fee: {_serviceFee} EGP";
    }
    internal class IMAXTicket : Ticket
    {
        private bool Is3D;
        private decimal _imaxPrice = 30;

        public IMAXTicket(bool is3D, string movieName, decimal price) : base(movieName, price)
        {
            Is3D = is3D;
        }

        public override string ToString() => $" {base.ToString()} 3D: {(Is3D ? "Yes" : "No")} | IMAX Price: {_imaxPrice + base.Price} EGP";
    }
    internal class Projector
    {
        public void Start()
        {
            Console.WriteLine("Projector started.");
        }

        public void Stop()
        {
            Console.WriteLine("Projector stopped.");
        }
    }
    internal class Cinema
    {
        private string _cinemaName;
        private Projector _projector;
        private Ticket[] _tickets;

        public string CinemaName
        {
            get { return _cinemaName; }
        }

        public Cinema(string cinemaName)
        {
            _cinemaName = cinemaName;
            _projector = new Projector();
            _tickets = new Ticket[20];
        }

        public void AddTicket(Ticket t)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == null)
                {
                    _tickets[i] = t;
                    Console.WriteLine("Ticket added successfully.");
                    return;
                }
            }

            Console.WriteLine("Cinema is full. Cannot add more tickets.");
        }

        public void PrintAllTickets()
        {
            Console.WriteLine($"Tickets for Cinema: {_cinemaName}");
            Console.WriteLine("--------------------------------");

            bool hasTickets = false;

            for (int i = 0; i < 20; i++)
            {
                if (_tickets[i] != null)
                {
                    Console.WriteLine(_tickets[i]);
                    hasTickets = true;
                }
            }

            if (!hasTickets)
            {
                Console.WriteLine("No tickets available.");
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            _projector.Start();
        }

        public void CloseCinema()
        {
            _projector.Stop();
            Console.WriteLine("========== Cinema Closed ==========");
        }

    }
    internal class CinemaName
    {
        private string _cinemaName;
        private Projector _projector;
        private Ticket[] _tickets;

        public string CName => _cinemaName;

        public void AddTicket(Ticket t)
        {
            for (int i = 0; i < 20; i++)
            {
                if (_tickets[i] == null)
                {
                    _tickets[i] = t;
                    Console.WriteLine("Ticket added successfully.");
                    return;
                }
            }

            Console.WriteLine("Cinema is full. Cannot add more tickets.");
        }
    }
}