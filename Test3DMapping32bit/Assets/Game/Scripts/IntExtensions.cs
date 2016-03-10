using System.Text;

public static class IntExtensions
{
    public static string ToScoreFormat(this int number)
    {
        if (number > 99) return "99";
        StringBuilder sb = new StringBuilder();
        if (number < 10)
        {
            sb.Append('0');
        }
        sb.Append(number);
        return sb.ToString();
    }
}

