using System;
using Client2.Models;

namespace Client.Models.Base {
    public class BaseBooking {
        public global::Client2.Models.Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime ReservedDay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime? CanceledAt { get; set; }
    }
}