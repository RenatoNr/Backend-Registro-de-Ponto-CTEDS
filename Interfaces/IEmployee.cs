using Registro_de_Ponto_CTEDS.Models;

namespace Registro_de_Ponto_CTEDS.Interfaces
{
    public interface IEmployee
    {
        public Employee GetEmployeeByCpf(string cpf);
        public bool Login(string cpf, string password);
        public void RegisterClockIn();
        public void Create(Employee employee,IFormFile photo);
    }
}
