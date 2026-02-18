using Microsoft.AspNetCore.Components;
using Model;

namespace WebUi.Components.Pages;

public partial class Home : ComponentBase
{
    // Liste zum befüllen:
    public List<Product> Products { get; set; }
}