using BOTW.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BOTW.Controllers
{
  public class StylesController : Controller
  {
    private readonly BOTWContext _db;

    public StylesController(BOTWContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Styles.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Style style)
    {
      _db.Styles.Add(style);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisStyle = _db.Styles
          .Include(style => style.JoinEntries)
          .ThenInclude(join => join.Character)
          .FirstOrDefault(style => style.StyleId == id);
      return View(thisStyle);
    }

    public ActionResult Edit(int id)
    {
      var thisStyle = _db.Styles.FirstOrDefault(style => style.StyleId == id);
      ViewBag.CharacterId = new SelectList(_db.Characters, "CharacterId", "Name");
      return View(thisStyle);
    }

    [HttpPost]
    public ActionResult Edit(Style style)
    {
      _db.Entry(style).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStyle = _db.Styles.FirstOrDefault(style => style.StyleId == id);
      return View(thisStyle);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStyle = _db.Styles.FirstOrDefault(style => style.StyleId == id);
      _db.Styles.Remove(thisStyle);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}