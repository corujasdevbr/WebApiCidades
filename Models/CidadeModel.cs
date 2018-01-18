using System.ComponentModel.DataAnnotations;

namespace WebApiCidades.Models
{
    public class CidadeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Campo Nome deve ser informado")]
        [MinLength(3,ErrorMessage="Mínimo de 3 caracteres no campo Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo Estado deve ser informado")]
        [StringLength(2,ErrorMessage="Máximo de 2 caracteres no campo Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage="Campo Habitantes deve ser informado")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor do tipo inteiro no campo Habitantes")]
        public int Habitantes { get; set; }
    }
}