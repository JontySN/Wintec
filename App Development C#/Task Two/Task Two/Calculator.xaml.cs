namespace Task_Two;

public partial class Calculator : ContentPage
{
    public Calculator()
    {
        InitializeComponent();
    }

    #region Calculate Button Operation
    private void btnCalculate_Click(object sender, EventArgs e)
    {
        // Validate and get input numbers
        var Set = InputValidation(NumberEntry.Text);

        if (Set.Item1 == 0 && Set.Item2 == 0)
        {
            return;
        }

        // Calculate prime numbers
        var primesSet = GetPrimes(Set.Item1, Set.Item2);

        // Display results
        lblResult.Text = $"Primes between {Set.Item1}-{Set.Item2}: {string.Join(", ", primesSet)}\n";
    }
    #endregion

    #region Reset Button Operation
    private void btnReset_Click(object sender, EventArgs e)
    {
        // Clear input and output fields
        NumberEntry.Text = "";
        lblResult.Text = "Results: ";
    }
    #endregion

    #region Input Validation
    private (int, int) InputValidation(string input)
    {
        var parts = input.Split(',');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int num1) || !int.TryParse(parts[1], out int num2))
        {
            DisplayAlert("Error", "Input must have two numbers, separated by a comma.", "Ok");
            return (0, 0);
        }
        return (num1, num2);
    }
    #endregion

    #region Get Primes Method
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

    #region IsPrime
    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    #endregion
}

