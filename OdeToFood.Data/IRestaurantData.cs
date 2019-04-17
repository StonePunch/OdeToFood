using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
  public interface IRestaurantData
  {
    IEnumerable<Restaurant> GetRestaurantsByName(string name);

    Restaurant GetRestaurantById(int id);

    Restaurant UpdateRestaurant(Restaurant updatedRestaurant);

    Restaurant CreateRestaurant(Restaurant newRestaurant);

    bool DeleteRestaurant(int id);

    bool Commit();
  }
}
