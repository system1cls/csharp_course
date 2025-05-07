using System.Text;

namespace App.practice2;

public class Mashine
{
    public static string CalculateString(string[] codeLines)
    {
        var builder = new StringBuilder();

        foreach (var str in codeLines)
        {
            switch (str.Substring(0, 4))
            {
                case "push":
                    builder.Append(str.Substring(5, str.Length - 5));
                    break;
                case "pop ":
                    var countToDelete = Convert.ToInt32(str.Substring(4, str.Length - 4));
                    builder.Remove(builder.Length - countToDelete, countToDelete);
                    break;
            }
        }
        
        return builder.ToString();
    }
}