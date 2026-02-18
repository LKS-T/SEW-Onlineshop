using Model;

namespace WebUi;

public interface ICheckoutHandler
{
    Dictionary<Product,int> GetProducts();
    void AddProduct(Product p, int quantity);
    void RemoveProduct(Product p);
    void UpdateQuantity(Product p, int quantity);
    Task CheckoutAsync();
}
