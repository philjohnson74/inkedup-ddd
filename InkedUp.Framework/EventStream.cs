using System.Collections.Generic;
using Newtonsoft.Json;

namespace InkedUp.Framework
{
    public class EventStream
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public List<EventData> Events { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}