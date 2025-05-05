namespace App.practice2;

public class Phone
{
    public static bool TryParsePhone(string inputString, out string parsedPhone) 
    {
        for (int i = 0; i < inputString.Length; i++)
        {
            var new_it = check(inputString, i);
            if (new_it >= 0)
            {
                parsedPhone = inputString.Substring(i, new_it - i);
                return true;
            }
        }
        
        parsedPhone = null;
        return false;
    }

    static int check(string inputString, int it)
    {
        if (inputString[it] == '+') it++;
        
        if (it > inputString.Length - 1) return -1;
        
        switch (inputString[it])
        {
            case '7':
            case '8':
                var new_it = checkSep(inputString, it + 1);

                if (new_it < 0) return -1;
                if (new_it == it + 1 || new_it == it + 2)
                {
                    new_it = checkdigits(inputString, new_it, 3);
                    if (new_it == -1) return -1;
                }

                new_it = checkBlock(inputString, new_it, 3);
                if (new_it == -1) return -1;
                
                new_it = checkBlock(inputString, new_it, 2);
                if (new_it == -1) return -1;
                
                new_it = checkBlock(inputString, new_it, 2);
                if (new_it == -1) return -1;

                return new_it;
                
            default: 
                return -1;
        }
    }

    static int checkBlock(string inputString, int it, int cnt)
    {
        var new_it = checkSep(inputString, it);
        if (new_it < 0) return -1;
        
        new_it = checkdigits(inputString, new_it, cnt); 
        return new_it;
    }
    
    static int checkSep(string inputString, int it)
    {
        var sc = false;
        
        while (it < inputString.Length) {

            switch (inputString[it])
            {

                case '(':
                    it = checkdigits(inputString, it + 1, 3);
                    sc = true;
                    break;
                case ')':
                    if (sc) return it + 1;
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
    
    static int checkdigits(string inputString, int it, int count)
    {
        var new_it = it;
        for (; new_it < it + count; new_it++)
        {
            if (new_it >= inputString.Length) return -1;
            if (!Char.IsDigit(inputString[new_it])) return -1;
        }
        
        
        return new_it;
    }
}