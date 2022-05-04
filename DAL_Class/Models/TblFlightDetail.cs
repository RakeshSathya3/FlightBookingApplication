using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Class.Models
{
    public partial class TblFlightDetail
    {
        public int FlightId { get; set; }
        public string AirlineName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TicketCost { get; set; }
        public int? Bcseats { get; set; }
        public int? Nbcseats { get; set; }
    }
}
