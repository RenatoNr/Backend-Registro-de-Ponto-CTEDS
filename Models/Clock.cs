namespace Registro_de_Ponto_CTEDS.Models
{
    public class Clock
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
      
    }
}
