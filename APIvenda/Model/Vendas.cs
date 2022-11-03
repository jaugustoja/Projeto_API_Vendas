using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API_Pagamentos.Model;

namespace API_Pagamentos.Model
{
    public class Vendas
    {
        [Key]
        public int VendasId { get; set; }
        public Itens Item { get; set; }
        public int ItemId { get; set; }
        public Vendedores Vendedor { get; set; }
        public string VendasStatus { get; set; }
    }

  
}
