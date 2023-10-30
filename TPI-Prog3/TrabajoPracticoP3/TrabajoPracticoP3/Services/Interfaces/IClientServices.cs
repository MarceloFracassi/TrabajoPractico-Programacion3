using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IClientServices
    {
        public List<Order> SendOrders();
        public List<Order> ModifyOrder();
    }
}
