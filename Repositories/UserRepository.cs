using Microsoft.EntityFrameworkCore;
using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Repositories
{
    public class UserRepository: IUser
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

       public void Create(User user)
        {
            _appDbContext.users.Add(user);
            _appDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            var users = _appDbContext.users.ToList();         
            return users;
        }

        public void DeleteUser(string cpf)
        {
            var user = _appDbContext.users.FirstOrDefault(x => x.Cpf == cpf);
            if (user != null)
            {
                _appDbContext.users.Remove(user);
                _appDbContext.SaveChanges();
            }
        }

        public User? GetUser(string cpf)
        {
            var user = _appDbContext.users.FirstOrDefault(x => x.Cpf == cpf);
            if (user != null)
            {
                return user;
            }

            return null;
        }
    }
}
