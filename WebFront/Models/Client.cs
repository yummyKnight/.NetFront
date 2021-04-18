using Client.Models.Base;

namespace Client2.Models {
    public class Client : BaseClient {
        public Client(int id) {
            Id = id;
        }

        public int Id { get; }

        public Client() {
        }
    }
}