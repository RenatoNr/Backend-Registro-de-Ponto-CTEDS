using Registro_de_Ponto_CTEDS.Context;
using Registro_de_Ponto_CTEDS.Interfaces;
using Registro_de_Ponto_CTEDS.Models;
using Registro_de_Ponto_CTEDS.Services;

namespace Registro_de_Ponto_CTEDS.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Employee employee)
        {
            //Usado somente para testes local
            //var photoPath = UploadPhotoService.SaveFile(photo);
            //employee.Photo = photoPath;
            var cpfexists = _context.employees.FirstOrDefault(c => c.Cpf == employee.Cpf);
            if (cpfexists == null)
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
            }
            
        }

        public Employee GetEmployeeByCpf(string cpf)
        {
            var employee = _context.employees.FirstOrDefault(e => e.Cpf == cpf);

            //if (employee != null)
            //{
            //    var today = DateTime.Now.Date;

            //    Clock todayClocks = employee.clocks.FirstOrDefault(c => c.ClockIn.Date == today);

            //    employee.clocks.Add(todayClocks);
            //}
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _context.employees.ToList();
        }

        public bool Login(string cpf, string password)
        {
            throw new NotImplementedException();
        }

        public void RegisterClockIn()
        {
            throw new NotImplementedException();
        }
    }
}
