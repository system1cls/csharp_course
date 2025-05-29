namespace App.practice6;

public sealed class ProductsSearchDto  
{  
    public string Query { get; set; }  
    public ProductsSortType ProductsSortType { get; set; } 
}

public enum ProductsSortType  
{  
    Popularity,  
    Price  
}

public sealed class CreateProductDto  
{  
    public string Name { get; set; }  
    public string Description { get; set; }  
    public decimal Price { get; set; }  
    public Guid Seller { get; set; }  
}

public sealed class UpdateProductDto  
{  
    public string Name { get; set; }  
    public string Description { get; set; }  
    public decimal Price { get; set; }  
    public int Amount { get; set; }  
}