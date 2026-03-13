// OOP assignment 1

//Part 1 : 

#region Q1
//A class is a reference type and  struct is a value type This means when you
//assign a class object to another variable, both variables refer to the same object
//When you assign a struct to another variable, a copy of the value is created

//Ex:
//using System;
//class PersonClass
//{
//    public string Name;
//}
//struct PersonStruct
//{
//    public string Name;
//}

//class Program
//{
//    static void Main()
//    {
//        // Class :
//        PersonClass p1 = new PersonClass();
//        p1.Name = "Ali";
//        PersonClass p2 = p1;
//        p2.Name = "Omar";
//        Console.WriteLine("Class p1.Name = " + p1.Name); // Omar
//        Console.WriteLine("Class p2.Name = " + p2.Name); // Omar

//        // Struct :
//        PersonStruct s1;
//        s1.Name = "Ali";
//        PersonStruct s2 = s1;
//        s2.Name = "Omar";
//        Console.WriteLine("Struct s1.Name = " + s1.Name); // Ali
//        Console.WriteLine("Struct s2.Name = " + s2.Name); // Omar
//    }
//}
#endregion

#region Q2

//In C#, access modifiers control where variables, methods, or classes can be accessed from.
//public : public member can be accessed from anywhere in the program.
//private :private member can only be accessed inside the same class.
//Ex :
//using System;
//class Student
//{
//    public string Name;
//    private int Age;
//    public void SetAge(int age)
//    {
//        Age = age;
//    }
//    public void ShowInfo()
//    {
//        Console.WriteLine("Name: " + Name);
//        Console.WriteLine("Age: " + Age);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Student s = new Student();

//        s.Name = "Ahmed";   // Allowed because Name is public
//        s.Age = 20;      // Error : Not allowed because Age is private

//        s.SetAge(20);       // Allowed through public method
//        s.ShowInfo();
//    }
//}
#endregion

#region Q3

//A class library in Visual Studio is a project that contains reusable classes,
//methods, and other code that can be used in other projects.
//Steps to create and use a class library


//1-Right-click on the main project and choose Add > Project Reference
//2-Select the class library project and click OK
//3-Import the library namespace using using
//4-Create objects from the library classes and use their methods

#endregion

#region Q4
//class library is a collection of reusable classes, methods, and other
//code components stored in a separate project or file.
//It does not run by itself like a console or Windows application.
//Instead, it is used by other applications.

//Why do we use class libraries?

//We use class libraries because they help us:
//1-Reuse code
//2-Write the code once and use it in many projects
//3-Organize the project
//4-Keep related code in one place
//5-Save time
//6-No need to rewrite the same functions again

//Example

//A company may create a class library for:
//login system - database functions - calculations - report generation
//Then multiple applications can use the same library instead of writing the same code again.

//Conclusion

//A class library is important because it makes software development faster,
//cleaner, and easier to maintain.
#endregion

//Part 2 :

namespace ConsoleApp2
{
    enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }
    struct SeatLocation
    {
        public char Row;
        public int Number;

        public SeatLocation(char Row , int Number) 
        {
            this.Row = Row;
            this.Number = Number;
        }
        public override string ToString()
        {
            return $"{Row}{Number}";
        }
    }
    class Ticket
    {
        public string MovieName;
        public TicketType Type;
        public SeatLocation Seat;
        private double Price;

        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }
        public double CalcTotal(double taxPercent)
        {
            double total = Price + (Price * taxPercent / 100.0);
            return total;
        }
        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= Price)
            {
                Price -= discountAmount
               discountAmount = 0;
            }
        }
        public void PrintTicket(double tax)
        {
            Console.WriteLine("===== Ticket Info =====");
            Console.WriteLine($"Movie Name : {MovieName}");
            Console.WriteLine($"Ticket Type: {Type}");
            Console.WriteLine($"Seat       : {Seat}");
            Console.WriteLine($"Price      : {Price}");
            Console.WriteLine($"Total ({tax}% tax) : {CalcTotal(tax)}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Movie Name: ");
            string movie = Console.ReadLine();

            Console.Write("Enter Ticket Type (0 = Standard , 1 = VIP , 2 = IMAX ): ");
            int typeInput = int.Parse(Console.ReadLine());
            TicketType type = (TicketType)typeInput; //explicit casting

            Console.Write("Enter Seat Row (A, B, C...): ");
            char row = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter Seat Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Amount: ");
            double discount = double.Parse(Console.ReadLine());

            //declare values
            SeatLocation seat = new SeatLocation(row, number);
            Ticket ticket = new Ticket(movie, type, seat, price);

            double tax = 14;

            Console.WriteLine();
            ticket.PrintTicket(tax);
            Console.WriteLine();
            Console.WriteLine("===== After Discount =====");
            Console.WriteLine($"Discount Before : {discount:F2}");

            ticket.ApplyDiscount(ref discount);

            Console.WriteLine($"Discount After  : {discount:F2}");

            ticket.PrintTicket(tax);

        }
    }
}