using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Pagamentos.Model;

namespace APIvenda.Context
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }

        public DbSet<Itens> Item { get; set; }
        public DbSet<Vendas> Venda { get; set; }
        public DbSet<Vendedores> Vendedor { get; set; }

    }
}