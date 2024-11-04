namespace Task_One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessNumbers();
        }

        #region Process Numbers
        public static void ProcessNumbers()
        {
            Write("Enter first set of numbers: ");
            string input1 = ReadLine(); // Get the first input from the user
            var firstSet = InputValidation(input1); // Pass the input to the method

            Write("Enter second set of numbers: ");
            string input2 = ReadLine(); // Get the second input from the user
            var secondSet = InputValidation(input2); // Pass the input to the method

            var primesFirstSet = GetPrimes(firstSet.Item1, firstSet.Item2); // Use the tuple values
            var primesSecondSet = GetPrimes(secondSet.Item1, secondSet.Item2); // Use the tuple values

            WriteLine($"Primes between {firstSet.Item1}-{firstSet.Item2}: {string.Join(",", primesFirstSet)}");
            WriteLine($"Primes between {secondSet.Item1}-{secondSet.Item2}: {string.Join(",", primesSecondSet)}");
        }
        #endregion

        #region Input Validation
        static (int, int) InputValidation(string input)
        {
            var parts = input.Split(',');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int num1) || !int.TryParse(parts[1], out int num2))
            {
                WriteLine("Input must have two numbers, separated by a comma.");
                return (0, 0); // Returning a default tuple, or you could handle it differently.
            }

            return (num1, num2); // Return the tuple with the two parsed integers.
        }
        #endregion

        #region Prime Method
        public static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        #endregion

        #region Get Prime
        static List<int> GetPrimes(int start, int end)
        {
            var primes = new List<int>();
            if (start > end)
            {
                var temp = start;
                start = end;
                end = temp;
            }

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
        #endregion
    }
}
