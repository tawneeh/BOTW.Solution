using System.Collections.Generic;

namespace BOTW.Models
{
  public class Character
  {
    public Character()
    {
      this.JoinEntries = new HashSet<CharacterLocationStyle>();
    }

    public int CharacterId { get; set; }
    public string Name { get; set; }
    public ICollection<CharacterLocationStyle> JoinEntries { get; }
  }
}