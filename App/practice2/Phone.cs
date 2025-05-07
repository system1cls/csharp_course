namespace App.practice2;

public class Phone
{
    public static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        for (var i = 0; i < inputString.Length; i++)
        {
            var newIt = Check(inputString, i);
            if (newIt >= 0)
            {
                parsedPhone = inputString.Substring(i, newIt - i);
                return true;
            }
        }
        
        parsedPhone = null;
        return false;
    }

    private static int Check(string inputString, int it)
    {
        if (inputString[it] == '+') it++;
        
        if (it > inputString.Length - 1) return -1;
        
        switch (inputString[it])
        {
            case '7':
            case '8':
                var newIt = CheckSeparators(inputString, it + 1);

                if (newIt < 0) return -1;
                if (newIt == it + 1 || newIt == it + 2)
                {
                    newIt = CheckDigits(inputString, newIt, 3);
                    if (newIt == -1) return -1;
                }

                newIt = CheckBlock(inputString, newIt, 3);
                if (newIt == -1) return -1;
                
                newIt = CheckBlock(inputString, newIt, 2);
                if (newIt == -1) return -1;
                
                newIt = CheckBlock(inputString, newIt, 2);
                if (newIt == -1) return -1;

                return newIt;
                
            default: 
                return -1;
        }
    }

    private static int CheckBlock(string inputString, int it, int cnt)
    {
        var newIt = CheckSeparators(inputString, it);
        if (newIt < 0) return -1;
        
        newIt = CheckDigits(inputString, newIt, cnt); 
        return newIt;
    }
    
    static int CheckSeparators(string inputString, int it)
    {
        var isStaplesStarted = false;
        
        while (it < inputString.Length) {

            switch (inputString[it])
            {

                case '(':
                    it = CheckDigits(inputString, it + 1, 3);
                    if (it == -1) return it;
                    isStaplesStarted = true;
                    break;
                case ')':
                    if (isStaplesStarted) return it + 1;
                    else return -1;
                case '-':
                    return it + 1;
                case '0': 
                case '1': 
                case '2': 
                case '3': 
                case '4': 
                case '5':
                case '6': 
                case '7': 
                case '8':
                case '9':
                    return it;
            }   
        }
        
        return -1;
}
    
    static int CheckDigits(string inputString, int it, int count)
    {
        var newIt = it;
        for (; newIt < it + count; newIt++)
        {
            if (newIt >= inputString.Length) return -1;
            if (!Char.IsDigit(inputString[newIt])) return -1;
        }
        
        
        return newIt;
    }
}