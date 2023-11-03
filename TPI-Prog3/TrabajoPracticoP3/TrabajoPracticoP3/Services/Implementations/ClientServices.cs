using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class ClientServices : IClientServices
    {
        private readonly Context _context;

        public ClientServices(Context context)
        {
            _context = context;
        }

        public List<Order> SendOrders()  //COMO HACER EL CLIENT DTO PARA QUE ENVIE UNA ORDEN
        {
            return _context.Orders.ToList();
        }

        public List<Order> ModifyOrder()
        {
            return _context.Orders.ToList();
        }

    }
}
