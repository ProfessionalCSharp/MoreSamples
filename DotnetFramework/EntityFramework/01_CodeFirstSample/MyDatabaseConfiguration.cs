using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace Wrox.ProCSharp.Entities
{
  class MyDatabaseConfiguration : DbConfiguration
  {
    public MyDatabaseConfiguration()
    {
      // this.SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());

    }
  }

}
