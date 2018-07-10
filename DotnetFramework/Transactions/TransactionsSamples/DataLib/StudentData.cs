using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  public class StudentData
  {
    public async Task AddStudentAsync(Student student)
    {
      var connection = new SqlConnection(Properties.Settings.Default.CourseManagementConnectionString);
      await connection.OpenAsync();
      try
      {
        SqlCommand command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Students " +
              "(FirstName, LastName, Company) VALUES " +
              "(@FirstName, @LastName, @Company)";
        command.Parameters.AddWithValue("@FirstName", student.FirstName);
        command.Parameters.AddWithValue("@LastName", student.LastName);
        command.Parameters.AddWithValue("@Company", student.Company);

        await command.ExecuteNonQueryAsync();
      }
      finally
      {
        connection.Close();
      }
    }

    public async Task AddStudentAsync(Student student, Transaction tx)
    {
      // Contract.Requires<ArgumentNullException>(student != null);

      SqlConnection connection = new SqlConnection(
            Properties.Settings.Default.CourseManagementConnectionString);
      await connection.OpenAsync();
      try
      {
        if (tx != null) connection.EnlistTransaction(tx);

        SqlCommand command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Students (FirstName, LastName, Company) " +
              "VALUES (@FirstName, @LastName, @Company)";
        command.Parameters.AddWithValue("@FirstName", student.FirstName);
        command.Parameters.AddWithValue("@LastName", student.LastName);
        command.Parameters.AddWithValue("@Company", student.Company);

        await command.ExecuteNonQueryAsync();
      }
      finally
      {
        connection.Close();
      }
    }

  }
}

