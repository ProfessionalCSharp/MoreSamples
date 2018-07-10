using System;
using System.ComponentModel.DataAnnotations;

namespace Wrox.ProCSharp.Entities
{
  public class Menu
  {
    public int Id { get; set; }
    [StringLength(50)]
    public string Text { get; set; }
    public decimal Price { get; set; }
    public DateTime? Day { get; set; }
    public MenuCard MenuCard { get; set; }
    public int MenuCardId { get; set; }
  }
}
