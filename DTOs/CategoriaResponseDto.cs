using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancasApi.DTOs
{
    public class CategoriaResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}