using Model;

namespace Domain;

public class OrderRepository : ARepository<OrderedProduct>
{
    public OrderRepository(OnlineShopContext context) : base(context){}
}