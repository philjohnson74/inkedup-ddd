using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace InkedUp.Framework
{
    public abstract class Entity<TId> where TId : IEquatable<TId>
    {
        private readonly List<object> _events;

        protected Entity() => _events = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _events.Add(@event);
        }

        protected void LoadEventStream(EventStream eventStream)
        {
            foreach (var eventData in eventStream.Events)
            {
                var dataType = Type.GetType(eventData.Type);
                var jsonData = Encoding.UTF8.GetString(eventData.Data);
                var data = JsonConvert.DeserializeObject(jsonData, dataType);
                
                //  Add the event to the entities local cache of events
                _events.Add(data);
                
                //  Apply the event
                When(data);
            }
        }

        protected abstract void When(object @event);

        public IEnumerable<object> GetChanges() => _events.AsEnumerable();

        public void ClearChanges() => _events.Clear();
        
        protected abstract void EnsureValidState();
    }
}