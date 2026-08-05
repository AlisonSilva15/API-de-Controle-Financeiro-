using System.ComponentModel.DataAnnotations;

namespace FinancasApi.Models
{
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Valor é um campo obrigatório")]
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }

    }
}