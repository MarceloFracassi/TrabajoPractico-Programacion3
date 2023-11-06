using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Price { get; set; }

   

        /*[ForeignKey("ModifiedByAdminId")]   ///FALTA LA RELACION ADMIN PRODUCT EN CONTEXT CON MIGRACION, NO NOS SALIO. PREGUNTAR.
        public int ModifiedByAdminId { get; set; }

        // Administrador que modificó este producto
        public Admin ModifiedByAdmin { get; set; }*/
    }
}
