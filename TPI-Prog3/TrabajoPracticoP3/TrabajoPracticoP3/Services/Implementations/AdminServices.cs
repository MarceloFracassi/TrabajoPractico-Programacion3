using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;
using static TrabajoPracticoP3.Services.Implementations.AdminServices;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class AdminServices : IAdminServices
    {

        private readonly Context _context;

        public AdminServices(Context context)
        {
         _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(int productId)
        {
            Product productToDelete = _context.Products.FirstOrDefault(u => u.Id == productId);
            productToDelete.State = false;
            _context.Update(productToDelete);
            _context.SaveChanges();

        }
        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void EditProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
