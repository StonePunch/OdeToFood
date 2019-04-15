using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.Restaurants
{
  public class ListModel : PageModel
  {
    private readonly IConfiguration configuration;
    private readonly IRestaurantData restaurantData;

    public string Message { get; set; }
    public IEnumerable<Restaurant> Restaurants { get; set; }

    public void OnGet(string searchBox)
    {
      Message = configuration["Message"];
      Restaurants = restaurantData.GetRestaurantsByName(searchBox);
    }

    public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
    {
      this.configuration = configuration;
      this.restaurantData = restaurantData;
    }
  }
}