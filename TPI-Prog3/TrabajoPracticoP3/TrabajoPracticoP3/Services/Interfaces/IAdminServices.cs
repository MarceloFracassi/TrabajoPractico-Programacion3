using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IAdminServices
    {
        public int AddProduct(Product product);
        public void DeleteProduct(int productId);

        public void EditProduct(Product product);
        public Product GetProductById (int productId);


    }
}
