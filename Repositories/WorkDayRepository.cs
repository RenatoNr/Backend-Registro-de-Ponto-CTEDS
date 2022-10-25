using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Repositories
{
    public class WorkDayRepository:IWorkDay

    {
        private AppDbContext _appDbContext;

        public WorkDayRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public List<WorkDay> GetAll()
        {
            var workdays = _appDbContext.workdays.ToList();
            return workdays;
        }

        public List<WorkDay> GetWorkDaysEmployee(int employeeId)
        {
            var groups = _appDbContext.workdays.Where(x => x.EmployeeId == employeeId);
            var workdays = new List<WorkDay>();
            foreach (var workDay in groups)
            {
                workdays.Add(workDay);

            }
            if (workdays.Any())
            {
                return workdays;
            }

            return null;
        }

    }
}
