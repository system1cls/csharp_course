namespace App;

public static class Prices
{
    public static string GetCurrencyAlias(int price, bool isShorNotation, bool isFirstCapital)
    {
        String str = "";
        if (isFirstCapital) str += "Руб";
        else str += "руб";

        if (isShorNotation)
        {
            str += ".";
            return str;
        }

        switch (price % 10)
        {
            case 1:
                if (price % 100 == 11) str += "лей";
                else str  += "ль";
                return str;
            
            case 2:
            case 3:
            case 4:
                if (price % 100 == 10 + price % 10) str += "лей";
                else str += "ля";
                return str;
            default:
                str += "лей";
                return str;
        }
    }
}