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
            _appDbContext.clocks.Add(clock);
            _appDbContext.SaveChanges();
        }

        public List<Clock> GetAll()
        {
            var clocks = _appDbContext.clocks.ToList();
            return clocks;
        }

        public List<Clock> GetClocksEmployee(int employeeId)
        {
            var groups = _appDbContext.clocks.GroupBy(x => x.EmployeeId == employeeId);
            var clocks = new List<Clock>();
            foreach(var group in groups)
            {
                
                foreach(var clock in group)
                {
                    clocks.Add(clock);
                }
            }
            if (clocks.Any())
            {
                return clocks;
            }

            return null;
        }
        public void UpdateTime(int Id, int update)
        {
            var updateclock = _appDbContext.clocks.FirstOrDefault(x => x.Id == Id);
        
            if (updateclock != null)
            {
                if (update == 0)
                {
                    updateclock.LunchIn = DateTime.Now;
                }
                else if(update == 1)
                {
                    updateclock.LunchOut = DateTime.Now;
                }
                else
                {
                    updateclock.ClockOut = DateTime.Now;
                }
                
                _appDbContext.SaveChanges();
            }
        }

    }
}
