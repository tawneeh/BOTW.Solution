using BOTW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BOTW.Controllers
{
  public class CharactersController : Controller
  {
    private readonly BOTWContext _db;
    public CharactersController(BOTWContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Character> model = _db.Characters.ToList();
      return View(_db.Characters.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Character Character)
    {
      _db.Characters.Add(Character);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCharacter = _db.Characters //this is called a stream. streams let you enumerate over all of the items in a collection. thisCharacter is a set until other things are called on it. but since you're calling these other things it is just the culmination of all of them at once.
        .Include(character => character.JoinEntries) // (character => character.JoinEntries) this is a lambda function, a nameless method, to the left of the equals is what the method takes, to the right of the equals is what the method does. item can be whatever (x, a, y.)
        // include function iterates over the dbCharacters set, character is an individual character in the set, this will call categories on every item in the database and load them into the individual item in the lambda object. 
        // this returns a collection of join entities, which is the collection of relationships between the item and the categores, as defined by the categoryItems table in the database 
        // a collection is an object that contains other typed objects, and offers some specific methods on how to access them. 
        // in this case, the join entities are CharacterLocationStyle Objects.
        .ThenInclude(join => join.Location) //join should really be CharacterLocationStyle.
        .Include(character => character.JoinEntries)
        .ThenInclude(join => join.Style)
        .FirstOrDefault(character => character.CharacterId == id); //specifies which particular character to run these commands on / filter list by
      return View(thisCharacter);
    }

    public ActionResult Edit(int id)
    {
      var thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
      ViewBag.Styles = _db.Styles.ToList();
      return View(thisCharacter);
    }

    [HttpPost]
    public ActionResult Edit(Character Character, List<int> styles)
    {
      if (styles.Count != 0)
      {
        foreach(int style in styles)
        {
        _db.CharacterLocationStyle.Add(new CharacterLocationStyle() { StyleId = style, CharacterId = Character.CharacterId });
        }
      }
      _db.Entry(Character).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult AddStyle(int id)
    // {
    //   var thisCharacter = _db.Characters.FirstOrDefault(CharactersController => CharactersController.CharacterId == id);
    //   ViewBag.StyleId = new SelectList(_db.Styles, "StyleId", "Name");
    //   return View(thisCharacter);
    // }

    // [HttpPost]
    // public ActionResult AddStyle(Character character, int StyleId)
    // {
    //   if (StyleId != 0)
    //   {
    //     _db.CharacterLocationStyle.Add(new CharacterLocationStyle() { StyleId = StyleId, CharacterId = character.CharacterId });
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    public ActionResult AddLocation(int id)
    {
      var thisCharacter = _db.Characters.FirstOrDefault(CharactersController => CharactersController.CharacterId == id);
      ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
      return View(thisCharacter);
    }

    [HttpPost]
    public ActionResult AddLocation(Character character, int LocationId)
    {
      if (LocationId != 0)
      {
        _db.CharacterLocationStyle.Add(new CharacterLocationStyle() { LocationId = LocationId, CharacterId = character.CharacterId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
      return View(thisCharacter);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCharacter = _db.Characters.FirstOrDefault(character => character.CharacterId == id);
      _db.Characters.Remove(thisCharacter);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      var joinEntry = _db.CharacterLocationStyle.FirstOrDefault(entry => entry.CharacterLocationStyleId == joinId);
      _db.CharacterLocationStyle.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}