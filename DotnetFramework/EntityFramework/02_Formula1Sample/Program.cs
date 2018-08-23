using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Entities
{
  class Program
  {
    static void Main(string[] args)
    {
      // ShowRacers();
      // ShowRacersEagerLoading();
      // ShowRacersExplicitLoading();

      // EntityClientSample().Wait();
      // EntityClientSample2().Wait();

      // DbSqlQuerySample();
      // LinqToEntities1();
      // LinqToEntities2();
      // TrackingDemo();
      // ChangeInformation();
      // DetachingObjects();
      // SaveObjectsLastWins().Wait();
      DealWithUpdates().Wait();
    }

    private async static Task SaveObjectsLastWins()
    {
      Task t1 = Task.Run(() => UserSaveObjectLastWins("A", 1000, 211));
      Task t2 = Task.Run(() => UserSaveObjectLastWins("B", 2000, 212));
      await Task.WhenAll(t1, t2);
      ReadRecord();

    }

    private async static Task DealWithUpdates()
    {
      Task t1 = Task.Run(() => UserDealWithUpdates("A", 1000, 171));
      Task t2 = Task.Run(() => UserDealWithUpdates("B", 2000, 110));
      await Task.WhenAll(t1, t2);
      ReadRecord();
    }

    private static void ReadRecord()
    {

      using (var data = new Formula1Entities())
      {
        Racer r1 = data.Racers.Where(r => r.LastName == "Alonso").First();
        Console.WriteLine("after the update, the new value is {0}", r1.Starts);
      }
    }

    private async static Task UserSaveObjectLastWins(string user, int delay, int starts)
    {
      using (var data = new Formula1Entities())
      {
        int changes = 0;
        try
        {
          Racer r1 = data.Racers.Where(r => r.LastName == "Alonso").First();
          r1.Starts = starts;
          await Task.Delay(delay);
          changes = data.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
          Console.WriteLine("{0} error {1}", user, ex.Message);
        }
        Console.WriteLine("{0} changed {1} record(s)", user, changes);
      }
    }

    private async static Task UserDealWithUpdates(string user, int delay, int starts)
    {
      using (var data = new Formula1Entities())
      {
        int changes = 0;
        bool saveFailed = false;

        do
        {
          try
          {
            saveFailed = false;
            Racer r1 = data.Racers.Where(r => r.LastName == "Alonso").First();
            r1.Starts = starts;
            await Task.Delay(delay);
            changes = data.SaveChanges();
          }
          catch (DbUpdateConcurrencyException ex)
          {
            saveFailed = true;

            Console.WriteLine("{0} error {1}", user, ex.Message);
            foreach (var entry in ex.Entries)
            {
              DbPropertyValues currentValues = entry.CurrentValues;
              DbPropertyValues databaseValues = entry.GetDatabaseValues();
              DbPropertyValues resolvedValues = databaseValues.Clone();

              AskUser(currentValues, databaseValues, resolvedValues);

              entry.OriginalValues.SetValues(databaseValues);
              entry.CurrentValues.SetValues(resolvedValues);
            }
          }
        }
        while (saveFailed);

        Console.WriteLine("{0} changed {1} record(s)", user, changes);
      }
    }

    private static void AskUser(DbPropertyValues currentValues, DbPropertyValues databaseValues, DbPropertyValues resolvedValues)
    {
      foreach (string propertyName in currentValues.PropertyNames)
      {
          Console.WriteLine("{0}, current: {1}, database: {2}, proposed: {3}", propertyName, currentValues[propertyName], databaseValues[propertyName], resolvedValues[propertyName]);
      }
    }

    //private static void SaveObjects()
    //{
    //  using (var data = new Formula1Entities())
    //  {
    //    int changes = 0;
    //    try
    //    {
    //      changes += data.SaveChanges();
    //    }
    //    catch (OptimisticConcurrencyException ex)
    //    {
    //      data.ChangeTracker.Entries().First().re
    //      data.Refresh(RefreshMode.ClientWins, ex.StateEntries);
    //      changes += data.SaveChanges();
    //    }
    //    Console.WriteLine("{0} entities changed", changes);
    //    //...

    //            catch (DbUpdateConcurrencyException ex)
    //    {
    //        saveFailed = true;

    //        // Update original values from the database
    //        var entry = ex.Entries.Single();
    //        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
    //    }

    //          catch (DbUpdateConcurrencyException ex)
    //    {
    //        saveFailed = true;

    //        // Get the current entity values and the values in the database
    //        var entry = ex.Entries.Single();
    //        var currentValues = entry.CurrentValues;
    //        var databaseValues = entry.GetDatabaseValues();

    //        // Choose an initial set of resolved values. In this case we
    //        // make the default be the values currently in the database.
    //        var resolvedValues = databaseValues.Clone();

    //        // Have the user choose what the resolved values should be
    //        HaveUserResolveConcurrency(currentValues, databaseValues,
    //                                   resolvedValues);

    //        // Update the original values with the database values and
    //        // the current values with whatever the user choose.
    //        entry.OriginalValues.SetValues(databaseValues);
    //        entry.CurrentValues.SetValues(resolvedValues);
    //    }


    //  }

    //}

    private static void DetachingObjects()
    {
      using (var data = new Formula1Entities())
      {
        IQueryable<Racer> racers = data.Racers.Where(r => r.LastName == "Alonso").AsNoTracking();
        Racer fernando = racers.First();

        // Racer is detached and can be changed independent of the 
        // data context
        fernando.Starts++;

        ShowTrackedObjects("none tracked", data.ChangeTracker);

        //Racer originalObject = data.Racers.Find(fernando.Id);

        data.Racers.Attach(fernando);
        data.Entry<Racer>(fernando).State = EntityState.Modified;

        ShowTrackedObjects("fernando attached", data.ChangeTracker);

        //(data as IObjectContextAdapter).ObjectContext.ApplyCurrentValues("Racers", fernando);

        //ShowTrackedObjects("apply current", data.ChangeTracker);

        
      }

    }

    private static void ShowTrackedObjects(string title, DbChangeTracker tracker)
    {
      Console.WriteLine(title);
      foreach (var item in tracker.Entries<Racer>())
      {
        Console.WriteLine("{0}, state: {1}", item.Entity.LastName, item.State);
      }
      Console.WriteLine();
    }

    private static void ChangeInformation()
    {
      using (var data = new Formula1Entities())
      {
        var esteban = data.Racers.Create();
        esteban.FirstName = "Esteban";
        esteban.LastName = "Gutierrez";
        esteban.Nationality = "Mexico";
        esteban.Starts = 0;
        data.Racers.Add(esteban);

        Racer fernando = data.Racers.Where(r => r.LastName == "Alonso").First();
        fernando.Wins++;
        fernando.Starts++;

        foreach (DbEntityEntry<Racer> entry in data.ChangeTracker.Entries<Racer>())
        {
          Console.WriteLine("{0}, state: {1}", entry.Entity, entry.State);
          if (entry.State == EntityState.Modified)
          {
            Console.WriteLine("Original values");
            DbPropertyValues values = entry.OriginalValues;
            foreach (string propName in values.PropertyNames)
            {
              Console.WriteLine("{0} {1}", propName, values[propName]);
            }
            Console.WriteLine();
            Console.WriteLine("Current values");

            values = entry.CurrentValues;
            foreach (string propName in values.PropertyNames)
            {
              Console.WriteLine("{0} {1}", propName, values[propName]);
            }
          }

        }



      }
    }


    private static void TrackingDemo()
    {
      using (var data = new Formula1Entities())
      {
        Racer niki1 = (from r in data.Racers
                       where r.Nationality == "Austria" && r.LastName == "Lauda"
                       select r).First();
        Racer niki2 = (from r in data.Racers
                       where r.Nationality == "Austria"
                       orderby r.Wins descending
                       select r).First();
        if (Object.ReferenceEquals(niki1, niki2))
        {
          Console.WriteLine("the same object");
        }
      }

    }

    private static void LinqToEntities1()
    {
      using (Formula1Entities data = new Formula1Entities())
      {
        data.Database.Log = Console.Write;

        var racers = from r in data.Racers
                     where r.Wins > 40
                     orderby r.Wins descending
                     select r;
        foreach (Racer r in racers)
        {
          Console.WriteLine("{0} {1}", r.FirstName, r.LastName);
        }
      }
    }

    private static void LinqToEntities2()
    {
      using (var data = new Formula1Entities())
      {
        var query = from r in data.Racers
                    from rr in r.RaceResults
                    where rr.Position <= 3 && rr.Position >= 1 &&
                        r.Nationality == "Switzerland"
                    group r by r.Id into g
                    let podium = g.Count()
                    orderby podium descending
                    select new
                    {
                      Racer = g.FirstOrDefault(),
                      Podiums = podium
                    };
        foreach (var r in query)
        {
          Console.WriteLine("{0} {1} {2}", r.Racer.FirstName, r.Racer.LastName,
                            r.Podiums);
        }
      }

    }


    private static void DbSqlQuerySample()
    {
      using (Formula1Entities data = new Formula1Entities())
      {
        data.Database.Log = Console.Write;

        string country = "Brazil";
        // DbSqlQuery<Racer> racers = data.Racers.SqlQuery("SELECT * FROM Racers WHERE nationality = @country", new SqlParameter("country", country));
        DbSqlQuery<Racer> racers = data.Racers.SqlQuery("SELECT * FROM Racers WHERE nationality = @p0", country).AsNoTracking();

        foreach (var r in racers)
        {
          Console.WriteLine("{0} {1}", r.FirstName, r.LastName);
        }
      }
    }



    private static async Task EntityClientSample2()
    {
      string connectionString = ConfigurationManager.ConnectionStrings["Formula1Entities"].ConnectionString;
      var connection = new EntityConnection(connectionString);
      await connection.OpenAsync();
      EntityCommand command = connection.CreateCommand();
      command.CommandText =
        "SELECT Racers.FirstName, Racers.LastName FROM Formula1Entities.Racers";
      DbDataReader reader = await command.ExecuteReaderAsync(
          CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
      while (await reader.ReadAsync())
      {
        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
      }
      reader.Close();
    }

    private static async Task EntityClientSample()
    {
      string connectionString = ConfigurationManager.ConnectionStrings["Formula1Entities"].ConnectionString;
      var connection = new EntityConnection(connectionString);
      await connection.OpenAsync();
      EntityCommand command = connection.CreateCommand();
      command.CommandText = "[Formula1Entities].[Racers]";
      DbDataReader reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
      while (await reader.ReadAsync())
      {
        Console.WriteLine("{0} {1}", reader["FirstName"], reader["LastName"]);
      }
      reader.Close();

    }

    private static void ShowRacersExplicitLoading()
    {
      using (var data = new Formula1Entities())
      {
        // data.RaceResults.Load();
        foreach (var racer in data.Racers)
        {
          Console.WriteLine("{0} {1}", racer.FirstName, racer.LastName);

          DbCollectionEntry entry = data.Entry(racer).Collection("RaceResults");
          if (!entry.IsLoaded)
          {
            entry.Load();
          }
          DbCollectionEntry<Racer, RaceResult> entry1 = data.Entry(racer).Collection(r => r.RaceResults);
          if (!entry1.IsLoaded)
          {
            entry1.Load();
          }
          
          //if (!data.Entry(racer).Collection("RaceResults").IsLoaded)
          //{
          //  data.Entry(racer).Collection("RaceResults").Load();
          //}
          foreach (var raceResult in racer.RaceResults)
          {
            Console.WriteLine("\t{0} {1:d} {2}", raceResult.Race.Circuit.Name,
                raceResult.Race.Date, raceResult.Position);
          }
        }
      }
    }

    private static void ShowRacersEagerLoading()
    {
      using (var data = new Formula1Entities())
      {
        foreach (var racer in data.Racers.Include("RaceResults.Race.Circuit"))
        {
          Console.WriteLine("{0} {1}", racer.FirstName, racer.LastName);
          foreach (var raceResult in racer.RaceResults)
          {
            Console.WriteLine("\t{0} {1:d} {2}", raceResult.Race.Circuit.Name,
                raceResult.Race.Date, raceResult.Position);
          }
        }
      }
    }

    private static void ShowRacers()
    {
      using (var data = new Formula1Entities())
      {
        data.Database.Log = Console.WriteLine;

        foreach (var racer in data.Racers)
        {
          Console.WriteLine("{0} {1}", racer.FirstName, racer.LastName);

          foreach (var raceResult in racer.RaceResults)
          {
            Console.WriteLine("\t{0} {1:d} {2}", raceResult.Race.Circuit.Name,
                raceResult.Race.Date, raceResult.Position);
          }
        }
      }

    }
  }
}
