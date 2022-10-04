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

        public void Create(Employee employee, IFormFile photo)
        {
           var photoPath =  UploadPhotoService.SaveFile(photo);
            employee.Photo = photoPath;
            
            _context.employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeByCpf(string cpf)
        {
            var employee = _context.employees.FirstOrDefault(e => e.Cpf == cpf);
            return employee;
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
