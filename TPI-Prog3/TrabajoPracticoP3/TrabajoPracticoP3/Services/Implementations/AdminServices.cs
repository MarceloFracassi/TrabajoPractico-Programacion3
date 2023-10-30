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

        public List<Product> AddProduct() 
        {
            return _context.Products.ToList();
        }

        public List<Product> DeleteProduct()
        {
            return _context.Products.ToList();
        }

        public List<Product> EditProduct()
        {
            return _context.Products.ToList();
        }
    }
}
