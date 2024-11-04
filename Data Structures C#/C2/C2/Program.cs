using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    internal class Program
    {
        #region Main
        private static readonly string BaseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Words Files");

        private static DList dList = new DList();
        static void Main(string[] args)
        {
            int opt = 0;

            // While true loop to keep program running until valid input is entered.
            while (true)
            {
                opt = FileMenuUI();

                if (opt >= 1 && opt <= 12)
                {
                    FileMenuSwitch(opt);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1-12.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
        #endregion

        #region Read File Method
        // Method to Read the File into the Doubly Linked List
        static String[] ReadFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filename}: {ex.Message}\nStack Trace: {ex.StackTrace}");//chatGPT for debugging code
                return new string[0]; // Return an empty array in case of an error
            }
        }

        static void FileInsert(string filename)
        {
            Console.Clear();
            String[] filetoadd = ReadFile(filename);
            if (filetoadd.Length == 0)
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                foreach (String line in filetoadd)
                {   // Add a way to remove # and remove duplicates
                    string wordAdd = line;
                    int wordLen = wordAdd.Length;
                    dList.AddToEnd(wordAdd, wordLen);
                }
            }
        }
        #endregion

        #region File Menu UI
        //Method to Display the File Menu
        static int FileMenuUI()
        {

            Console.Clear();
            Console.WriteLine("=== File Menu ===\n");
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
            Console.WriteLine("[12] - Exit\n");
            Console.WriteLine("Enter Option (1-12): ");

            int option;

            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 12)
            {

                return option;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region File Menu Switch

        static void FileMenuSwitch(int opt)
        {
            string file = string.Empty;
            Console.Clear();
            switch (opt)
            {
                case 1:
                    file = @"1000-words.txt";
                    break;
                case 2:
                    file = @"5000-words.txt";
                    break;
                case 3:
                    file = @"10000-words.txt";
                    break;
                case 4:
                    file = @"15000-words.txt";
                    break;
                case 5:
                    file = @"20000-words.txt";
                    break;
                case 6:
                    file = @"25000-words.txt";
                    break;
                case 7:
                    file = @"30000-words.txt";
                    break;
                case 8:
                    file = @"35000-words.txt";
                    break;
                case 9:
                    file = @"40000-words.txt";
                    break;
                case 10:
                    file = @"45000-words.txt";
                    break;
                case 11:
                    file = @"50000-words.txt";
                    break;
                case 12:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid menu option");
                    break;
            }

            if (!string.IsNullOrEmpty(file))
            {
                string fullPath = Path.Combine(BaseDirectory, file);
                SubMenuSwitch(fullPath);
            }
        }
        #endregion

        #region Sub Menu UI

        //Method for submenu
        static int SubMenuUI()
        {
            Console.Clear();
            int opt = 0;
            while (opt < 1 || opt > 7)
            {

                Console.WriteLine("=== Operations Menu ===\n");
                Console.WriteLine("[1] - Add txt");
                Console.WriteLine("[2] - Delete txt");
                Console.WriteLine("[3] - Find txt");
                Console.WriteLine("[4] - Print");
                Console.WriteLine("[5] - Time Complexity Report");
                Console.WriteLine("[6] - Demonstration");
                Console.WriteLine("[7] - Exit");
                Console.WriteLine();
                Console.WriteLine("Enter Option(1-7): ");
                if (!int.TryParse(Console.ReadLine(), out opt))
                {
                    opt = 0;
                }
            }
            return opt;
        }
        #endregion

        #region Sub Menu Switch
        static void SubMenuSwitch(string file)
        {
            dList.ListClear();
            FileInsert(file);  // Load the file into the list.

            int opt;

            do
            {
                opt = SubMenuUI();  // Get the user's choice.

                switch (opt)
                {
                    case 1:
                        // Add operation
                        AddOpMenu();
                        break;
                    case 2:
                        // Delete operation
                        DeleteOpMenu();
                        break;
                    case 3:
                        // Find operation
                        FindOp();
                        break;
                    case 4:
                        // Print operation
                        PrintOp();
                        break;
                    case 5:
                        // Time complexity report
                        TimeComplexity();
                        break;
                    case 6:
                        //Demonstrate all functions
                        Demonstration();
                        return;
                    case 7:
                        // Exit submenu
                        return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (opt != 6);  // Only exit the loop when the user chooses option 6.
        }
        #endregion

        #region Demonstration
        static void Demonstration()
        {
            //add front
            Console.Clear();
            Console.WriteLine("--- Add text to front ---\n");
            Console.WriteLine("Adding the word 'joy' to end to envoke error:");
            dList.AddToFront("joy", 3);
            Console.WriteLine("\nAdding the word 'Dinosaur' to the front...");
            dList.AddToFront("Dinosaur", 8);

            //so it stops between:
            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Addition ===\n");
            dList.ToPrint();
            
            Console.WriteLine();
            Console.WriteLine("Press any key to go to add to end function...");
            Console.ReadKey();

            //add end
            Console.Clear();
            Console.WriteLine("--- Add text to end ---\n");
            Console.WriteLine("Adding the word 'joy' to end to envoke error:");
            dList.AddToEnd("joy", 3);
            Console.WriteLine("\nAdding the word 'Penguin' to the end...");
            dList.AddToEnd("Penguin", 8);

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Addition ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine("Press any key to go to add before function...");
            Console.ReadKey();

            //add before
            Console.Clear();
            Console.WriteLine("--- Add text before ---\n");
            Console.WriteLine("Adding the word 'joy' before joy to envoke error:");
            string errorBefore = dList.AddBefore("joy", 3, "joy");
            Console.WriteLine(errorBefore);
            Console.WriteLine("\nAdding the word 'highschool' before 'joy'...");
            string foundBefore = dList.AddBefore("highschool", 10, "joy");
            Console.WriteLine(foundBefore);

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Deletion ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine("Press any key to go to add after function...");
            Console.ReadKey();

            //add after
            Console.Clear();
            Console.WriteLine("--- Add text after ---\n");
            Console.WriteLine("Adding the word 'joy' before joy to envoke error:");
            string errorAfter = dList.AddAfter("joy", 3, "joy");
            Console.WriteLine(errorAfter);
            Console.WriteLine("\nAdding the word 'Dino' after 'joy'...");
            string addedAfter = dList.AddAfter("Dino", 4, "joy");
            Console.WriteLine(addedAfter);

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Additions ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any key to go to delete front function...");
            Console.ReadKey();

            //Delete at front
            Console.Clear();
            Console.WriteLine("Deleting at Front...\n");
            dList.DeleteFront();

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Deletion ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine("Press any key to go to delete back function...");
            Console.ReadKey();

            //delete at back
            Console.Clear();
            Console.WriteLine("Deleteing at Back...\n");
            dList.DeleteEnd();

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Deletion ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine("Press any key to go to delete word function...");
            Console.ReadKey();

            //delete by search
            Console.Clear();
            Console.WriteLine("--- Deleteing specific word (by node) ---\n");
            Console.WriteLine("Deleting the word 'joy' from list...");
            string delete = dList.RemoveWord("joy");
            Console.WriteLine(delete);

            Console.WriteLine();
            Console.WriteLine("Press any key to print results...");
            Console.ReadKey();

            Console.WriteLine("\n=== List after Deletions ===\n");
            dList.ToPrint();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any key to go to find function...");
            Console.ReadKey();

            //find op
            Console.WriteLine("\n=== Find Op ===");
            Console.WriteLine("Finding the word 'sister'...");
            string found = dList.Find("sister");
            Console.WriteLine(found);

            Console.WriteLine();
            Console.WriteLine("Press any key to go to print function...");
            Console.ReadKey();

            Console.WriteLine("\n=== Print Op ===\n");
            dList.ToPrint();

            Console.WriteLine();
            Console.WriteLine("Press any key to go to the time complexity reports...");
            Console.ReadKey();

            //time complexity report
            TimeComplexity();
        }
        #endregion

        #region Find Op
        static void FindOp()
        {
            Console.WriteLine("Enter a word to find:");
            string word = Console.ReadLine(); //saving input as a variable and executing below
            string found = dList.Find(word);
            Console.WriteLine(found);
        }
        #endregion

        #region PrintOp
        static void PrintOp()
        {
            Console.WriteLine("=== Doubly Linked List Contents ===\n");
            dList.ToPrint();//envokes the to print method
            Console.ReadKey();//make sure it stays on screen
        }
        #endregion

        #region Add Menu UI
        static void AddOpMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Add Operations ===\n");
                Console.WriteLine("[1] - Add txt to front");
                Console.WriteLine("[2] - Add txt to end");
                Console.WriteLine("[3] - Add txt before");
                Console.WriteLine("[4] - Add txt after");
                Console.WriteLine("[5] - Exit");
                Console.WriteLine();
                Console.Write("Enter Option (1-5): \n");
                if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 5)
                {
                    if (option == 5) return;
                    AddMenuSwitch(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        #endregion

        #region Add Switch
        static void AddMenuSwitch(int opt)
        {
            switch (opt)
            {
                case 1:
                    //inputs AddToFront() method
                    AddFrontOp();
                    return;
                case 2:
                    //inputs AddToEnd() method
                    AddEndOp();
                    return;
                case 3:
                    //inputs AddBefore() method
                    AddBeforeOp();
                    return;
                case 4:
                    //inputs AddAfter() method
                    AddAfterOp();
                    return;
                case 5:
                    Console.WriteLine("Exting...");
                    return;
            }
        }
        #endregion

        #region Add Front Op
        static void AddFrontOp()
        {
            Console.Clear();
            Console.WriteLine("--- Front Insertion ---\n");
            Console.WriteLine("Enter a Word to insert to FRONT:");
            string input = Console.ReadLine();
            dList.AddToFront(input, input.Length);

            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint();
            Console.ReadKey();
        }

        #endregion

        #region Add To End Op
        static void AddEndOp()
        {
            Console.Clear();
            Console.WriteLine("--- End Insertion ---\n");
            Console.WriteLine("Enter a Word to insert at END:");
            string input = Console.ReadLine();
            dList.AddToEnd(input, input.Length);

            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint();
            Console.ReadKey();
        }
        #endregion

        #region Add before Op
        static void AddBeforeOp()
        {
            Console.Clear();
            Console.WriteLine("--- Add Before Operation --- \n");


            // Prompt the user for input
            Console.WriteLine("Enter the word to insert: ");
            string word = Console.ReadLine();

            Console.WriteLine("Enter the target word BEFORE which to insert: ");
            string target = Console.ReadLine();

            // Call the AddAfter method and display the result
            string result = dList.AddBefore(word, word.Length, target);
            Console.WriteLine(result);

            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint(); // Print the list after the operation
            Console.ReadKey();
        }

        #endregion

        #region Add After Op
        static void AddAfterOp()
        {
            Console.Clear();
            Console.WriteLine("--- Add After Operation --- \n");

            // Prompt the user for input
            Console.WriteLine("Enter the word to insert: ");
            string word = Console.ReadLine();

            Console.WriteLine("Enter the target word AFTER which to insert: ");
            string target = Console.ReadLine();

            // Call the AddAfter method and display the result
            string result = dList.AddAfter(word, word.Length, target);

            Console.WriteLine(result);

            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint(); // Print the list after the operation
            Console.ReadKey();
        }
        #endregion

        #region Delete Stuff

        #region Delete Menu UI
        static void DeleteOpMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Delete Operation ===\n");
                Console.WriteLine("[1] - Delete at Front");
                Console.WriteLine("[2] - Delete at End");
                Console.WriteLine("[3] - Delete Word");
                Console.WriteLine("[4] - Exit");
                Console.WriteLine();
                Console.Write("Enter Option (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4)
                {
                    if (option == 4) break;
                    DeleteMenuSwitch(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        #endregion

        #region Delete Switch
        static void DeleteMenuSwitch(int opt)
        {
            switch (opt)
            {
                case 1:
                    //inputs DeleteAtFront() method
                    DeleteAtFrontOp();
                    break;
                case 2:
                    //inputs DeleteAtEnd() method
                    DeleteAtEndOp();
                    break;
                case 3:
                    //inputs DeleteOp() method
                    DeleteWordOp();
                    break;
                case 4:
                    //inputs exit menu method
                    Environment.Exit(0);
                    break;
            }
            //if option is 4, itll exit the program
            if (opt != 4)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion

        #region DeleteOp
        static void DeleteWordOp()
        {
            Console.Clear();
            Console.WriteLine("--- Delete by Search ---\n");
            Console.WriteLine("Enter word to delete from list: ");
            string deleteWord = Console.ReadLine();
            string deleted = dList.RemoveWord(deleteWord);


            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint();
            Console.WriteLine(deleted);
            Console.ReadKey();
        }
        #endregion

        #region DeleteFrontOp
        static void DeleteAtFrontOp()
        {
            Console.Clear();
            dList.DeleteFront();
            Console.WriteLine("--- Word deletion at front completed. ---\n");
            Console.WriteLine();

            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint();
            Console.ReadKey();
        }
        #endregion

        #region DeleteEndOp
        static void DeleteAtEndOp()
        {
            Console.Clear();
            dList.DeleteEnd();
            Console.WriteLine("--- Word deletion at front completed. ---\n");
            Console.WriteLine();
            Console.WriteLine("\n --- Current List ---");
            dList.ToPrint();
            Console.ReadKey();
        }
        #endregion

        #endregion

        #region Insertion Time
        static void InsertionStopwatch(string numWords)
        {
            string fullPath = Path.Combine(BaseDirectory, $"{numWords}-words.txt");

            dList.ListClear();
            //reads file
            ReadFile(fullPath);

            Stopwatch sw = Stopwatch.StartNew();
            //starts
            sw.Start();


            //find operation to find the word "Hammer"
            dList.AddToEnd("Hammer", 6);

            //stops
            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //log the time
            Console.WriteLine("--- Time taken to perform insert ---\n");
            Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.fffffff") + " {m:ss}");
            Console.WriteLine("Time: " + timespan.ToString(@"ss\.fffffff") + " {s}");
        }
        #endregion

        #region Searching Stopwatch
        //method to preform insertionstopwatch() 
        static void TimeComplexity()
        {
            //inserts the word 'hammer' and times each file in the word folder
            Console.WriteLine("=== Time Complexity Report ===\n");
            Console.WriteLine("--- Insertion Time ---");
            Console.WriteLine();
            InsertionStopwatch("1000");
            InsertionStopwatch("5000");
            InsertionStopwatch("10000");
            InsertionStopwatch("15000");
            InsertionStopwatch("20000");
            InsertionStopwatch("25000");
            InsertionStopwatch("30000");
            InsertionStopwatch("35000");
            InsertionStopwatch("40000");
            InsertionStopwatch("45000");
            InsertionStopwatch("50000");
            Console.WriteLine();
        }
        #endregion
    }
}