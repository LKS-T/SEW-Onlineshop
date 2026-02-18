using Domain;
using Model;

namespace WebUi;

public class CheckoutHandler : ICheckoutHandler
{
    private Dictionary<Product,int> Products = new();
    public OrderRepository OrderRepository { get; set; }
    public CheckoutHandler()
    {
        OrderRepository = new OrderRepository(new OnlineShopContext());
    }
    public Dictionary<Product,int> GetProducts()
    {
        return Products;
    }

    public void AddProduct(Product p, int quantity)
    {
        if(!Products.ContainsKey(p))
            Products.Add(p, quantity);
        else
        {
            Products[p] += quantity;
        }
    }

    public void RemoveProduct(Product p)
    {
        Products.Remove(p);
    }

    public async Task CheckoutAsync()
    {
        List<OrderedProduct> orders = new();
        foreach (var product in Products)
        {
            orders.Add(new OrderedProduct()
            {
                Id = 0,
                OrderDate = DateTime.Now,
                ProductId = product.Key.ProductId,
                Quantity = product.Value
            });
        }
        await OrderRepository.CreateRangeAsync(orders);
        Products.Clear();
    }
}