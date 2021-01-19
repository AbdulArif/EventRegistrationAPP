using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationAPP.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; }
        public string CapacityId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int SeatsBooked { get; set; }
        public string Comments { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public object UpdatedBy { get; set; }
        public object UpdatedDate { get; set; }
    }
}
