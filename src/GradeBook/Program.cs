using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new InMemoryBook("Pete's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book name: {book.Name}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");


        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit:");

                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var theGrade = double.Parse(input);
                    book.AddGrade(theGrade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
        
    }
}
