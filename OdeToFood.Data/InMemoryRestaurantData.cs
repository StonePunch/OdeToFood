using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
  public class InMemoryRestaurantData : IRestaurantData
  {
    private List<Restaurant> restaurants;

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in restaurants
             where
             string.IsNullOrEmpty(name) ||
             r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
             orderby r.Name
             select r;
    }

    public Restaurant GetRestaurantById(int id)
    {
      return (from r in restaurants
              where r.Id == id
              select r).FirstOrDefault();
    }

    public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
    {
      Restaurant restaurant = (from res in restaurants
                               where res.Id == updatedRestaurant.Id
                               select res).SingleOrDefault();

      if (restaurant == null)
        return null;

      restaurant.Name = updatedRestaurant.Name;
      restaurant.Location = updatedRestaurant.Location;
      restaurant.Cuisine = updatedRestaurant.Cuisine;

      return restaurant;
    }

    public bool Commit()
    {
      return true;
    }

    public Restaurant CreateRestaurant(Restaurant newRestaurant)
    {
      restaurants.Add(newRestaurant);
      newRestaurant.Id = restaurants.Max(restaurant => restaurant.Id) + 1;

      return newRestaurant;
    }

    public Restaurant DeleteRestaurant(int id)
    {
      Restaurant restaurant = restaurants.FirstOrDefault(res => res.Id == id);

      if (restaurant == null)
        return null;

      restaurants.Remove(restaurant);
      return restaurant;
    }

    public int GetRestaurantCount()
    {
      return restaurants.Count;
    }

    public InMemoryRestaurantData()
    {
      restaurants = new List<Restaurant>()
      {
        new Restaurant()
        {
          Id = 1,
          Name = "Joe's Grill House",
          Location = "address1",
          Cuisine = CuisineType.None
        },
        new Restaurant()
        {
          Id = 2,
          Name = "Los Hermanos",
          Location = "address2",
          Cuisine = CuisineType.Mexican
        },
        new Restaurant()
        {
          Id = 3,
          Name = "Rock Pizza",
          Location = "address3",
          Cuisine = CuisineType.Italian
        },
        new Restaurant()
        {
          Id = 4,
          Name = "Mojave Sun",
          Location = "address4",
          Cuisine = CuisineType.Mexican
        },
        new Restaurant()
        {
          Id = 5,
          Name = "Natraj Tandoori",
          Location = "address5",
          Cuisine = CuisineType.Indian
        },
      };
    }
  }
}
