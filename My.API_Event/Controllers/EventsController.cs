using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My.API_Event.Models;
using My.API_Event.Repository;

namespace My.API_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return eventRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var @event = eventRepository.Find(id);

            if (@event == null)
                return NotFound();

            return new ObjectResult(@event);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Event @event)
        {
            if (@event == null)
                return BadRequest();

            eventRepository.Add(@event);

            return CreatedAtRoute("GetUsuario", new { id = @event.Id }, @event);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
