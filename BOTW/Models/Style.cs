using System.Collections.Generic;

namespace BOTW.Models
{
  public class Style
  {
    public Style()
    {
      this.JoinEntries = new HashSet<CharacterLocationStyle>(); // part of the constructor
    }

    public int StyleId { get; set; } // definitions of properties
    public string Name { get; set; }
    public bool Owned { get; set; } 
    public virtual ICollection<CharacterLocationStyle> JoinEntries { get; set; }
    static public ICollection<Style> StyleList { get; set; }
  }
}