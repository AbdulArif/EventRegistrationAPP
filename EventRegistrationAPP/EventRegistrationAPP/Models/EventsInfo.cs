using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationAPP.Models
{
    public class EventsInfo
    {
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventHours { get; set; }
        public string SpecialInstructions { get; set; }
        public string AddBy { get; set; }
        public DateTime AddDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
