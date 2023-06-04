using Microsoft.AspNetCore.Mvc;
using restapi_learn.Models;
using restapi_learn.Service;

namespace restapi_learn.Controllers
{
    public class PIzzaShopController : Controller
    {

        private readonly PizzaShopService _service;

        public PIzzaShopController(PizzaShopService service)
        {
            this._service = service;
        }


        public IActionResult Index()
        {
            ViewData["pizzalist"] = _service.GetAll();

            
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PizzaShop pizza)
        {
            if (ModelState.IsValid)
            {
                _service.Add(pizza);

                return RedirectToAction(nameof(Index));
            }

            return View(pizza);
        }
    }
}
