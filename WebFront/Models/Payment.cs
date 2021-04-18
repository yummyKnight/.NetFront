using Client.Models.Base;

namespace Client2.Models {
    public class Payment : BasePayment {
        public Payment(uint id) {
            Id = id;
        }

        public uint Id { get; }
    }
}