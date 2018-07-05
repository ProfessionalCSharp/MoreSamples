using System;

namespace Wrox.ProCSharp.Assemblies
{
  public class CodeDriverInAppDomain
  {
    public string CompileAndRun(string code, out bool hasError)
    {
      AppDomain codeDomain = AppDomain.CreateDomain("CodeDriver");

      CodeDriver codeDriver = (CodeDriver)
            codeDomain.CreateInstanceAndUnwrap("DynamicAssembly",
                  "Wrox.ProCSharp.Assemblies.CodeDriver");

      string result = codeDriver.CompileAndRun(code, out hasError);

      AppDomain.Unload(codeDomain); 

      return result;
    }
  }

}
