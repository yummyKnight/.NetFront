using System.Threading.Tasks;
using Client.Services.Contracts;
using Client2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client2.Controllers {
    public class ClientController : Controller {
        private IGenericServices<Models.Client> _services { get; }

        public async Task<IActionResult> ListClient() {
            return View(await _services.Get());
        }

        public async Task<IActionResult> InfoClient(int id) {
            return View(await _services.Get(id));
        }

        public async Task<IActionResult> AddClient() {
            return View(await _services.Get());
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Put(Models.Client model) {
            await this._services.Put(model);
            //Console.Out.WriteLine(doctor);
            return RedirectToAction("ListClient");
        }
    }
}

public class PaymentController : Controller {
    private IGenericServices<Payment> _services { get; }

    public async Task<IActionResult> PaymentList() {
        return View(await _services.Get());
    }

    public async Task<IActionResult> PaymentInfo(int id) {
        return View(await _services.Get(id));
    }

    public async Task<IActionResult> PaymentAdd() {
        return View(await _services.Get());
    }

    [HttpPost]
    public async Task<RedirectToActionResult> Put(Payment model) {
        await this._services.Put(model);
        //Console.Out.WriteLine(doctor);
        return RedirectToAction("PaymentList");
    }
}


public class BookingController : Controller {
    private IGenericServices<Booking> _services { get; }

    public async Task<IActionResult> BookingList() {
        return View(await _services.Get());
    }

    public async Task<IActionResult> BookingInfo(int id) {
        return View(await _services.Get(id));
    }

    public async Task<IActionResult> BookingAdd() {
        return View(await _services.Get());
    }

    [HttpPost]
    public async Task<RedirectToActionResult> Put(Booking model) {
        await this._services.Put(model);
        return RedirectToAction("BookingList");
    }
}


public class RoomController : Controller {
    private IGenericServices<Room> _services { get; }

    public async Task<IActionResult> RoomList() {
        return View(await _services.Get());
    }

    public async Task<IActionResult> RoomInfo(int id) {
        return View(await _services.Get(id));
    }

    public async Task<IActionResult> RoomAdd() {
        return View(await _services.Get());
    }

    [HttpPost]
    public async Task<RedirectToActionResult> Put(Room model) {
        await this._services.Put(model);
        //Console.Out.WriteLine(doctor);
        return RedirectToAction("RoomList");
    }
}