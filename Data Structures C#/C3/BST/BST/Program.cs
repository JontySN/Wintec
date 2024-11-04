using System;
using System.Diagnostics;
using System.IO;

namespace BST
{
    internal class Program
    {
        #region Base Directory and New Instance
        private static readonly string BaseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Words Files");

        private static BSTree bs = new BSTree();
        #endregion

        #region Main
        static void Main(string[] args)
        {
            int opt = 0;

            while (true)
            {
                opt = MainMenuUI();

                if (opt >= 1 && opt <= 3)
                {
                    MainMenuSwitch(opt);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1-3.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        #endregion

        #region Read File
        static string[] ReadFile(string folder, string fileName)
        {
            return File.ReadAllLines(Path.Combine(BaseDirectory, folder, fileName));
        }
        #endregion

        #region File Insert
        static void FileInsert(string folder, string filename)
        {
            Console.Clear();
            string[] fileToAdd = ReadFile(folder, filename);
            if (fileToAdd.Length == 0)
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                foreach (string line in fileToAdd)
                {
                    string wordAdd = line.Trim();

                    // Skip any word containing a '#'
                    if (!string.IsNullOrEmpty(wordAdd) && !wordAdd.Contains("#"))
                    {
                        bs.Add(wordAdd);  // Add each valid word to the tree
                    }
                }
                Console.WriteLine("Words added successfully.");
            }
        }
        #endregion

        #region Main Menu UI
        static int MainMenuUI()
        {
            Console.Clear();
            Console.WriteLine("=== Binary Search Tree Program ===\n");
            Console.WriteLine("Enter a Dictionary you would like to use\n");
            Console.WriteLine("[1] - Sequentially ordered dictionary");
            Console.WriteLine("[2] - Randomly ordered dictionary");
            Console.WriteLine("[3] - Exit\n");
            Console.WriteLine("Enter Option (1-3): ");
            return int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 3 ? option : 0;
        }
        #endregion

        #region Main Menu Switch
        static void MainMenuSwitch(int opt)
        {
            string folder = string.Empty;
            Console.Clear();
            switch (opt)
            {
                case 1:
                    folder = @"ordered";
                    break;
                case 2:
                    folder = @"random";
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid menu option");
                    return; // Exit if invalid option
            }

            if (!string.IsNullOrEmpty(folder))
            {
                string fullPath = Path.Combine(BaseDirectory, folder);
                FileMenuSwitch(fullPath); 
            }
        }
        #endregion

        #region File Menu UI
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
            return int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 12 ? option : 0;
        }
        #endregion

        #region File Menu Switch
        static void FileMenuSwitch(string folderPath) 
        {
            Console.Clear();
            int opt = FileMenuUI(); // Show file menu UI
            string file = string.Empty;

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
                    return;
                default:
                    Console.WriteLine("Invalid menu option");
                    return; // Exit if invalid option
            }

            if (!string.IsNullOrEmpty(file))
            {
                string fullPath = Path.Combine(folderPath, file);
                Console.WriteLine($"Full Path: {fullPath}");
                if (File.Exists(fullPath))
                {
                    FileInsert(folderPath, file); 
                    OpMenuSwitch(folderPath, file);  
                }
            }
        }
        #endregion

