
namespace App.Practice3;

public class User
{
    public  Guid Id { get; init; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Name { set; get; }
    public string Surname { set; get; }
    public string Inn { set; get; }

    private string _phone;
    
    public string Phone { 
        set
        {
            if (TryUpdatePhone(value)) _phone = value;
            else _phone = "";
        }
        get { return _phone; }
    }
    public DateTime RegisterTime { init; get; }

    public User(Guid id, string login, string passwordHash, string name,
        string surname, string inn, string phone, DateTime registerTime)
    {
        this.Id = id;
        this.Login = login;
        this.PasswordHash = passwordHash;
        this.Name = name;
        this.Surname = surname;
        this.Inn = inn;
        this.Phone = phone;
        this.RegisterTime = registerTime;
    }
    public User() 
    {
        this.Id = Guid.NewGuid();
        this.RegisterTime = DateTime.Now;
    }

    public string GetUserFullName()
    {
        return Name + " " + Surname;
    }

    public bool TryUpdatePhone(string phone)
    {
        if (IsPhoneValid(phone, out phone))
        {
            this._phone = phone;
            return true;
        }
        return false;
    }

    
    private static bool IsPhoneValid(string inputString, out string parsedPhone) 
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
                var newIt = CheckSep(inputString, it + 1);

                if (newIt < 0) return -1;
                if (newIt == it + 1 || newIt == it + 2)
                {
                    newIt = Checkdigits(inputString, newIt, 3);
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
        var newIt = CheckSep(inputString, it);
        if (newIt < 0) return -1;
        
        newIt = Checkdigits(inputString, newIt, cnt); 
        return newIt;
    }

    private static int CheckSep(string inputString, int it)
    {
        var sc = false;
        
        while (it < inputString.Length) {

            switch (inputString[it])
            {

                case '(':
                    it = Checkdigits(inputString, it + 1, 3);
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

    private static int Checkdigits(string inputString, int it, int count)
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