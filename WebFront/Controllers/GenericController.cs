using System.Threading.Tasks;
using Client.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using RedirectToRouteResult = System.Web.Mvc.RedirectToRouteResult;

// namespace Client.Controllers {
//     public class GenericController<TDomainModel> : Controller where TDomainModel : class {
//         private IGenericServices<TDomainModel> _services { get; }
//
//         public async Task<IActionResult> List() {
//             return View(await _services.Get());
//         }
//
//         public async Task<IActionResult> Info(int id) {
//             return View(await _services.Get(id));
//         }
//
//         public async Task<IActionResult> Add() {
//             return View(await _services.Get());
//         }
//
//         [HttpPost]
//         public async Task<RedirectToActionResult> Put(TDomainModel model) {
//             await this._services.Put(model);
//             //Console.Out.WriteLine(doctor);
//             return RedirectToAction("List");
//         }
//     }
// }