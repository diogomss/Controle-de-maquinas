using ControleMaquinas.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleMaquinas.models
{
    public class MaquinaModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public LocalizaçãoEnum Localização { get; set; }

        public StatusEnum Status { get; set; }
    }
}
