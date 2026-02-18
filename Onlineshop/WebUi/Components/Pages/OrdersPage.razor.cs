using Microsoft.AspNetCore.Components;
using Model;

namespace WebUi.Components.Pages;

public partial class OrdersPage : ComponentBase
{
    private Dictionary<DateTime,Product> _products = new ();
    protected async override Task OnInitializedAsync()
    {
        var orders = await OrderRepository.ReadAsync();
        foreach (var order in orders)
        {
            var product = await ProductRepository.ReadAsync(order.ProductId);
            _products.Add(order.OrderDate, product);
        }
    }
}