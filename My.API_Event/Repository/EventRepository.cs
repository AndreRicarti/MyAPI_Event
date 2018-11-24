using System;
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

        public IEnumerable<Event> FindDate(string date)
        {
            DateTime dateInicial = DateTime.ParseExact(date + " 00:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime dateFinal = DateTime.ParseExact(date + " 23:59:59", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

            return eventDbContext.Events.Where(e => e.DateStart > dateInicial && e.DateStart < dateFinal).OrderBy(e => e.DateStart).ToList();
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
