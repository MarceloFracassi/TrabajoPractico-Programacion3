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

        public List<Order> SendOrders()   //Copie y pegue lo de pablo con nuestros metodos, hay que ver si es asi
        {
            return _context.Orders.ToList();
        }

        public List<Order> ModifyOrder()
        {
            return _context.Orders.ToList();
        }

    }
}
