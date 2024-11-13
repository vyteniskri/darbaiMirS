namespace Sporto_irangos_prekyba.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Sporto_irangos_prekyba.Repositories;
using Sporto_irangos_prekyba.Models;


/// <summary>
/// Controller for working with 'Automobilis' entity.
/// </summary>
public class MiestasController : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		var markes = MiestasRepo.List();
		return View(markes);
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var autoCE = new Miestas();

		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="autoCE">Entity model filled with latest data.</param>
	/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(Miestas autoCE)
	{
		//form field validation passed?
		if( ModelState.IsValid )
		{
			MiestasRepo.InsertMiestas(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}
		
		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var autoCE = MiestasRepo.Find(id);

		return View(autoCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>		
	/// <param name="autoCE">Entity model filled with latest data.</param>
	/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, Miestas autoCE)
	{
		//form field validation passed?
		if (ModelState.IsValid)
		{
			MiestasRepo.UpdateMiestas(autoCE);

			//save success, go back to the entity list
			return RedirectToAction("Index");
		}

		return View(autoCE);
	}

	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var autoEvm = MiestasRepo.Find(id);
		return View(autoEvm);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//try deleting, this will fail if foreign key constraint fails
		try 
		{
			MiestasRepo.DeleteMiestas(id);

			//deletion success, redired to list form
			return RedirectToAction("Index");
		}
		//entity in use, deletion not permitted
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;

			var autoCE = MiestasRepo.Find(id);
			return View("Delete", autoCE);
		}
	}
}
