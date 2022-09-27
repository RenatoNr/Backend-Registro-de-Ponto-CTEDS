namespace Registro_de_Ponto_CTEDS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string EmployeePost { get; set; }
        public string Password { get; set; }
        public string? Photo { get; set; }
        public ICollection<Clock>? clocks { get; set; }

    }
}
