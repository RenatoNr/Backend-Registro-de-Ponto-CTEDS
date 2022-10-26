
using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using BC = BCrypt.Net.BCrypt;

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
            string passwordHash = BC.HashPassword(user.Password);
            user.Password = passwordHash;
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

        public bool Login(string cpf, string password)
        {
            var user = GetUser(cpf);
            if (user != null)
            {
                var dbHashedPassword = user.Password;
                var result = BC.Verify(password, dbHashedPassword);

                if (result)
                {
                    return true;

                }
               return false;
            }

            return false;
        }
    }
}
