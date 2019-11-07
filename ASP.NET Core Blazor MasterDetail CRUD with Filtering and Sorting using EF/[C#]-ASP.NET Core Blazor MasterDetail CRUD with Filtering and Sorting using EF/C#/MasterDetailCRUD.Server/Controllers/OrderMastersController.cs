using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterDetailCRUD.Shared.Models;

namespace MasterDetailCRUD.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderMasters")]
    public class OrderMastersController : Controller
    {
        OrderManagementContext _context = new OrderManagementContext();

        // GET: api/OrderMasters
        [HttpGet]
        public IEnumerable<OrderMasters> GetOrderMasters()
        {
            return _context.OrderMasters;
        }

        // GET: api/OrderMasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderMasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMasters = await _context.OrderMasters.SingleOrDefaultAsync(m => m.OrderNo == id);

            if (orderMasters == null)
            {
                return NotFound();
            }

            return Ok(orderMasters);
        }

        // PUT: api/OrderMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMasters([FromRoute] int id, [FromBody] OrderMasters orderMasters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderMasters.OrderNo)
            {
                return BadRequest();
            }

            _context.Entry(orderMasters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMastersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderMasters
        [HttpPost]
        public async Task<IActionResult> PostOrderMasters([FromBody] OrderMasters orderMasters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderMasters.Add(orderMasters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMasters", new { id = orderMasters.OrderNo }, orderMasters);
        }

        // DELETE: api/OrderMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderMasters = await _context.OrderMasters.SingleOrDefaultAsync(m => m.OrderNo == id);
            if (orderMasters == null)
            {
                return NotFound();
            }

            _context.OrderMasters.Remove(orderMasters);
            await _context.SaveChangesAsync();

            return Ok(orderMasters);
        }

        private bool OrderMastersExists(int id)
        {
            return _context.OrderMasters.Any(e => e.OrderNo == id);
        }
    }
}