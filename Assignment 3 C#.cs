// assignment C#  3

#region Q1

// A junior developer wrote this code to build a comma-separated list of 5,000 product IDs:

//using System.Text;

//string productList = "";

//for (int i = 1; i <= 5000; i++)
//{
//    productList += "prod-"+ i+ ",";
//}
//Console.WriteLine(productList);

// A : in every time we concatenate a string, a new string is created in memory.
// This can lead to performance issues,especiall
// y when dealing with large strings or many concatenations.

// B : rewrite the code using StringBuilder to improve performance:

//StringBuilder productListBuilder = new StringBuilder();

//for (int i = 1; i <= 5000; i++)
//{
//    productListBuilder.Append("prod-").Append(i).Append(",");
//}

//productList = productListBuilder.ToString();
//Console.WriteLine(productList);

#endregion

#region Q2

// Ticket Pricing System :
//int dayOfTheWeek = 7; // 6: Fri, 7: Sat
//int age = 28;
//bool haveStudentID = true;
//int price = 0;

//if (age < 5)
//{
//    price = 0;
//    Console.WriteLine("Free entry.");
//    Console.WriteLine(price);
//    return;
//}

//if (age < 12)
//{
//    price = 30;
//}
//else if (age < 59)
//{
//    price = 50;
//}
//else
//{
//    price = 25;
//}

//// Weekend surcharge
//if (dayOfTheWeek == 6 || dayOfTheWeek == 7)
//{
//    price += 10;
//    Console.WriteLine("Weekend pricing applies.");
//}

//// Student discount 20%
//if (haveStudentID)
//{
//    price -= price / 5;
//    Console.WriteLine("Student pricing applies.");
//}
//else
//{
//    Console.WriteLine("Regular pricing applies.");
//}

//Console.WriteLine($"Final price: {price}");



#endregion

#region Q3

// convert to Switch Statement

//string fileExtension = ".pdf";
//string fileType;

//switch (fileExtension)
//{
//    case ".pdf":
//        fileType = "PDF Document";
//        break;

//    case ".doc":
//    case ".docx":
//        fileType = "Word Document";
//        break;

//    case ".xls":
//    case ".xlsx":
//        fileType = "Excel Spreadsheet";
//        break;

//    case ".jpg":
//    case ".png":
//    case ".gif":
//        fileType = "Image File";
//        break;

//    default:
//        fileType = "Unknown File Type";
//        break;
//}

//Console.WriteLine(fileType);

#endregion

#region Q4

// Ternary Operator :

//int temperature = 35;

//string weatherAdvice =
//    temperature < 0 ? "Freezing! Stay indoors." :
//    temperature < 15 ? "Cold. Wear a jacket." :
//    temperature < 25 ? "Pleasant weather." :
//    temperature < 35 ? "Warm. Stay hydrated." :
//                       "Hot! Avoid sun exposure.";

//Console.WriteLine(weatherAdvice);

// answer : yes , the ternary version more readable and i will choose ternary

#endregion

#region Q5

//using System;

//class Program
//{
//    static void Main()
//    {
//        string password;
//        int attempts = 0;
//        int maxAttempts = 5;

//        bool isValid;

//        do
//        {
//            Console.Write("Enter password: ");
//            password = Console.ReadLine();

//            attempts++;

//            bool hasMinLength = password.Length >= 8;
//            bool hasUppercase = false;
//            bool hasDigit = false;
//            bool hasSpace = false;

//            foreach (char c in password)
//            {
//                if (char.IsUpper(c))
//                    hasUppercase = true;

//                if (char.IsDigit(c))
//                    hasDigit = true;

//                if (char.IsWhiteSpace(c))
//                    hasSpace = true;
//            }

//            isValid = hasMinLength && hasUppercase && hasDigit && !hasSpace;

//            if (isValid)
//            {
//                Console.WriteLine("Password accepted!");
//                break;
//            }


//            Console.WriteLine("Invalid password. Violations:");

//            if (!hasMinLength)
//                Console.WriteLine("- Must be at least 8 characters.");

//            if (!hasUppercase)
//                Console.WriteLine("- Must contain at least one uppercase letter.");

//            if (!hasDigit)
//                Console.WriteLine("- Must contain at least one digit.");

//            if (hasSpace)
//                Console.WriteLine("- Must not contain spaces.");


//            if (attempts >= maxAttempts)
//            {
//                Console.WriteLine("Account locked.");
//                return;
//            }

//            Console.WriteLine($"Attempts remaining: {maxAttempts - attempts}");
//            Console.WriteLine();

//        } while (!isValid);
//    }
//}

#endregion

#region Q6

using System;
using System.Collections.Generic;

int[] scores = { 85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48 };

List<int> LowScores = new List<int>();

//A

for (int i = 0; i < scores.Length; i++)
{
    if (scores[i] < 50)
    {
        LowScores.Add(scores[i]);
    }
}

//B

for (int i = 0; i < scores.Length; i++)
{
    if (scores[i] > 90)
    {
       Console.WriteLine(scores[i]);
        return;
    }
}

//C

int sum = 0;
int count = 0;

for (int i = 0; i < scores.Length; i++)
{
    if (scores[i] >= 40)
    {
        sum += scores[i];
        count++;        
    }

}

int avg = sum / count;
Console.WriteLine(avg);

// D

int countA = 0;
int countB = 0;
int countC = 0;
int countD = 0;
int countF = 0;

foreach (int score in scores)
{
    if (score >= 90 && score <= 100)
        countA++;
    else if (score >= 80 && score <= 89)
        countB++;
    else if (score >= 70 && score <= 79)
        countC++;
    else if (score >= 60 && score <= 69)
        countD++;
    else
        countF++;
}


#endregion