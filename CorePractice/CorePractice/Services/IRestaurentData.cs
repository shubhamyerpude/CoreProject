using CorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice.Services
{
    public interface IRestaurentData
    {
        IEnumerable<Restaurent> GetAll();
        Restaurent Get(int id);
        Restaurent Add(Restaurent restaurent);
        void Delete(int id);
        Restaurent Edit(Restaurent restaurent);
    }
}
