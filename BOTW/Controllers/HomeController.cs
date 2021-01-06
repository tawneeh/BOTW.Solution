using Microsoft.AspNetCore.Mvc;

namespace BOTW.Controllers
{
  public class HomeController : Controller 
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View(); 
    }
  }
}