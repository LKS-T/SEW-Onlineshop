using Microsoft.AspNetCore.Components;
using Model;

namespace WebUi.Components.Pages;

public partial class Home : ComponentBase
{
    // Liste zum befüllen:
    public List<Product> Products { get; set; }
    public int Quantity { get; set; }
    protected async override Task OnInitializedAsync()
    {
        Products = await ProductRepository.ReadAsync();
    }

    private void AddProduct(Product p)
    {
        CheckoutHandler.AddProduct(p, Quantity);
        StateHasChanged();
    }
}