using My.API_Event.Models;
using System;
using System.Collections.Generic;

namespace My.API_Event.Repository
{
    public interface IEventRepository
    {
        void Add(Event @event);
        IEnumerable<Event> GetAll();
        Event Find(long id);
        IEnumerable<Event> FindDate(string date);
        void Remove(long id);
        void Update(Event @event);
    }
}
