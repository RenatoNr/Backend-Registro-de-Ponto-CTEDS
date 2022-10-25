using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Interfaces
{
    public interface IWorkDay
    {
        public List<WorkDay> GetAll();
        public List<WorkDay> GetWorkDaysEmployee(int employeeId);
    }
}
