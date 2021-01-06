using System.Collections.Generic;

namespace BOTW.Models
{
  public class Location
  {
    public Location()
    {
      this.JoinEntries = new HashSet<CharacterLocationStyle>();
    }

    public int LocationId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CharacterLocationStyle> JoinEntries { get; set; }
  }
}