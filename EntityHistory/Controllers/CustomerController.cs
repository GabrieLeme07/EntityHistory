using EntityHistory.Data;
using EntityHistory.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EntityHistory.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly HistoryDbContext _context;

        public CustomerController(HistoryDbContext context)
        {
            _context = context; 
        }

        [HttpPost]
        [Route("api/customer/adicionar")]
        public async Task<ActionResult> Adicionar()
        {
            var customer = new Customer();
            customer.FirstName = "João";
            customer.LastName = "Da Silva";
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        [Route("api/customer/editar/{id}")]
        public async Task<ActionResult> Editar(int Id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == Id);
            customer.LastName = "Soares";
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("api/customer/deletar/{id}")]
        public async Task<ActionResult> Deletar(int Id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == Id);
             _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
