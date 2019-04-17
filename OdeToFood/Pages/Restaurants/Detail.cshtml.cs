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
  public class DetailModel : PageModel
  {
    private readonly IRestaurantData data;

    public Restaurant Restaurant { get; set; }

    [TempData]
    public string Message { get; set; }

    public IActionResult OnGet(int id)
    {
      Restaurant = data.GetRestaurantById(id);

      if (Restaurant == null)
        return RedirectToPage("./NotFound");

      return Page();
    }

    public DetailModel(IRestaurantData data)
    {
      this.data = data;
    }
  }
}