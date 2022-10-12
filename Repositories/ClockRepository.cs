using Microsoft.EntityFrameworkCore;
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

            var today = DateTime.Now.Date;
            var clockExists = _appDbContext.clocks
                .Where(x => x.EmployeeId == clock.EmployeeId)
                .FirstOrDefault(c => c.ClockIn.Date == today);
                       

            if (clockExists == null)
            {
                clock.ClockIn = DateTime.Now;
                clock.ClockOut = null;
                clock.LunchIn = null;
                clock.LunchOut = null;
                clock.TotalHours = "";
                _appDbContext.clocks.Add(clock);
                _appDbContext.SaveChanges();

            }

        }

        public List<Clock> GetAll()
        {
            var clocks = _appDbContext.clocks.ToList();
            return clocks;
        }

        public List<Clock> GetClocksEmployee(int employeeId)
        {
            var groups = _appDbContext.clocks.Where(x => x.EmployeeId == employeeId);
            var clocks = new List<Clock>();
            foreach (var clock in groups)
            {
                clocks.Add(clock);

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
                else if (update == 1)
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

        public TimeSpan SumWorkTime(int id)
        {
            var clock = _appDbContext.clocks.FirstOrDefault(x => x.Id == id);
            if (clock != null)
            {
                TimeSpan firstPeriod = ((TimeSpan)(clock.ClockIn - clock.LunchIn));
                TimeSpan secondPeriod = ((TimeSpan)(clock.ClockOut - clock.LunchOut));
                var total = firstPeriod + secondPeriod;
                clock.TotalHours = total.Duration().ToString();
                _appDbContext.SaveChanges();
                return total.Duration();
            }
            return TimeSpan.Zero;

        }

    }
}
