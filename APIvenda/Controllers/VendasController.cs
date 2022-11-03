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
    public class VendasController : ControllerBase
    {
        private readonly PaymentContext _context;

        public VendasController(PaymentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Vendas venda)
        {

            //venda.ItemId = _context.Item.FirstOrDefault(i => i.ItemId == venda.ItemId).ItemId;
            _context.Add(venda);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
            return Ok(venda);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {

            var todasVendas = _context.Venda;

            if (todasVendas == null)
            {
                return NotFound();
            }
            return Ok(todasVendas);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Vendas venda)
        {
            var statusVenda = _context.Venda.Find(id);

            if (statusVenda == null)
                return NotFound();

            statusVenda.VendasStatus = venda.VendasStatus;

            _context.Venda.Update(statusVenda);
            _context.SaveChanges();
            return Ok(statusVenda);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var delVenda = _context.Venda.Find(id);

            if (delVenda == null)
                return NotFound();

            _context.Venda.Remove(delVenda);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
