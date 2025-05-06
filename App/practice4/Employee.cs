using App.Practice3;

namespace App.practice4;

public class Employee : User
{
    
    private List<Order> orders;

    public Employee(Guid id, string login, string passwordHash, string name,
        string surname, string phone, DateTime registerTime, string inn, List<Order> orders) : base(id, login, passwordHash, name, surname, 
        inn, phone, registerTime)
    {
        this.orders = orders;
        if (orders is null) throw new ArgumentNullException(nameof(orders));
    }
    
    
}