using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIvenda.Context;
using API_Pagamentos.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIvenda.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VendedoresController: ControllerBase
    {
        private readonly PaymentContext _context;

        public VendedoresController(PaymentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Vendedores vendedor)
        {

            _context.Add(vendedor);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
            return Ok(vendedor);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
           
            var todosVendedores = _context.Vendedor;

            if (todosVendedores == null)
            {
                return NotFound();
            }
            return Ok(todosVendedores);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var delVendedor = _context.Vendedor.Find(id);

            if (delVendedor == null)
                return NotFound();

            _context.Vendedor.Remove(delVendedor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Vendedores vendedor)
        {
            var atualizaVendedor = _context.Vendedor.Find(id);

            if (atualizaVendedor == null)
                return NotFound();

            atualizaVendedor.NomeVendedor = vendedor.NomeVendedor;
            atualizaVendedor.VendedorCPF = vendedor.VendedorCPF;
            atualizaVendedor.VendedorEmail = vendedor.VendedorEmail;

            _context.Vendedor.Update(atualizaVendedor);
            _context.SaveChanges();
            return Ok(atualizaVendedor);
        }
    }
}
