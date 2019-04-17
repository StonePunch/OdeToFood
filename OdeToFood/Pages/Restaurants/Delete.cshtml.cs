using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.Restaurants
{
  public class DeleteModel : PageModel
  {
    private readonly IRestaurantData data;

    public Restaurant Restaurant{ get; set; }

    public IActionResult OnGet(int id)
    {
      Restaurant = data.GetRestaurantById(id);

      if (Restaurant == null)
        return RedirectToPage("./NotFound");

      return Page();

    }

    public IActionResult OnPost(int id)
    {
      Restaurant restaurant = data.DeleteRestaurant(id);

      if (restaurant == null)
        return RedirectToPage("./NotFound");

      data.Commit();

      TempData["Message"] = string.Format("{0} deleted", restaurant.Name);
      return RedirectToPage("./List");
    }

    public DeleteModel(IRestaurantData data)
    {
      this.data = data;
    }
  }
}