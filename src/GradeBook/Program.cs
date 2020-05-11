using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        
        //Main - entry point of C# app
        static void Main(string[] args)
        {
            var book = new DiskBook("Olga's Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.AddGrade(90.5);
            book.AddGrade(89.1);
            book.AddGrade(77.5);

            EnterGrades(book);
            // .. 
            var stats = book.GetStats();
            Console.WriteLine($"For the book Named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.letter}");
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade. Entewr 'q' to Exit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    inMemoryBook.AddGrade(grade);
                    //..
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade Was Added");
        }
    }
}