using Microsoft.EntityFrameworkCore;
using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using Registro_de_Ponto_CTEDS.Services;
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

        public Clock GetTodayClock(int employeeId)
        {
            var today = DateTime.Now.Date.Day;
            var clocks = _appDbContext.clocks
                .Where(x => x.EmployeeId == employeeId)
                .FirstOrDefault(c => c.ClockIn.Date.Day == today);

            // .FirstOrDefault<Clock>(x => x.ClockIn.Date == today);
            return clocks;
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

        public string GetMissWorkDay()
        {
           
           VerifyAllEmployeeMissWorkDay();

            return "Verificação de faltas executada com sucesso.";
        }

        private void VerifyAllEmployeeMissWorkDay()
        {
            var today = DateTime.Now.Date;
            var employees = _appDbContext.employees.ToList();

            if (employees.Count != 0)
            {
                foreach (var employee in employees)
                {
                    SaveMissWorkDay(employee.Id);
                }
            }
        }

        private void SaveMissWorkDay(int Id)
        {
            var getDayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var today = DateTime.Now.Date;

            var user = _appDbContext.clocks.Where(x => x.EmployeeId == Id).FirstOrDefault(c => c.ClockOut == today);

            if (getDayOfWeek == "Saturday" || getDayOfWeek == "Sunday" || user != null)
            {
                return;
            }

            var missWorkDayExist = _appDbContext.workdays.Where(e => e.EmployeeId == Id).FirstOrDefault(x => x.MissWorDate == today);

            if (missWorkDayExist != null)
            {
                return;
            }

            WorkDay workDay = new WorkDay();
            workDay.EmployeeId = Id;
            workDay.MissWorDate = today;

            _appDbContext.Add(workDay);
            _appDbContext.SaveChanges();

        }


    }
}
