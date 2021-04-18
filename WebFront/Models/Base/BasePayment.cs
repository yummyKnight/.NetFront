using System;
using Client2.Models;

namespace Client.Models.Base {
    public class BasePayment {
        public Booking Booking { get; set; }
        public uint Amount { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}