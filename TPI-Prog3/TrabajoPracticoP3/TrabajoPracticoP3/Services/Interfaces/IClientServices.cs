using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IClientServices
    {
        public List<Client> GetClients();
        public User GetUserById(int userId);

        public int CreateClient(User user);
        //public void UpdateClient(Client user);
        //public void DeleteUser(int userId);

    }
}
