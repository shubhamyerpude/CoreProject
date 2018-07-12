using CorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice.ViewModels
{
    public class HomeRestaurentViewModel
    {
        public IEnumerable<Restaurent> Restaurents { get; set; }
        public string CurrentMessage { get; set; }
    }
}
