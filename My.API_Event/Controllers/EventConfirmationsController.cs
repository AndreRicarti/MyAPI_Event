using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.API_Event.Models;

namespace My.API_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventConfirmationsController : ControllerBase
    {
        private readonly EventDbContext _context;

        public EventConfirmationsController(EventDbContext context)
        {
            _context = context;
        }

        readonly ApiError apiError = new ApiError()
        {
            Error = new Error()
        };

        // GET: api/EventConfirmations
        [HttpGet]
        public IEnumerable<EventConfirmation> GetEventConfirmations()
        {
            return _context.EventConfirmations;
        }

        // GET: api/EventConfirmations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventConfirmation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventConfirmation = await _context.EventConfirmations.FindAsync(id);

            if (eventConfirmation == null)
            {
                return NotFound();
            }

            return Ok(eventConfirmation);
        }

        // PUT: api/EventConfirmations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventConfirmation([FromRoute] int id, [FromBody] EventConfirmation eventConfirmation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventConfirmation.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventConfirmation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventConfirmationExists(id))
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

        // POST: api/EventConfirmations
        [HttpPost]
        public async Task<IActionResult> PostEventConfirmation([FromBody] EventConfirmation eventConfirmation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.EventConfirmations.Any(e => e.EventId == eventConfirmation.EventId && e.UserId == eventConfirmation.UserId))
            {
                apiError.Error = new Error
                {
                    Code = Convert.ToInt16(StatusCodes.Status422UnprocessableEntity).ToString(),
                    Message = "Esse evento já esta confirmado para esse usuário."
                };

                return StatusCode(StatusCodes.Status422UnprocessableEntity, apiError);
            }

            if (eventConfirmation.EventId != 0)
            {
                eventConfirmation.@event = null;
            }

            if (eventConfirmation.UserId != 0)
            {
                eventConfirmation.User = null;
            }

            _context.EventConfirmations.Add(eventConfirmation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventConfirmation", new { id = eventConfirmation.Id }, eventConfirmation);
        }

        // DELETE: api/EventConfirmations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventConfirmation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventConfirmation = await _context.EventConfirmations.FindAsync(id);
            if (eventConfirmation == null)
            {
                return NotFound();
            }

            _context.EventConfirmations.Remove(eventConfirmation);
            await _context.SaveChangesAsync();

            return Ok(eventConfirmation);
        }

        private bool EventConfirmationExists(int id)
        {
            return _context.EventConfirmations.Any(e => e.Id == id);
        }
    }
}