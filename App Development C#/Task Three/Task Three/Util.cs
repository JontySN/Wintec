namespace Task_Three;

public class Util
{
    public static readonly int ROUND = 2;
    public static readonly string BAD_STRING = string.Empty;
    public static readonly int BAD_INT = Int32.MinValue;
    public static readonly double BAD_DOUBLE = Double.MinValue;

    #region Parse Int Validation
    public static int ParseInt(object? o)
    {
        if (o == null) return BAD_INT;
        int n;
        if (int.TryParse(o.ToString(), out n) == false)
            return BAD_INT;
        return n;
    }
    #endregion

    #region Parse Double Validaion
    public static double ParseDouble(object? o)
    {
        if (o == null) return BAD_DOUBLE;
        double n;
        if (double.TryParse(o.ToString(), out n) == false)
            return BAD_DOUBLE;
        return n;
    }
    #endregion

    #region Title Case
    public static string ToTitleCase(string s)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
    }
    #endregion

    #region Type Verification
    public static string? VerifyType(string? type)
    {
        if (string.IsNullOrWhiteSpace(type)) return null;
        var types = new List<string>() { "Manager", "Salesperson" };
        string t = ToTitleCase(type);
        return types.Contains(t) ? t : null;
    }
    #endregion
}