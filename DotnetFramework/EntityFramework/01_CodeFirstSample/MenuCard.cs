using System.Collections.Generic;

namespace Wrox.ProCSharp.Entities
{
  public class MenuCard
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public virtual ICollection<Menu> Menus { get; set; }
  }
}
