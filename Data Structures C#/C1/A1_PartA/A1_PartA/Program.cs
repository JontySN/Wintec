using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1_PartA
{
    internal class Program
    {
        private static DictionaryDS WordDictionaryDS = new DictionaryDS();

        static void Main(string[] args)
        {
            string folderName, fileName;
            int folderNum, fileNum;
            int opt;

            // getting the folder name from the input through the main menu
            folderNum = MainMenuUI();
            folderName = MainMenuSwitch(folderNum);

            // getting the file name from the input through the file menu
            fileNum = FileMenuUI();
            fileName = FileMenuSwitch(fileNum);

            try
            {
                // try to read the file the user chose
                ReadFile(folderName, fileName);

                // displaying and performing the operation the user chooses
                opt = SubMenuUI();
                SubMenuSwitch(opt);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred. Check the file path");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        //Method to Display the Main Menu
        static int MainMenuUI()
        {
            int opt = 0;
            while (opt < 1 || opt > 2) //sets parameter between 1 and 2
            {
                Console.Clear();
                Console.WriteLine("=== Dictionary Program ===");
                Console.WriteLine("Enter a Dictionary you would like to use");
                Console.WriteLine();
                Console.WriteLine("[1] - Sequentially ordered dictionary");
                Console.WriteLine("[2] - Randomly ordered dictionary");
                Console.WriteLine();
                Console.WriteLine("Enter Option (1-2): ");
                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }

        //Method to Set the Folder Name from input in MainMenuUI
        static string MainMenuSwitch(int opt)
        {

            string folder;
            if (opt == 1)
            {
                folder = "ordered";
            }
            else
            {
                folder = "random";
            }
            return folder;
        }

        //Method to Display the File Menu
        static int FileMenuUI()
        {
            int opt = 0;
            while (opt < 1 || opt > 11)
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
                Console.WriteLine();
                Console.WriteLine("Enter Option: ");
                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }

        //Method to Set the File Name  
        static string FileMenuSwitch(int file)
        {
            switch (file)
            {
                case 1:
                    return "1000-words";
                case 2:
                    return "5000-words";
                case 3:
                    return "10000-words";
                case 4:
                    return "15000-words";
                case 5:
                    return "20000-words";
                case 6:
                    return "25000-words";
                case 7:
                    return "30000-words";
                case 8:
                    return "35000-words";
                case 9:
                    return "40000-words";
                case 10:
                    return "45000-words";
                case 11:
                    return "50000-words";
                default:
                    Console.WriteLine("Invalid menu option");
                    return null;
            }
        }

        //Method to Read the File into the Dictionary with 2 strings
        static void ReadFile(string folder, string fileName)
        {            
            String[] fileContent = System.IO.File.ReadAllLines($@"Words Files/{folder}/{fileName}.txt");
            foreach (String line in fileContent)
            {
                WordDictionaryDS.AddOp(line);
            }
        }
        //Method for submenu
        static int SubMenuUI()
        {
            int opt = 0;
            while (opt < 1 || opt > 6)
            {
                Console.Clear();
                Console.WriteLine("What operation would you like to perform?");
                Console.WriteLine();
                Console.WriteLine("[1] - Insert txt");
                Console.WriteLine("[2] - Find txt");
                Console.WriteLine("[3] - Delete txt");
                Console.WriteLine("[4] - Print");
                Console.WriteLine("[5] - Time Complexity Report");
                Console.WriteLine("[6] - Demonstrate All Operations");
                Console.WriteLine();
                Console.WriteLine("Enter Option: ");
                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }

        //Method to Perform the User's Chosen Operation
        static void SubMenuSwitch(int opt)
        {
            Console.Clear();
            switch (opt)
            {
                case 1:
                    //inputs AddOp() method
                    WordDictionaryDS.AddOp("Hammer");
                    break;
                case 2:
                    //inputs FindOp() method
                    WordDictionaryDS.FindOp("above");
                    WordDictionaryDS.FindOp("abovve");
                    break;
                case 3:
                    //inputs DeleteOp() method
                    WordDictionaryDS.DeleteOp("above");
                    WordDictionaryDS.DeleteOp("abovve");
                    break;
                case 4:
                    //inputs ToPrint() method
                    Console.WriteLine(WordDictionaryDS.ToPrint());
                    break;
                case 5:
                    //Calls TimeComplexity() that works all the stopwatches
                    TimeComplexity();
                    break;
                case 6:
                    // display and perform each operation

                    //demonstrate AddOp()
                    WordDictionaryDS.AddOp("hammer");
                    //demonstrate FindOp()
                    WordDictionaryDS.FindOp("above");
                    WordDictionaryDS.FindOp("abovve");
                    //Demonstrate DeleteOp()
                    WordDictionaryDS.DeleteOp("above");
                    WordDictionaryDS.DeleteOp("abovve");

                    //Demonstrates the ToPrint() method
                    Console.WriteLine();
                    Console.WriteLine("Press any key to print the dictionary...");
                    Console.ReadKey();
                    Console.WriteLine(WordDictionaryDS.ToPrint());

                    //Demonstrates the TimeComeplexity() method
                    Console.WriteLine();
                    Console.WriteLine("Press any key to call TimeComplexity(); ");
                    Console.ReadKey();
                    TimeComplexity();
                    break;
                default:
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }

        //method for InsertionStopwatch that sees how long it takes to preform an insertion
        static void InsertionStopwatch(string folder, string numWords)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //starts
            sw.Start();
            
            //reads file
            ReadFile(folder, $"{numWords}-words");

            //stops
            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //log the time
            Console.WriteLine("--- Time taken to perform insert ---");
            Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.fffffff") + " {m:ss}");
            Console.WriteLine("Time: " + timespan.ToString(@"ss\.fffffff") + " {s}");
        }

        //method to preform both insertionstopwatch() and searhingstopwatch()
        static void TimeComplexity()
        {
            WordDictionaryDS.Clear(); // clearing the dictionary so it doesn't affect the report

            //finds the folder "ordered" and times each file in that folder
            Console.WriteLine("=== Time Complexity Report ===");
            Console.WriteLine("--- Insertion Time ---");
            Console.WriteLine();
            Console.WriteLine("Sequentially Ordered Words:");
            InsertionStopwatch("ordered", "1000");
            InsertionStopwatch("ordered", "5000");
            InsertionStopwatch("ordered", "10000");
            InsertionStopwatch("ordered", "15000");
            InsertionStopwatch("ordered", "20000");
            InsertionStopwatch("ordered", "25000");
            InsertionStopwatch("ordered", "30000");
            InsertionStopwatch("ordered", "35000");
            InsertionStopwatch("ordered", "40000");
            InsertionStopwatch("ordered", "45000");
            InsertionStopwatch("ordered", "50000");
            Console.WriteLine();

            //finds the folder "random" and times each file in that folder
            Console.WriteLine();
            Console.WriteLine("Randomly Ordered Words:");
            InsertionStopwatch("random", "1000");
            InsertionStopwatch("random", "5000");
            InsertionStopwatch("random", "10000");
            InsertionStopwatch("random", "15000");
            InsertionStopwatch("random", "20000");
            InsertionStopwatch("random", "25000");
            InsertionStopwatch("random", "30000");
            InsertionStopwatch("random", "35000");
            InsertionStopwatch("random", "40000");
            InsertionStopwatch("random", "45000");
            InsertionStopwatch("random", "50000");
            Console.WriteLine("\n\n");

            //finds the folder "ordered" and times how long it takes to search "above" in each file in that folder
            Console.WriteLine("--- Searching Time ---");
            Console.WriteLine();
            Console.WriteLine("Sequentially Ordered Words:");
            SearchingStopwatch("ordered", "1000");
            SearchingStopwatch("ordered", "5000");
            SearchingStopwatch("ordered", "10000");
            SearchingStopwatch("ordered", "15000");
            SearchingStopwatch("ordered", "20000");
            SearchingStopwatch("ordered", "25000");
            SearchingStopwatch("ordered", "30000");
            SearchingStopwatch("ordered", "35000");
            SearchingStopwatch("ordered", "40000");
            SearchingStopwatch("ordered", "45000");
            SearchingStopwatch("ordered", "50000");
            Console.WriteLine();

            //finds the folder "random" and times how long it takes to search "above" in each file in that folder
            Console.WriteLine();
            Console.WriteLine("Randomly Ordered Words:");
            SearchingStopwatch("random", "1000");
            SearchingStopwatch("random", "5000");
            SearchingStopwatch("random", "10000");
            SearchingStopwatch("random", "15000");
            SearchingStopwatch("random", "20000");
            SearchingStopwatch("random", "25000");
            SearchingStopwatch("random", "30000");
            SearchingStopwatch("random", "35000");
            SearchingStopwatch("random", "40000");
            SearchingStopwatch("random", "45000");
            SearchingStopwatch("random", "50000");
        }
        //Method to Record Searching Time 
        static void SearchingStopwatch(string folder, string numWords)
        {
            ReadFile(folder, $"{numWords}-words");

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            //find operation to find the word "above"
            WordDictionaryDS.FindOp("above");

            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //logs the time
            Console.WriteLine(numWords + " words: " + timespan.ToString(@"ss\.fffffff") + "s");
        }
    }
}

