using Client.Models.Base;

namespace Client2.Models {
    public class Booking : BaseBooking {
        public Booking(int id) {
            Id = id;
        }

        public int? Id { get; set; }
    }
}