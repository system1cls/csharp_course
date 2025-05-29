namespace App.practice4;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

//сколько единиц товара в наличии
    public int Amount { get; set; }

//кто продавец
    public Guid SellerId { get; set; }
    
    
    
}