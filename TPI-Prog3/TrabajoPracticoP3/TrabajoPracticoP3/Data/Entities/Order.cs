using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Payment { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now.ToUniversalTime();
        public string TotalPrize { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }

}