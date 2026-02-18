using Microsoft.AspNetCore.Components;
using Model;

namespace WebUi.Components.Components;

public partial class ProductComponent : ComponentBase
{
    [Parameter]
    public Product Product { get; set; }
}