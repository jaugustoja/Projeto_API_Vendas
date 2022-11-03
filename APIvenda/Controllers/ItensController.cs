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
    public class ItensController: ControllerBase
    {
        
         private readonly PaymentContext _context;

        public ItensController(PaymentContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult Criar(Itens item)
        {

            _context.Add(item);
            _context.SaveChanges();
            //return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
            return Ok(item);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            
            var todosItens = _context.Item;

            if (todosItens == null)
            {
                return NotFound();
            }
            return Ok(todosItens);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Itens item)
        {
            var itemBanco = _context.Item.Find(id);

            if (itemBanco == null)
                return NotFound();

            itemBanco.ItemNome = item.ItemNome;
            itemBanco.PrecoItem = item.PrecoItem;

            _context.Item.Update(itemBanco);
            _context.SaveChanges();
            return Ok(itemBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var delItem = _context.Item.Find(id);

            if (delItem == null)
                return NotFound();

            _context.Item.Remove(delItem);
            _context.SaveChanges();
            return NoContent();
        }        

    }
}
