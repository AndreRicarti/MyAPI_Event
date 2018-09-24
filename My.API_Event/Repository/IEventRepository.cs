using My.API_Event.Models;
using System.Collections.Generic;

namespace My.API_Event.Repository
{
    public interface IEventRepository
    {
        void Add(Event @event);
        IEnumerable<Event> GetAll();
        Event Find(long id);
        void Remove(long id);
        void Update(Event @event);
    }
}
