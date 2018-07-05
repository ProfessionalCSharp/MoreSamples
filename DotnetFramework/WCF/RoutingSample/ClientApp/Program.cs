using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("client - wait for services");
      Console.ReadLine();
      DemoService.DemoServiceClient service = new DemoService.DemoServiceClient();
      
      Console.WriteLine(service.GetData("HelloB"));
      Console.ReadLine();
    }
  }
}
