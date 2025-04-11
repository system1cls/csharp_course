namespace App.practice2;

public class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[10];

        String[] strs = text.Split(" ");

        foreach (var str in strs)
        {
            int ind = str.IndexOfAny("0123456789".ToCharArray());
            if (ind >= 0 && ind < str.Length) statistics[str[ind] - '0']++;
        }
        
        return statistics;
    }
}