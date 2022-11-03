using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pagamentos.Model
{
    public class Vendedores  
    {
        [Key]
        public int VendedorId { get; set; }
        public string NomeVendedor { get; set; }
        public string VendedorCPF { get; set; }
        public string VendedorEmail { get; set; }
        
    }
}
