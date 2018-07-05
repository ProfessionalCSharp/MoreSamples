using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Transactions
{
  public class CourseData
  {
    public async Task AddCourseAsync(Course course)
    {
      SqlConnection connection = new SqlConnection(
            Properties.Settings.Default.CourseManagementConnectionString);
      SqlCommand courseCommand = connection.CreateCommand();
      courseCommand.CommandText =
            "INSERT INTO Courses (Number, Title) VALUES (@Number, @Title)";
      await connection.OpenAsync();

      SqlTransaction tx = connection.BeginTransaction();

      try
      {
        courseCommand.Transaction = tx;

        courseCommand.Parameters.AddWithValue("@Number", course.Number);
        courseCommand.Parameters.AddWithValue("@Title", course.Title);
        await courseCommand.ExecuteNonQueryAsync();

        tx.Commit();
      }
      catch (Exception ex)
      {
        Trace.WriteLine("Error: " + ex.Message);
        tx.Rollback();
        throw;
      }
      finally
      {
        connection.Close();
      }
    }
  }

}
