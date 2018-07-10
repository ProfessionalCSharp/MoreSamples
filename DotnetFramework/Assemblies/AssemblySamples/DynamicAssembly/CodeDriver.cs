using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;


namespace Wrox.ProCSharp.Assemblies
{
  public class CodeDriver : MarshalByRefObject
  {
    private string prefix =
       "using System;" +
       "public static class Driver" +
       "{" +
       "   public static void Run()" +
       "   {";

    private string postfix =
       "   }" +
       "}";


    public string CompileAndRun(string input, out bool hasError)
    {
      hasError = false;
      string returnData = null;

      CompilerResults results = null;
      using (var provider = new CSharpCodeProvider())
      {
        var options = new CompilerParameters();
        options.GenerateInMemory = true;

        var sb = new StringBuilder();
        sb.Append(prefix);
        sb.Append(input);
        sb.Append(postfix);

        results = provider.CompileAssemblyFromSource(options, sb.ToString());
      }

      if (results.Errors.HasErrors)
      {
        hasError = true;
        var errorMessage = new StringBuilder();
        foreach (CompilerError error in results.Errors)
        {
          errorMessage.AppendFormat("{0} {1}", error.Line, error.ErrorText);
        }
        returnData = errorMessage.ToString();
      }
      else
      {
        TextWriter temp = Console.Out;
        var writer = new StringWriter();
        Console.SetOut(writer);
        Type driverType = results.CompiledAssembly.GetType("Driver");

        driverType.InvokeMember("Run", BindingFlags.InvokeMethod |
              BindingFlags.Static | BindingFlags.Public,
              null, null, null);
        
        Console.SetOut(temp);

        returnData = writer.ToString();
      }

      return returnData;
    }
  }
}
