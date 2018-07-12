using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice.Models;
using CorePractice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CorePractice.Pages
{
    public class EditModel : PageModel
    {
        private IRestaurentData _restaurentData;
        [BindProperty]
        public Restaurent Restaurent { get; set; }
        public EditModel(IRestaurentData restaurentData)
        {
            _restaurentData = restaurentData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurent = _restaurentData.Get(id);
            if (Restaurent == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _restaurentData.Edit(Restaurent);
                return RedirectToAction("Details", "Home", new { id = Restaurent.Id });
            }
            return Page();
        }
    }
}