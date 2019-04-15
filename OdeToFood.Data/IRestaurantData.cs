using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
  public interface IRestaurantData
  {
    //IEnumerable<Restaurant> GetAll();

    IEnumerable<Restaurant> GetRestaurantsByName(string name);
  }

  public class InMemoryRestaurantData : IRestaurantData
  {
    private List<Restaurant> restaurants;

    //public IEnumerable<Restaurant> GetAll()
    //{
    //  return from r in restaurants
    //         orderby r.Name
    //         select r;
    //}

    public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
    {
      return from r in restaurants
             where
             string.IsNullOrEmpty(name) ||
             r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
             orderby r.Name
             select r;
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
