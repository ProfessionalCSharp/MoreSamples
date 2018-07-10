
namespace Wrox.ProCSharp.Entities
{
  public partial class Racer
  {
    public override string ToString()
    {
      return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
  }
}
