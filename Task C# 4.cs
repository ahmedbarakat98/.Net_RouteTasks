using ConsoleApp2;
using System;

enum DayOfWeek
{
    Saturday = 1,
    Sunday = 2,
    Monday = 3,
    Tuesday = 4,
    Wednesday = 5,
    Thursday = 6,
    Friday = 7
}

enum Grade
{
    A, B, C, D, F
}


class Program
{
    static double Add(double a, double b)
    {
        return a + b;
    }
    static double Subtract(double a, double b)
    {
        return a - b;
    }
    static double Multiply(double a, double b)
    {
        return a * b;
    }
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return double.NaN;
        }

        return a / b;
    }
    static void CalculateCircle(double radius, out double area, out double circumference)
    {
        area = Math.PI * radius * radius;
        circumference = 2 * Math.PI * radius;
    }
    static Grade GetGrade(int score)
    {
        if (score >= 90)
            return Grade.A;
        else if (score >= 80)
            return Grade.B;
        else if (score >= 70)
            return Grade.C;
        else if (score >= 60)
            return Grade.D;
        else
            return Grade.F;
    }
    static double CalculateAverage(int[] scores)
    {
        int sum = 0;

        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }

        return (double)sum / scores.Length;
    }
    static void GetMinMax(int[] scores, out int min, out int max)
    {
        min = scores[0];
        max = scores[0];

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] < min)
                min = scores[i];

            if (scores[i] > max)
                max = scores[i];
        }
    }
    static void Main(string[] args)
    {
        //Enum
        #region Q1

        //Console.Write("Enter a day number (1–7): ");
        //int dayNumber = Convert.ToInt32(Console.ReadLine());

        //if (dayNumber < 0 || dayNumber > 6)
        //{
        //    Console.WriteLine("Invalid number. Please enter a number between 0 and 6.");
        //    return;
        //}

        //DayOfWeek day = (DayOfWeek)dayNumber;

        //Console.WriteLine("Day name: " + day);

        //switch (day)
        //{
        //    case DayOfWeek.Saturday:
        //    case DayOfWeek.Sunday:
        //        Console.WriteLine("Weekend");
        //        break;

        //    default:
        //        Console.WriteLine("Workday");
        //        break;
        //}

        #endregion

        //Arrays
        #region Q1
        //Console.Write("Enter the size of the array: ");
        //int size = Convert.ToInt32(Console.ReadLine());

        //int[] numbers = new int[size];


        //for (int i = 0; i < size; i++)
        //{
        //    Console.Write("Enter element " + (i + 1) + ": ");
        //    numbers[i] = Convert.ToInt32(Console.ReadLine());
        //}

        //int sum = 0;
        //int max = numbers[0];
        //int min = numbers[0];

        //for (int i = 0; i < size; i++)
        //{
        //    sum += numbers[i];

        //    if (numbers[i] > max)
        //        max = numbers[i];

        //    if (numbers[i] < min)
        //        min = numbers[i];
        //}

        //double average = (double)sum / size;


        //Console.WriteLine("\nSum = " + sum);
        //Console.WriteLine("Average = " + average);
        //Console.WriteLine("Maximum = " + max);
        //Console.WriteLine("Minimum = " + min);

        //Console.WriteLine("Array in reverse order:");
        //for (int i = size - 1; i >= 0; i--)
        //{
        //    Console.Write(numbers[i] + " ");
        //}


        #endregion

        #region Q2
        //int[,] grades = new int[3, 4];
        //double totalSum = 0;

        //for (int i = 0; i < 3; i++)
        //{
        //    Console.WriteLine("Enter grades for Student " + (i + 1));

        //    for (int j = 0; j < 4; j++)
        //    {
        //        Console.Write("Subject " + (j + 1) + ": ");
        //        grades[i, j] = Convert.ToInt32(Console.ReadLine());
        //    }
        //}

        //Console.WriteLine();

        //for (int i = 0; i < 3; i++)
        //{
        //    int studentSum = 0;

        //    for (int j = 0; j < 4; j++)
        //    {
        //        studentSum += grades[i, j];
        //        totalSum += grades[i, j];
        //    }

        //    double studentAverage = studentSum / 4.0;
        //    Console.WriteLine("Average grade for Student " + (i + 1) + " = " + studentAverage);
        //}

        //double classAverage = totalSum / (3 * 4);

        //Console.WriteLine("\nOverall class average = " + classAverage);
        #endregion

        //Methods
        #region Q1

        //Console.Write("Enter first number: ");
        //double num1 = Convert.ToDouble(Console.ReadLine());

        //Console.Write("Enter second number: ");
        //double num2 = Convert.ToDouble(Console.ReadLine());

        //Console.Write("Enter operation (+, -, *, /): ");
        //char op = Convert.ToChar(Console.ReadLine());

        //double result = 0;

        //switch (op)
        //{
        //    case '+':
        //        result = Add(num1, num2);
        //        break;

        //    case '-':
        //        result = Subtract(num1, num2);
        //        break;

        //    case '*':
        //        result = Multiply(num1, num2);
        //        break;

        //    case '/':
        //        result = Divide(num1, num2);
        //        break;

        //    default:
        //        Console.WriteLine("Invalid operation.");
        //        return;
        //}

        //Console.WriteLine("Result = " + result);
        #endregion

        #region Q2

        //Console.Write("Enter the radius: ");
        //double radius = Convert.ToDouble(Console.ReadLine());

        //double area, circumference;

        //CalculateCircle(radius, out area, out circumference);

        //Console.WriteLine("Area = " + area);
        //Console.WriteLine("Circumference = " + circumference);

        #endregion

        //Console Application project

        #region Project
        int[] scores = new int[5];

        for (int i = 0; i < scores.Length; i++)
        {
            Console.Write("Enter score for student " + (i + 1) + ": ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("---- Report ----");

        for (int i = 0; i < scores.Length; i++)
        {
            Grade grade = GetGrade(scores[i]);
            Console.WriteLine("Student " + (i + 1) + " Score = " + scores[i] + " Grade = " + grade);
        }

        double average = CalculateAverage(scores);

        int min, max;
        GetMinMax(scores, out min, out max);

        Console.WriteLine("\nClass Average = " + average);
        Console.WriteLine("Minimum Score = " + min);
        Console.WriteLine("Maximum Score = " + max);
        #endregion

    }
}
