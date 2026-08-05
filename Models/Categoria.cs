using System.ComponentModel.DataAnnotations;

namespace FinancasApi.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Tipo é um campo obrigatório")]
        public string Tipo { get; set; }
    }
}