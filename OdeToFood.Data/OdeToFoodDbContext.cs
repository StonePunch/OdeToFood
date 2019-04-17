using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core
{
  public class OdeToFoodDbContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }

    public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
    {

    }
  }
}
