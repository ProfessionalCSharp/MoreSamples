using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Entities
{
  public class MenuCardsInitializer : DropCreateDatabaseAlways<MenuContext>
  {
    protected override void Seed(MenuContext context)
    {
      var menuCards = new List<MenuCard>()
      {
        new MenuCard{
          Text = "Soups",
          Menus = new List<Menu> {
            new Menu {
              Text = "Baked Potatoe Soup",
              Price = 4.8M,
              Day = DateTime.Parse("8/14/2013", CultureInfo.InvariantCulture)
            },
            new Menu {
              Text = "Cheddar Broccoli Soup",
              Price = 4.5M,
              Day = DateTime.Parse("8/15/2013", CultureInfo.InvariantCulture)
            }
          }
        },
        new MenuCard{
          Text = "Steaks",
          Menus = new List<Menu> {
            new Menu {
              Text = "New York Sirloin Steak",
              Price = 18.8M,
              Day = DateTime.Parse("8/16/2013", CultureInfo.InvariantCulture)
            },
            new Menu {
              Text = "Rib Eye Steak",
              Price = 14.8M,
              Day = DateTime.Parse("8/17/2013", CultureInfo.InvariantCulture)
            }
          }
        }
      };

      menuCards.ForEach(c => context.MenuCards.Add(c));
    }
  }
}
