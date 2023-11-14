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

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }
        public Client? GetUserById(int userId)
        {
            return _context.Clients.FirstOrDefault(u => u.Id == userId);
        }
        public int CreateClient(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        //public void UpdateClient(User user)
        //{
        //    _context.Update(user);
        //    _context.SaveChanges();

        //}

        //public void DeleteClient(int userId)
        //{
        //    User userToDelete = _context.Users.FirstOrDefault(u => u.Id == userId);
        //    userToDelete.State = false;
        //    _context.Update(userToDelete);
        //    _context.SaveChanges();

        //}

    }
}
