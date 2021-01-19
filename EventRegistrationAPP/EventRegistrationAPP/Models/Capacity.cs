using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationAPP.Models
{
    public class Capacity
    {
        public string CapacityId { get; set; }
        public string EventId { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string EventHours { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public object UpdatedBy { get; set; }
        public object UpdatedDate { get; set; }
    }
}
