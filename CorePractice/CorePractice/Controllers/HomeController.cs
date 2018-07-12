using CorePractice.Models;
using CorePractice.Services;
using CorePractice.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CorePractice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurentData _restaurent;
        private IGreeter _greeter;

        public HomeController(IRestaurentData restaurent, IGreeter greeter)
        {
            _restaurent = restaurent;
            _greeter = greeter;
         }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeRestaurentViewModel();
            model.Restaurents = _restaurent.GetAll();
            model.CurrentMessage = _greeter.GetResponseMessage();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurent.Get(id);
            return View(model);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurent restaurent)
        {
            if (ModelState.IsValid)
            {
                restaurent = _restaurent.Add(restaurent);
                return RedirectToAction(nameof(Details), new { id = restaurent.Id });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _restaurent.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
