using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice.Models;

namespace CorePractice.Services
{
    public class RestaurentData : IRestaurentData
    {
        List<Restaurent> _restaurents;
        public RestaurentData()
        {
            _restaurents = new List<Restaurent>()
            {
                new Restaurent()
                {
                    Id = 1,
                    Name = "Bavarchi Restaurent",
                    City = "Hyderabad",
                    ContactNumber = +91-8484848488
                },
                new Restaurent()
                {
                    Id = 2,
                    Name = "Melting Pot Restaurent",
                    City = "Hyderabad",
                    ContactNumber = +91-8989898989
                },
                new Restaurent()
                {
                    Id = 3,
                    Name = "Divakar Meal Restaurent",
                    City = "Bangalore",
                    ContactNumber = +91-9696969696
                }
            };
        }

        public Restaurent Add(Restaurent restaurent)
        {
            restaurent.Id = _restaurents.Max(a => a.Id) + 1;
            _restaurents.Add(restaurent);
            return restaurent;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurent Edit(Restaurent restaurent)
        {
            throw new NotImplementedException();
        }

        public Restaurent Get(int id)
        {
            var model = _restaurents.FirstOrDefault(a => a.Id == id);
            return model;
        }

        public IEnumerable<Restaurent> GetAll()
        {
            var model = _restaurents.OrderBy(a => a.Name);
            return model;
        }
    }
}
