using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace A1_PartB
{
    internal class Program
    {
        private static readonly string BaseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Words Files", "random");
        static void Main(string[] args)
        {
            ArrayDS arrayDS = new ArrayDS();


            int opt = 0;

            // While true loop to keep program running until valid input is entered.
            while (true)
            {
                opt = DisplayMenu();

                if (opt >= 1 && opt <= 12)
                {
                    MenuOutput(opt, arrayDS);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1-12.");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

        static void InsertOp(string filename, ArrayDS arrayDS)
        {
            String[] fileAdd = ReadFile(filename);
            foreach (String line in fileAdd)
            {
                if (!line.StartsWith("#"))
                {
                    string wordAdd = line;
                    int wordLen = wordAdd.Length;
                    arrayDS.Add(wordAdd, wordLen);
                }
            }
        }
        static String[] ReadFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file path");
                return new string[0]; // Return an empty array in case of an error
            }
        }

        // displaying menu
        static int DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=== File Menu ===");
            Console.WriteLine();
            Console.WriteLine("[1] - 1000-words.txt");
            Console.WriteLine("[2] - 5000-words.txt");
            Console.WriteLine("[3] - 10000-words.txt");
            Console.WriteLine("[4] - 15000-words.txt");
            Console.WriteLine("[5] - 20000-words.txt");
            Console.WriteLine("[6] - 25000-words.txt");
            Console.WriteLine("[7] - 30000-words.txt");
            Console.WriteLine("[8] - 35000-words.txt");
            Console.WriteLine("[9] - 40000-words.txt");
            Console.WriteLine("[10] - 45000-words.txt");
            Console.WriteLine("[11] - 50000-words.txt");
            Console.WriteLine("[12] - Exit");
            Console.WriteLine();
            Console.WriteLine("Enter Option: ");

            int option;
            //assigning value to the input
            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 12)
            {
                return option;
            }
            else
            {
                return 0;
            }
        }

        //Menuoutput for when a file is selected
        static void MenuOutput(int option, ArrayDS arrayDS)
        {
            string filename = string.Empty;

            switch (option)
            {
                case 1:
                    Console.WriteLine("1000-Words selected.");
                    filename = @"1000-words.txt";
                    break;
                case 2:
                    Console.WriteLine("5000-Words selected.");
                    filename = @"5000-words.txt";
                    break;
                case 3:
                    Console.WriteLine("10000-Words selected.");
                    filename = @"10000-words.txt";
                    break;
                case 4:
                    Console.WriteLine("15000-Words selected.");
                    filename = @"15000-words.txt";
                    break;
                case 5:
                    Console.WriteLine("20000-Words selected.");
                    filename = @"20000-words.txt";
                    break;
                case 6:
                    Console.WriteLine("25000-Words selected.");
                    filename = @"25000-words.txt";
                    break;
                case 7:
                    Console.WriteLine("30000-Words selected.");
                    filename = @"30000-words.txt";
                    break;
                case 8:
                    Console.WriteLine("35000-Words selected.");
                    filename = @"35000-words.txt";
                    break;
                case 9:
                    Console.WriteLine("40000-Words selected.");
                    filename = @"40000-words.txt";
                    break;
                case 10:
                    Console.WriteLine("45000-Words selected.");
                    filename = @"45000-words.txt";
                    break;
                case 11:
                    Console.WriteLine("50000-Words selected.");
                    filename = @"50000-words.txt";
                    break;
                case 12:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
            }
            if (!string.IsNullOrEmpty(filename))
            {
                //file path for the inputed file number
                string pathFull = Path.Combine(BaseDirectory, filename);
                SubMenu(pathFull);
            }
        }

        //method to display sub menu
        static int DisplaySubMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Sub Menu Options ===");
            Console.WriteLine();
            Console.WriteLine("[1] - Print Array");
            Console.WriteLine("[2] - Selection Sort");
            Console.WriteLine("[3] - Merge Sort");
            Console.WriteLine("[4] - Stopwatch Methods");
            Console.WriteLine("[5] - Back");
            Console.WriteLine();
            Console.WriteLine("Enter option: ");

            int option;
 
            //making a validation method that will return the option selected and if it is not valid it will return 0
            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4)
            {
                return option;
            }
            else
            {
                return 0;
            }
        }

        //method for submenu input
        static void SubMenu(string filename)
        {
            int option;
            ArrayDS arrayDS = new ArrayDS();
            
            //call in sub menu input
            InsertOp(filename, arrayDS);

            do
            {
                option = DisplaySubMenu();
                switch (option)
                {
                    case 1:
                        //calls ToPrint() method
                        Console.Clear();
                        Console.WriteLine("=== Print ===");
                        Console.WriteLine(arrayDS.ToPrint());
                        break;
                    case 2:
                        //calls SelectionSort() method
                        Console.Clear();
                        Console.WriteLine("=== Selection Sort ===");
                        Console.WriteLine(arrayDS.SelectionSort());
                        break;
                    case 3:
                        //calls in MergeSort() method
                        Console.Clear();
                        Console.WriteLine("=== Merge Sort ===");
                        Console.WriteLine(arrayDS.MergeSort());
                        break;
                    case 4:
                        //calls in timer
                        Console.Clear();
                        Console.WriteLine("=== Timed Methods ===");
                        Console.WriteLine();
                        Console.WriteLine("=== Selection Sort ===");
                        SelectionTimer();
                        Console.WriteLine();
                        Console.WriteLine("=== Merge Sort ===");
                        MergeTimer();
                        break;
                    case 5:
                        Console.Clear();
                        DisplayMenu();
                        break;
                }
                //if option is 4, itll exit the program
                if (option != 5)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } while (option != 5);
        }
        static void SelectionSortstopwatch(string filename)
        {
            ArrayDS arrayDS = new ArrayDS();
            InsertOp(filename, arrayDS);

            Stopwatch sw = Stopwatch.StartNew();
            //starts
            sw.Start();

            //calls selection sort
            arrayDS.SelectionSort();

            //stops
            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //log the time
            Console.WriteLine("--- Time taken to perform Selection Sort ---");
            Console.WriteLine("Time: " + timespan.ToString(@"ss\.fffffff") + " {s}");
        }
        
        //Method to Record merge sort Time 
        static void MergeSortstopwatch(string filename)
        {
            ArrayDS arrayDS = new ArrayDS();
            InsertOp(filename, arrayDS);

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            //calls merge sort
            arrayDS.MergeSort();

            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //logs the time
            Console.WriteLine("--- Time taken to perform Merge Sort ---");
            Console.WriteLine("Time taken: " + timespan.ToString(@"ss\.fffffff") + "s");
        }

        static void MergeTimer()
        {
            string[] sizes = { "1000-words.txt", "5000-words.txt", "10000-words.txt", "15000-words.txt", "20000-words.txt", "25000-words.txt", "30000-words.txt", "35000-words.txt", "40000-words.txt", "45000-words.txt", "50000-words.txt" };

            foreach (var size in sizes)
            {
                string pathFull = Path.Combine(BaseDirectory, size);
                MergeSortstopwatch(pathFull);
            }
        }
        static void SelectionTimer()
        {
            string[] sizes = { "1000-words.txt", "5000-words.txt", "10000-words.txt", "15000-words.txt", "20000-words.txt", "25000-words.txt", "30000-words.txt", "35000-words.txt", "40000-words.txt", "45000-words.txt", "50000-words.txt" };

            foreach (var size in sizes)
            {
                string pathFull = Path.Combine(BaseDirectory, size);
                SelectionSortstopwatch(pathFull);
            }
        }

        //method to preform both SelectionSortstopwatch() and MergeSortstopwatch()
        //static void Timer()
        //{
        //    string filename = string.Empty;

        //    Console.WriteLine("=== Merge Sort Timer ===");
        //    Console.WriteLine();
        //    MergeSortstopwatch("1000-words.txt");
        //    MergeSortstopwatch("5000-words.txt");
        //    MergeSortstopwatch("10000-words.txt");
        //    MergeSortstopwatch("15000-words.txt");
        //    MergeSortstopwatch("20000-words.txt");
        //    MergeSortstopwatch("25000-words.txt");
        //    MergeSortstopwatch("30000-words.txt");
        //    MergeSortstopwatch("35000-words.txt");
        //    MergeSortstopwatch("40000-words.txt");
        //    MergeSortstopwatch("45000-words.txt");
        //    MergeSortstopwatch("50000-words.txt");
        //    Console.WriteLine();

        //    Console.WriteLine("=== Selection Sort Timer ===");
        //    Console.WriteLine();
        //    SelectionSortstopwatch("1000-words.txt");
        //    SelectionSortstopwatch("5000-words.txt");
        //    SelectionSortstopwatch("10000-words.txt");
        //    SelectionSortstopwatch("15000-words.txt");
        //    SelectionSortstopwatch("20000-words.txt");
        //    SelectionSortstopwatch("25000-words.txt");
        //    SelectionSortstopwatch("30000-words.txt");
        //    SelectionSortstopwatch("35000-words.txt");
        //    SelectionSortstopwatch("40000-words.txt");
        //    SelectionSortstopwatch("45000-words.txt");
        //    SelectionSortstopwatch("50000-words.txt");
        //    Console.WriteLine();

        //    if (!string.IsNullOrEmpty(filename))
        //    {
        //        //file path for the inputed file number
        //        string pathFull = Path.Combine(BaseDirectory, filename);
        //        SubMenu(pathFull);
        //    }
        //}        
    }
}
