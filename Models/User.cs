using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_de_Ponto_CTEDS.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string  Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
