using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IAdminServices
    {
        public List<Product> AddProduct();
        public List<Product> DeleteProduct();

        public List<Product> EditProduct();

    }
}
