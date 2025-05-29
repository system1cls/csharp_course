using App.practice4;

namespace App.practice6;

public interface ICartsService
{
    public Product DeleteProductFromCartAsync(Guid cartId, Guid productId);  
    public void ChangeProductAmountAsync(Guid cart, Guid product, int delta);  

}