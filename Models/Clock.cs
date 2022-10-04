using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_de_Ponto_CTEDS.Models
{
    public class Clock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; } 
        public DateTime? LunchIn { get; set; }
        public DateTime? LunchOut { get; set; }    
        public string TotalHours { get; set; }
      
    }
}
