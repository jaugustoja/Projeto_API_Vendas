using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pagamentos.Model
{
    public class Itens
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemNome { get; set; }
        public decimal PrecoItem { get; set; }
    }
}
