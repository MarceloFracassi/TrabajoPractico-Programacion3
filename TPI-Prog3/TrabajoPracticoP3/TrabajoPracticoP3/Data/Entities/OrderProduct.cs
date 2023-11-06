using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Entities
{
    public class OrderProduct
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [ForeignKey("OrderId")]
            public int OrderId { get; set; }

            [ForeignKey("ProductId")]
            public int ProductId { get; set; }
            public Product Product { get; set; }
            public int ProductQuntity { get; set; }
        }
    }