        #region Operations Menu UI
        static int OpMenuUI()
        {
            Console.Clear();
            int opt = 0;
            while (opt < 1 || opt > 7)
            {
                Console.WriteLine("=== Operations Menu ===\n");
                Console.WriteLine("[1] - Add txt");
                Console.WriteLine("[2] - Delete txt");
                Console.WriteLine("[3] - Find txt");
                Console.WriteLine("[4] - Order Menu");
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

        #region Operations Menu Switch
        static void OpMenuSwitch(string folder, string fileName)
        {
            ReadFile(folder, fileName);

            int opt;

            do
            {
                opt = OpMenuUI(); 

                switch (opt)
                {
                    case 1:
                        // Add operation
                        AddOp();
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
                        OrderMenu();
                        break;
                    case 5:
                        // Time complexity report
                        TimeComplexity();
                        break;
                    case 6:
                        // Demonstrate all functions
                        Demonstration();
                        return;
                    case 7:
                        // Exit submenu
                        return;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (opt != 7);  // Only exit the loop when the user chooses option 7.
        }
        #endregion

        #region Order Submenu
        static void OrderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Order Operations Menu ===\n");
                Console.WriteLine("[1] - Pre Order");
                Console.WriteLine("[2] - In Order");
                Console.WriteLine("[3] - Post Order");
                Console.WriteLine("[4] - Exit\n");
                Console.WriteLine("Enter an option (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4)
                {
                    if (option == 4) return;
                    OrderMenuSwitch(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        #endregion

        #region Order Switch
        static void OrderMenuSwitch(int opt)
        {
            switch (opt)
            {
                case 1:
                    // inputs pre-order
                    PreOrder();
                    return;
                case 2:
                    // inputs in-order
                    InOrder();
                    return;
                case 3:
                    // inputs post-order
                    PostOrder();
                    return;
                case 4:
                    // exits
                    return;
            }
        }
        #endregion

        #region Add Operation
        static void AddOp() 
        {
            Console.Clear();
            Console.WriteLine("=== Add Operation ===\n");
            Console.WriteLine("Enter a word that youd like to ADD: ");
            string input = Console.ReadLine();
            
            bs.Add(input);
            Console.ReadKey();

            // Print results
            Console.WriteLine("--- Current List (Pre-Order) ---");
            string result = bs.PreOrder();  
            Console.WriteLine(result); 
            Console.ReadKey();
        }
        #endregion

        #region Delete Operation
        static void DeleteOpMenu() 
        {
            Console.Clear();
            Console.WriteLine("=== Delete Operation ===\n");
            Console.WriteLine("Enter a word that youd like to DELETE: ");
            string input = Console.ReadLine();

            bs.Remove(input);
            Console.ReadKey();

            // Print results
            Console.WriteLine("--- Current List (Pre-Order) ---");
            string result = bs.PreOrder();
            Console.WriteLine(result);
            Console.ReadKey();
        }
        #endregion

        #region Find Operation
        static void FindOp()
        {
            Console.Clear();
            Console.WriteLine("=== Find Operation ===\n");
            Console.WriteLine("Enter a word to find:");
            string word = Console.ReadLine(); //saving input as a variable and executing below
            bs.Find(word);
            
        }
        #endregion

        #region Pre-Order Operation
        private static void PreOrder()
        {
            Console.Clear();
            Console.WriteLine("=== Pre Order ===\n");
            string result = bs.PreOrder();  
            Console.WriteLine(result); 
            Console.ReadKey();
        }
        #endregion

        #region In-Order Operation
        private static void InOrder()
        {
            Console.Clear();
            Console.WriteLine("=== In Order ===\n");
            string result = bs.InOrder();  
            Console.WriteLine(result); 
            Console.ReadKey();
        }
        #endregion

        #region Post-Order Operation
        private static void PostOrder()
        {
            Console.Clear();
            Console.WriteLine("=== Post Order ===\n");
            string result = bs.PostOrder();  
            Console.WriteLine(result); 
            Console.ReadKey();
        }
        #endregion

        #region Insertion Time
        static void InsertionStopwatch(string folder, string numWords)
        {
            bs.Clear(); //clears the list
            ReadFile(folder, $"{numWords}-words.txt");

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            //find operation to find the word "Hammer"
            bs.Add("Hammer");

            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //logs the time
            Console.WriteLine(numWords + " words: " + timespan.ToString(@"ss\.fffffff") + "s");
        }
        #endregion

        #region Searching Stopwatch
        static void SearchingStopwatch(string folder, string numWords)
        { 
            ReadFile(folder, $"{numWords}-words.txt");

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            //find operation to find the word "Hammer"
            bs.Find("Hammer");

            sw.Stop();
            TimeSpan timespan = sw.Elapsed;
            //logs the time
            Console.WriteLine(numWords + " words: " + timespan.ToString(@"ss\.fffffff") + "s");
        }
        #endregion

        #region Time Complexity Report
        static void TimeComplexity() 
        {
            //finds the folder "ordered" and times each file in that folder
            Console.WriteLine("=== Time Complexity Report ===\n");
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

            //finds the folder "ordered" and times how long it takes to search "Hammer" in each file in that folder
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

            //finds the folder "random" and times how long it takes to search "Hammer" in each file in that folder
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
        #endregion

        #region Demonstration
        static void Demonstration()
        {
            #region Add
            Console.Clear();
            Console.WriteLine("--- Adding text ---\n");
            Console.WriteLine("Adding the word 'zu' to envoke error:");
            bs.Add("zu");
            Console.WriteLine("\nAdding the word 'Zebra'");
            bs.Add("Zebra");

            //so it stops between:
            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n--- List after Addition (Pre-Order) ---\n");
            string addResult = bs.PreOrder();
            Console.WriteLine(addResult);
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Press any key to go to delete functions...");
            Console.ReadKey();
            #endregion

            #region Delete
            Console.Clear();
            Console.WriteLine("--- Deleting text ---\n");
            Console.WriteLine("Deleting the word 'Ambulance' to envoke error:");
            bs.Remove("Ambulance");
            Console.WriteLine("\nDeleting the word 'Zebra'");
            bs.Remove("Zebra");

            Console.WriteLine();
            Console.WriteLine("Press any key to Print results...");
            Console.ReadKey();

            Console.WriteLine("\n--- List after Addition (Pre-Order) ---\n");
            string delResult = bs.PreOrder();
            Console.WriteLine(delResult);
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Press any key to go to find function...");
            Console.ReadKey();
            #endregion

            #region Find
            Console.Clear();
            Console.WriteLine("--- Find text ---\n");
            Console.WriteLine("Adding the word 'Ambulance' to envoke error:");
            bs.Find("Ambulance");
            Console.WriteLine("\nFinding the word 'youth'");
            bs.Find("youth");

            Console.WriteLine();
            Console.WriteLine("Press any key to go to pre-order function...");
            Console.ReadKey();
            #endregion

            #region Pre Order
            Console.Clear();
            Console.WriteLine("--- Pre Order ---\n");
            string preOrder = bs.PreOrder();
            Console.WriteLine(preOrder);

            Console.WriteLine();
            Console.WriteLine("\nPress any key to go to in order function...");
            Console.ReadKey();
            #endregion

            #region In Order
            Console.Clear();
            Console.WriteLine("--- In Order ---\n");
            string inOrder = bs.InOrder();  
            Console.WriteLine(inOrder);  

            Console.WriteLine();
            Console.WriteLine("\nPress any key to go to post order function...");
            Console.ReadKey();
            #endregion

            #region Post Order
            Console.Clear();
            Console.WriteLine("--- Post Order ---\n");
            string postOrder = bs.PostOrder();
            Console.WriteLine(postOrder);

            Console.WriteLine();
            Console.WriteLine("\nPress any key to go to time complexity report...");
            Console.ReadKey();
            #endregion

            #region Time Complexity
            TimeComplexity();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit demonstraition...");
            Console.ReadKey();
            #endregion
        }
        #endregion
    }
}
