using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program!");

            GradeBook book = new ThrowAwayGradeBook();
            //book.NameChanged += OnNameChanged;

            //try
            //{
            //    Console.WriteLine("Enter a name");
            //    book.Name = Console.ReadLine();
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (NullReferenceException)
            //{
            //    Console.WriteLine("Something went wrong");
            //}
            book.AddGrade(91f);
            book.AddGrade(89.5f);
            //book.WriteGrade(Console.Out);
            //book.Name = "Scott's Grade Book";

            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrade(outputFile);
            }

            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Gradde", stats.LowestGrade);
            //Console.WriteLine(book.Name);
            WriteResult(stats.Description,stats.LetterGrade);



           




            Console.ReadLine();
            
            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;
            //g1.Name = "Scott";
            //Console.WriteLine(g2.Name);

        }
        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}

        public static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
        public static void WriteResult(string description, double number)
        {
            Console.WriteLine($"{description}: {number}");
        }
        public static void WriteResult(string description, params double[] number)
        {
            foreach (var item in number)
            {
                Console.WriteLine($"{description}: {item}");
            }
        }

        public static void WriteAsBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            foreach (byte b in bytes)
            {
                Console.WriteLine("{0:X2}", b);
            }
        }
    }
}
