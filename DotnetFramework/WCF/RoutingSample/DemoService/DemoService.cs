using System;

namespace Wrox.ProCSharp.WCF
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  public class DemoService : IDemoService
  {
    public static string Server { get; set; }

    public string GetData(string value)
    {
      string message = string.Format("Message from {0}, You entered: {1}", Server, value);
      Console.WriteLine(message);
      return message;
    }


  }
}
