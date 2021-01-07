using BOTW.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BOTW.Controllers
{
  public class LocationsController : Controller
  {
    private readonly BOTWContext _db;

    public LocationsController(BOTWContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Locations.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Location location)
    {
      _db.Locations.Add(location);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisLocation = _db.Locations
          .Include(location => location.JoinEntries)
          .ThenInclude(join => join.Character)
          .FirstOrDefault(location => location.LocationId == id);
      return View(thisLocation);
    }

    public ActionResult Edit(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      ViewBag.CharacterId = new SelectList(_db.Characters, "CharacterId", "Name"); 
      return View(thisLocation);
    }

    [HttpPost]
    public ActionResult Edit(Location location)
    {
      _db.Entry(location).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      return View(thisLocation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
      _db.Locations.Remove(thisLocation);
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