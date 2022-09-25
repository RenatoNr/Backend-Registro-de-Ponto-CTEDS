using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using BC = BCrypt.Net.BCrypt;

namespace Registro_de_Ponto_CTEDS.Repositories
{
    public class ClockRepository : IClock
    {
        private AppDbContext _appDbContext;
        public ClockRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Create(Clock clock)
        {
            _appDbContext.users.Add(clock);
            _appDbContext.SaveChanges();
        }

        public List<Clock> GetAll()
        {
            var clocks = _appDbContext.clocks.ToList();
            return clocks;
        }

        public List<Clock> GetClocksEmployee(string employeeId)
        {
            var clocks = _appDbContext.clocks.Where(x => x.EmployeeId == employeeId);
            if (clocks != null)
            {
                return clocks;
            }

            return null;
        }
        public void UpdateTime(int Id, int update)
        {
            var updateclock = context.Products.FirstOrDefault(x => x.Id == Id);
        
            if (entity != null)
            {
                if (update == 0)
                {
                    updateclock.LunchIn = DateTime.Now();
                }
                else if(update == 1)
                {
                    updateclock.LunchOut = DateTime.Now();
                }
                else
                {
                    updateclock.ClockOut = DateTime.Now();
                }
                
                context.SaveChanges();
            }
        }

    }
}
