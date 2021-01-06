namespace BOTW.Models
{
  public class CharacterLocationStyle
  {
    public int CharacterLocationStyleId { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    public int? LocationId { get; set; }
    public Location Location { get; set; }
    public int? StyleId { get; set; }
    public Style Style { get; set; }
  }
}