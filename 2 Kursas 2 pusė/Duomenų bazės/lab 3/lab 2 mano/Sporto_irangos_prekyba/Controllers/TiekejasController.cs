namespace Sporto_irangos_prekyba.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Sporto_irangos_prekyba.Repositories;
using Sporto_irangos_prekyba.Models;

public class TiekejasController : Controller
{
    [HttpGet]
	public ActionResult Index()
	{
		return View(TiekejasRepo.List());
	}

    [HttpGet]
	public ActionResult Create()
	{
		var tiek = new Tiekejas();
		return View(tiek);
	}

    [HttpPost]
	public ActionResult Create(Tiekejas tiek)
	{
		var match = TiekejasRepo.Find(tiek.Id);

		if( match !=null )
		{
            ModelState.AddModelError("Id", "Field value already exists in database.");
        }

		if (ModelState.IsValid)
		{
			
			TiekejasRepo.Insert(tiek);

			
			return RedirectToAction("Index");
		}
		
		return View(tiek);
	}

    [HttpGet]
	public ActionResult Edit(int id)
	{
		return View(TiekejasRepo.Find(id));
	}

    [HttpPost]
	public ActionResult Edit(int id, Tiekejas tiek)
	{
		
		if (ModelState.IsValid)
		{
			TiekejasRepo.Update(tiek);

			return RedirectToAction("Index");
		}

		return View(tiek);
	}

    [HttpGet]
	public ActionResult Delete(int id)
	{
		var darb = TiekejasRepo.Find(id);
		return View(darb);
	}

    [HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		try 
		{
			TiekejasRepo.Delete(id);

			return RedirectToAction("Index");
		}
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			ViewData["deletionNotPermitted"] = true;

			var tiek = TiekejasRepo.Find(id);
			return View("Delete", tiek);
		}
	}
}