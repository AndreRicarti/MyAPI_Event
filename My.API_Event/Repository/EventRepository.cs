using System.Collections.Generic;
using System.Linq;
using My.API_Event.Models;

namespace My.API_Event.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly  EventDbContext eventDbContext;

        public EventRepository(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        public void Add(Event @event)
        {
            eventDbContext.Events.Add(@event);
            eventDbContext.SaveChanges();
        }

        public Event Find(long id)
        {
            return eventDbContext.Events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return eventDbContext.Events.ToList();
        }

        public void Remove(long id)
        {
            var entity = eventDbContext.Events.First(e => e.Id == id);
            eventDbContext.Events.Remove(entity);
            eventDbContext.SaveChanges();
        }

        public void Update(Event @event)
        {
            eventDbContext.Events.Update(@event);
            eventDbContext.SaveChanges();
        }
    }
}
