using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice.Data;
using CorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace CorePractice.Services
{
    public class DatabaseRestaurant : IRestaurentData
    {
        private DataContext _restaurant;

        public DatabaseRestaurant(DataContext restaurant)
        {
            _restaurant = restaurant;
        }
        public Restaurent Add(Restaurent restaurent)
        {
            //_restaurant.Restaurents.Add(restaurent);
            //_restaurant.SaveChanges();
            //return restaurent;
            //var result = _restaurant.Database.ExecuteSqlCommand("spInsertion @Name, @City, @ContactNumber", parameters: new[] {
            //    restaurent.Name,
            //    restaurent.City,
            //    restaurent.ContactNumber.ToString()
            //});
            Restaurent result = _restaurant.Set<Restaurent>().FromSql("spInsertion @Name={0} ,@City ={1}, @ContactNumber={2}", restaurent.Name, restaurent.City, restaurent.ContactNumber).Single();
            return result;
        }

        public void Delete(int id)
        {
            var restaurant = _restaurant.Restaurents.SingleOrDefault(a => a.Id == id);
            _restaurant.Restaurents.Remove(restaurant);
            _restaurant.SaveChanges();
        }

        public Restaurent Edit(Restaurent restaurent)
        {
            _restaurant.Attach(restaurent).State = EntityState.Modified;
            _restaurant.SaveChanges();
            return restaurent;
        }

        public Restaurent Get(int id)
        {
            return _restaurant.Restaurents.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Restaurent> GetAll()
        {
            var restaurant = _restaurant.Restaurents.OrderBy(a => a.Name);
            return restaurant;
        }
    }
}
