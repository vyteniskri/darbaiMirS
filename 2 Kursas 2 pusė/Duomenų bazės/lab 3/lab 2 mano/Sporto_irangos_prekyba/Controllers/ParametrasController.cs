namespace Sporto_irangos_prekyba.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Sporto_irangos_prekyba.Repositories;
using Sporto_irangos_prekyba.Models.Parametras;

public class ParametrasController : Controller
{
    [HttpGet]
	public ActionResult Index()
	{
		return View(ParametrasRepo.ListParametras());
	}

    [HttpGet]
	public ActionResult Create()
	{
		var autoCE = new ParametrasCE();
		PopulateSelections(autoCE);

		return View(autoCE);
	}

    [HttpPost]
	public ActionResult Create(ParametrasCE autoCE)
	{
		//form field validation passed?
		if( ModelState.IsValid )
		{
			ParametrasRepo.InsertParametras(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}
		
		//form field validation failed, go back to the form
		PopulateSelections(autoCE);
		return View(autoCE);
	}

    [HttpGet]
	public ActionResult Edit(int id)
	{
		var autoCE = ParametrasRepo.FindParametras(id);
		PopulateSelections(autoCE);

		return View(autoCE);
	}

    [HttpPost]
	public ActionResult Edit(int id, ParametrasCE autoCE)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			ParametrasRepo.UpdateParametras(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		//form field validation failed, go back to the form
		PopulateSelections(autoCE);
		return View(autoCE);
	}

    [HttpGet]
	public ActionResult Delete(int id)
	{
		var autoEvm = ParametrasRepo.FindParametras(id);
		return View(autoEvm);
	}

    [HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			ParametrasRepo.DeleteParametras(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var autoCE = ParametrasRepo.FindParametras(id);
			PopulateSelections(autoCE);

			return View("Delete", autoCE);
		}
	}

    public void PopulateSelections(ParametrasCE autoCE)
    {
        var medziagos = ParametrasRepo.ListMedziagosTipas();
        var spalvos = ParametrasRepo.ListSpalva();

        autoCE.Lists.Medziagos =
            medziagos.Select(it => {
				return
					new SelectListItem() { 
						Value = Convert.ToString(it.Id),
						Text = it.Pavadinimas 
					};
			})
			.ToList();

        autoCE.Lists.Spalvos =
            spalvos.Select(it => {
				return
					new SelectListItem() { 
						Value = Convert.ToString(it.Id),
						Text = it.Pavadinimas 
					};
			})
			.ToList();
        
    }
}