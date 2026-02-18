using Model;

namespace Domain;

public class ProductRepository : ARepository<Product>
{
    public ProductRepository(OnlineShopContext context) : base(context){}
}