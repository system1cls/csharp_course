using App.practice4;
using App.practice6.InfoClasses;

namespace App.practice6;

public interface IProductsService
{
    
    public ProductsServiceResult<Product>? GetProduct(Guid productId);  

    //отдает все продукты продавца
    public ProductsServiceResult<List<Product>>? GetSellerProducts(Guid sellerId);

    //отдает продукты, которые удовлетворяют поисковому запросу
    public ProductsServiceResult<List<Product>> SearchProducts(ProductsSearchDto dto);  

    //добавляет продукт в корзину
    public void AddProductToCart(Guid cartId, Guid productId);  

    //создает продукт
    public ProductsServiceResult<Product> CreateProduct(CreateProductDto createProductDto); 

    //изменяет некоторые свойства продукта
    public ProductsServiceResult<Guid>? UpdateProduct(UpdateProductDto updateProductDto); 

    //удаляет продукт
    public ProductsServiceResult<Product>? DeleteProduct(Guid productId);  
}