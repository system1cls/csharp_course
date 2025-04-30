namespace App.practice4;

public class Seller : Employee
{
    protected List<Product> products;
    
    public Seller(Guid id, string login, string passwordHash, string name, string surname, string phone, 
        DateTime registerTime, string inn, List<Order> orders, List<Product> products) : base(id, login, passwordHash, name, surname, phone, registerTime, inn, orders)
    {
        this.products = products;
        if (products is null) throw new ArgumentNullException(nameof(products));
    }
}