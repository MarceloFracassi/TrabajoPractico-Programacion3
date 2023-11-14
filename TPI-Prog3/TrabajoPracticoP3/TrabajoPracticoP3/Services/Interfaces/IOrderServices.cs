using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IOrderServices
    {
        public Order GetOrder(int id);

        public int AddOrder(Order order);
    }
}
