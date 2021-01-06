using System.Collections.Generic;

namespace BOTW.Models
{
  public class Style
  {
    public Style()
    {
      this.JoinEntries = new HashSet<CharacterLocationStyle>();
    }

    public int StyleId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CharacterLocationStyle> JoinEntries { get; set; }
  }
}