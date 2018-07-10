using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Wrox.ProCSharp.Entities
{
  class Program
  {
    static void Main(string[] args)
    {
      // CreateMenus().Wait();
      // QueryMenus();
      // EagerLoadingQuery();
      FillDatabase();

      // SameReference().Wait();
      // SameReference();
      //ChangeTracking();
      //UpdateMenus();
    }



    private static void SameReference()
    {
      try
      {
        using (var data = new MenuContext())
        {
          Menu m1 = (from m in data.Menus
                     where m.Text.StartsWith("New")
                     select m).FirstOrDefault();
          Menu m2 = (from m in data.Menus
                     where m.Price == 18.8m
                     select m).FirstOrDefault();



          //Menu m1 = await (from m in data.Menus
          //                 where m.Text.StartsWith("New")
          //                 select m).FirstOrDefaultAsync();
          //Menu m2 = await (from m in data.Menus
          //                 where m.Price == 18.8m
          //                 select m).FirstOrDefaultAsync();

          if (object.ReferenceEquals(m1, m2))
          {
            Console.WriteLine("the same object {0} {1}", m1.Id, m2.Id);
          }
          else
          {
            Console.WriteLine("not the same {0} {1}", m1.Id, m2.Id);
          }

        }
      }
      catch (Exception ex)
      {

        Console.WriteLine(ex.Message);
      }
    }

    private static void FillDatabase()
    {
      try
      {
        Database.SetInitializer<MenuContext>(new MenuCardsInitializer());
        using (var data = new MenuContext())
        {
          // data.Database.Initialize(force: true);

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
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      
    }

    private static void EagerLoadingQuery()
    {
      using (var data = new MenuContext())
      {
        data.Configuration.LazyLoadingEnabled = true;

        var q = data.MenuCards.Include("Menus");

        foreach (var card in q)
        {
          Console.WriteLine(card.Text);
          foreach (var menu in card.Menus)
          {
            Console.WriteLine("{0} {1}", menu.Text, menu.Price);
          }
        }
      }
    }

    private static void QueryMenus()
    {
      using (var data = new MenuContext())
      {
        data.Configuration.LazyLoadingEnabled = true;

        var q = data.MenuCards;

        foreach (var card in q)
        {
          Console.WriteLine(card.Text);
          foreach (var menu in card.Menus)
          {
            Console.WriteLine("{0} {1}", menu.Text, menu.Price);
          }
        }
      }
    }

    static async Task CreateMenus()
    {
      using (var data = new MenuContext())
      {
        MenuCard card1 = data.MenuCards.Create();
        card1.Text = "Soups";
        data.MenuCards.Add(card1);

        Menu m1 = data.Menus.Create();
        m1.Text = "Baked Potatoe Soup";
        m1.Price = 4.80M;
        m1.Day = new DateTime(2013, 8, 14);
        m1.MenuCard = card1;
        data.Menus.Add(m1);

        Menu m2 = data.Menus.Create();
        m2.Text = "Cheddar Broccoli Soup";
        m2.Price = 4.50M;
        m2.Day = new DateTime(2013, 8, 15);
        m2.MenuCard = card1;
        data.Menus.Add(m2);

        MenuCard card2 = data.MenuCards.Create();
        card2.Text = "Steaks";
        data.MenuCards.Add(card2);

        //List<Menu> menus = new List<Menu>();
        //Menu m3 = data.Menus.Create();
        //m3.Text = "";
        //m3.Price = 9.9M;
        //m3.Day = new DateTime()
        //menus.Add(
          

        try
        {
          int changed = await data.SaveChangesAsync();
          Console.WriteLine("{0} records updated", changed);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }

      }
    }
  }
}
