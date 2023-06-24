using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry.Events
{
    [Serializable]
    public class Event
    {
        public Int32 _eventId;
        public long _timeStamp;
        
        public Dictionary<string, object> _data;
        public Event(Int32 eventId)
        {
            this._eventId = eventId;
            this._data = new Dictionary<string, object>();
            _timeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
             string evType=((EventType)(_eventId)).ToString(); //casts the enum to string to be used as a description of the event
            _data.Add("Event", evType);
            _data.Add("TimeStamp", _timeStamp);
   
    }
        public Int32 getEvent()
        {
            return _eventId;
        }
        public Dictionary<string, object> getData()
        {
            return _data;
        }
    }
}
