using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.Restaurants
{
  public class EditModel : PageModel
  {
    private readonly IRestaurantData data;
    private readonly IHtmlHelper helper;

    [BindProperty]
    public Restaurant Restaurant { get; set; }
    public IEnumerable<SelectListItem> Cuisines { get; set; }

    public IActionResult OnGet(int? id)
    {
      Cuisines = helper.GetEnumSelectList<CuisineType>();

      if (id.HasValue)
      {
        Restaurant = data.GetRestaurantById(id.Value);

        if (Restaurant == null)
          return RedirectToPage("./NotFound");

      }
      else
      {
        Restaurant = new Restaurant();
      }
      return Page();
    }

    public IActionResult OnPost()
    {
      Cuisines = helper.GetEnumSelectList<CuisineType>();

      if (!ModelState.IsValid)
        return Page();

      string toastMessage = "";
      if (Restaurant.Id == default(int))
      {
        data.CreateRestaurant(Restaurant);
        toastMessage = "Restaurant Created!";
      }
      else
      {
        data.UpdateRestaurant(Restaurant);
        toastMessage = "Restaurant Updated!";
      }
       
      if (!data.Commit())
        return Page();

      TempData["Message"] = toastMessage;
      return RedirectToPage("./Detail", new { id = Restaurant.Id });
    }

    public EditModel(IRestaurantData data, IHtmlHelper helper)
    {
      this.data = data;
      this.helper = helper;
    }
  }
}