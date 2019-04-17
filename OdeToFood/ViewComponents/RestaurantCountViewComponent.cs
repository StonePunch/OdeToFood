using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
  public class RestaurantCountViewComponent : ViewComponent
  {
    private readonly IRestaurantData data;

    public IViewComponentResult Invoke()
    {
      int count = data.GetRestaurantCount();
      return View(count);
    }

    public RestaurantCountViewComponent(IRestaurantData data)
    {
      this.data = data;
    }
  }
}
