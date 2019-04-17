using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
  public class SqlRestaurantData : IRestaurantData
  {
    private readonly OdeToFoodDbContext db;

    public bool Commit()
    {
      if (db.SaveChanges() > 0)
        return true;

      return false;
    }

    public Restaurant CreateRestaurant(Restaurant newRestaurant)
    {
      db.Add(newRestaurant);
      return newRestaurant;
    }

    public bool DeleteRestaurant(int id)
    {
      Restaurant restaurant = GetRestaurantById(id);

      if (restaurant == null)
        return false;

      db.Restaurants.Remove(restaurant);
      return true;
    }

    public Restaurant GetRestaurantById(int id)
    {
      return db.Restaurants.Find(id);
    }

    public IEnumerable<Restaurant> GetRestaurantsByName(string name)
    {
      return from res in db.Restaurants
             where 
             string.IsNullOrEmpty(name) || 
             res.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
             orderby res.Name
             select res;
    }

    public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
    {
      EntityEntry entity = db.Restaurants.Attach(updatedRestaurant);
      entity.State = EntityState.Modified;

      //Restaurant restaurant = (from res in db.Restaurants
      //                         where res.Id == updatedRestaurant.Id
      //                         select res)
      //                         .SingleOrDefault();

      //if (restaurant == null)
      //  return null;

      //restaurant.Name = updatedRestaurant.Name;
      //restaurant.Location = updatedRestaurant.Location;
      //restaurant.Cuisine = updatedRestaurant.Cuisine;

      return updatedRestaurant;
    }

    public SqlRestaurantData(OdeToFoodDbContext db)
    {
      this.db = db;
    }
  }
}
