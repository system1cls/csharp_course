using App.practice4;
using App.practice6.InfoClasses;

namespace App.practice6;

public class ProductsService : IProductsService
{
    List<Cart> Carts = new List<Cart>();
    List<Seller> Sellers = new List<Seller>();
    List<Product> Products = new List<Product>();

    
    ProductsService(List<Seller> sellers, List<Product> products)
    {
        this.Sellers = sellers;
        this.Products = products;
    }
    
    
    public ProductsServiceResult<Product>? GetProduct(Guid productId)
    {
        foreach (var seller in Sellers)
        {
            foreach (var product in Products)
            {
                if (product.Id == productId)
                {
                    ProductsServiceResult<Product> result = new ProductsServiceResult<Product>();
                    result.product = product;
                    return result;
                }
            }
        }

        return null;
    }

    public ProductsServiceResult<List<Product>>? GetSellerProducts(Guid sellerId)
    {
        foreach (var seller in Sellers)
        {
            if (sellerId == seller.Id)
            {
                var  res = new ProductsServiceResult<List<Product>>();
                res.product = seller.Products;
                return res;
            }
        }
        return null;
    }

    public ProductsServiceResult<List<Product>> SearchProducts(ProductsSearchDto dto)
    {
        var list = new List<Product>();
        decimal price = -1;
        long popularity = -1;
        
        
        if (dto.ProductsSortType == ProductsSortType.Price)
        {
            Decimal.TryParse(dto.Query, out price);            
        }

        if (dto.ProductsSortType == ProductsSortType.Popularity)
        {
            long.TryParse(dto.Query, out popularity);
        }
        
        
        foreach (var seller in Sellers)
        {
            foreach (var product in seller.Products)
            {
                if (price <= product.Price) list.Add(product);
                else if (popularity != -1)
                {
                }
            }
        }

        var ans = new ProductsServiceResult<List<Product>>();
        ans.product = list;
        
        return ans;
    }

    public void AddProductToCart(Guid cartId, Guid productId)
    {

        var cart = FindOrAddCart(cartId);
        FindAndOrAddProduct(productId, Carts[cart]);
    }

    public ProductsServiceResult<Product> CreateProduct(CreateProductDto createProductDto)
    {
        var seller = FindAndOrAddSeller(createProductDto.Seller);
        if (seller is null) throw new NullReferenceException("seller is null");
        
        var ans = new ProductsServiceResult<Product>();
        var product = FindAndOrAddProduct(createProductDto.Name, seller);
        if (product is null)
        {
            var newProduct = new Product();
            newProduct.Name = createProductDto.Name;
            newProduct.Price = createProductDto.Price;
            newProduct.Description = createProductDto.Description;
            newProduct.Amount = 1;
            seller.Products.Add(newProduct);
            ans.product = newProduct;
        }
        else
        {
            product.Description = createProductDto.Description;
            product.Price = createProductDto.Price;
            
            ans.product = product;
        }
        
        return ans;
    }

    public ProductsServiceResult<Guid>? UpdateProduct(UpdateProductDto updateProductDto)
    {
        var ans = new ProductsServiceResult<Guid>();
        foreach (var product in Products)
        {
            if (product.Name == updateProductDto.Name)
            {
                product.Amount = updateProductDto.Amount;
                product.Price = updateProductDto.Price;
                product.Description = updateProductDto.Description;
                ans.product = product.Id;
                
                var seller = FindAndOrAddSeller(product.SellerId);
                var productOfSeller = FindAndOrAddProduct(product.Name, seller);
                productOfSeller.Amount = product.Amount;
                productOfSeller.Price = product.Price;
                productOfSeller.Description = product.Description;
                
                return ans;
            }
        }

        return null;
    }

    public ProductsServiceResult<Product>? DeleteProduct(Guid productId)
    {
        var ans = new ProductsServiceResult<Product>();
        foreach (var product in Products)
        {
            if (product.Id == productId)
            {
                ans.product = product;
                
                var seller = FindAndOrAddSeller(product.SellerId);
                var productOfSeller = FindAndOrAddProduct(product.Name, seller);
                seller.Products.Remove(productOfSeller);
                
                return ans;
            }
        }

        return null;
    }

    int FindOrAddCart(Guid cartId)
    {
        for (int i = 0; i < Carts.Count; i++)
        {
            if (Carts[i].Id == cartId) return i;
        }
        
        Carts.Add(new Cart() { Id = cartId });
        return Carts.Count - 1;
    }

    void FindAndOrAddProduct(Guid productId, Cart cart)
    {
        foreach (var product in cart.Products)
        {
            if (product.Key == productId)
            {
                cart.Products[productId] = cart.Products[product.Key] + 1;
                return;
            }
        }
        
        
        cart.Products[productId] = 1;
    }
    
    Product FindAndOrAddProduct(string productName, Seller seller)
    {
        foreach (var product in seller.Products)
        {
            if (product.Name == productName)
            {
                return product;
            }
        }


        return null;
    }
    Seller FindAndOrAddSeller(Guid sellerId)
    {
        foreach (var seller in Sellers)
        {
            if (seller.Id == sellerId) return seller;
        }
        return null;
    }
    
}