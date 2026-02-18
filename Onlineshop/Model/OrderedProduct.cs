using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

[Table("ORDERED_PRODUCTS")]
public class OrderedProduct
{
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("PRODUCT_ID")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [Column("QUANTITY")]
    public int Quantity { get; set; }
    [Column("ORDER_DATE")]
    public DateTime OrderDate { get; set; }
}