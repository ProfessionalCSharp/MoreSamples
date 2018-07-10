using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrox.ProCSharp.Entities.Migrations;

namespace Wrox.ProCSharp.Entities
{
  class Program
  {
    static void Main(string[] args)
    {
      MigrationDemo();
    }

    private static void MigrationDemo()
    {
      // Package Manager Console Commands:
      // Enable-Migrations
      // Add-Migration AddMenuSubtitle
      // Update-Database –Verbose 
      Database.SetInitializer<MenuContext>(new MigrateDatabaseToLatestVersion<MenuContext, Configuration>());
      using (var data = new MenuContext())
      {
        foreach (var card in data.MenuCards)
        {
          Console.WriteLine(card.Text);
          foreach (var menu in card.Menus)
          {
            Console.WriteLine("\t{0} {1:C}", menu.Text, menu.Price);
          }
        }
      }
    }
  }
}
