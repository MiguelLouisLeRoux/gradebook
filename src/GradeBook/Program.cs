using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           var book = new Book("Pete's Grade Book");
           book.AddGrade(66.32);
           book.AddGrade(76.35);
           book.AddGrade(84.58);
           var stats = book.GetStatistics();

           Console.WriteLine($"The lowest grade is: {stats.Low}");
           Console.WriteLine($"The highest grade is: {stats.High}");
           Console.WriteLine($"The average grade is: {stats.Average:N2}");
        }
    }
}
