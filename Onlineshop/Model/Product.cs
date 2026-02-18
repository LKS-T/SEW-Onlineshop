using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("PRODUCTS")]
public class Product
{
    [Column("PRODUCT_ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Column("NAME")]
    public string Name { get; set; }
    [Column("DESCRIPTION")]
    public string Description { get; set; }
    [Column("PRICE")]
    public decimal Price { get; set; }
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
}