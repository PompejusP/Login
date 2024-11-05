using Microsoft.AspNetCore.Mvc;
using Web_FIA44_Login.ViewModels;

namespace Web_FIA44_Login.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			string SessionInhalt = HttpContext.Session.GetString("LoggedIn");
			if (SessionInhalt != null)
			{
				ViewBag.SessionInhalt = DateTime.Parse(SessionInhalt);
			}
			return View();
		}
		public IActionResult Oeffentlich()
		{
			return View();
		}
		public IActionResult Intern()
		{
			// Überprüfen, ob der Benutzer angemeldet ist
			string SessionInhalt = HttpContext.Session.GetString("LoggedIn");
			// Wenn der Benutzer nicht angemeldet ist, wird er auf die Login-Seite weitergeleitet
			if (SessionInhalt == null)
			{
				return RedirectToAction("Login");
			}
			// Wenn der Benutzer angemeldet ist, wird die Seite "Intern" angezeigt
			ViewBag.SessionInhalt = DateTime.Parse(SessionInhalt);
			return View();
		}
		public IActionResult Login(LoginViewModel model)
		{
			// Überprüfen, ob die Eingaben korrekt sind
			if (!ModelState.IsValid)
			{
				return View();
					}
			// Überprüfen, ob der Benutzername und das Passwort korrekt sind
			if (model.Username.ToUpper() == "ADMIN" && model.Password.ToUpper() == "ADMIN")
			{
				// Wenn der Benutzername und das Passwort korrekt sind, wird eine Session gestartet
				string SessionInhalt = DateTime.Now.ToString();
				// Der Benutzer wird auf die Seite "Intern" weitergeleitet
				HttpContext.Session.SetString("LoggedIn", SessionInhalt);
				// Der Benutzer wird auf die Seite "Intern" weitergeleitet
				return RedirectToAction("Intern");
			}
			//Ansonsten wird der Benutzer auf die Index-Seite weitergeleitet
			else
			{
				return RedirectToAction("Index");
			}	
		}
		public IActionResult Logout()
		{
			// Die Session wird beendet
			HttpContext.Session.Remove("LoggedIn");
			// Der Benutzer wird auf die Index-Seite weitergeleitet
			return RedirectToAction("Index");
		}
	}
}
