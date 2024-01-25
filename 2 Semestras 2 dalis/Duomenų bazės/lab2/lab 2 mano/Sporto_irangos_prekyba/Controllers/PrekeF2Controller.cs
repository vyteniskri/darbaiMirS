namespace Sporto_irangos_prekyba.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Sporto_irangos_prekyba.Repositories;
using Sporto_irangos_prekyba.Models.PrekeF2;

public class PrekeF2Controller : Controller
{
    [HttpGet]
	public ActionResult Index()
	{
		return View(PrekeF2Repo.ListPreke());
	}

    [HttpGet]
	public ActionResult Create()
	{
		var sutCE = new PrekeCE();
		
		PopulateLists(sutCE);

		return View(sutCE);
	}

    [HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, PrekeCE sutCE)
	{

        int date = DateTime.Now.Year * 1000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new PrekeCE.PrekesKainaM {
					InListId =
						sutCE.PrekiuKainos.Count > 0 ?
						sutCE.PrekiuKainos.Max(it => it.InListId) + 1 :
						0,

					GaliojaNuo = DateTime.Now,
					GaliojaIki = DateTime.Now,
					Kaina = 0
				};
			sutCE.PrekiuKainos.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sutCE.PrekiuKainos =
				sutCE
					.PrekiuKainos
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for( var i = 0; i < sutCE.PrekiuKainos.Count-1; i ++ )
			{
				var refUp = sutCE.PrekiuKainos[i];

				for( var j = i+1; j < sutCE.PrekiuKainos.Count; j++ )
				{
					var testUp = sutCE.PrekiuKainos[j];
					
					if( testUp.GaliojaNuo == refUp.GaliojaNuo )
						ModelState.AddModelError($"PrekiuKainos[{j}].GaliojaNuo", "Duplicate of another added service.");
				}
			}

			//form field validation passed?
			if( ModelState.IsValid )
			{

				//create new 'Sutartis'
				sutCE.Preke.Prekes_id = PrekeF2Repo.InsertPreke(sutCE);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in sutCE.PrekiuKainos )
					PrekeF2Repo.InsertPrekesKaina(sutCE.Preke.Prekes_id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			
				PopulateLists(sutCE);
				return View(sutCE);
			
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

    [HttpGet]
	public ActionResult Edit(int id)
	{
		var sutCE = PrekeF2Repo.FindPrekeCE(id);
		
		sutCE.PrekiuKainos = PrekeF2Repo.ListPrekesKaina(id);			
		PopulateLists(sutCE);

		return View(sutCE);
	}

    [HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, PrekeCE sutCE)
	{
        int date = DateTime.Now.Year * 1000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new PrekeCE.PrekesKainaM {
					InListId =
						sutCE.PrekiuKainos.Count > 0 ?
						sutCE.PrekiuKainos.Max(it => it.InListId) + 1 :
						0,

					GaliojaNuo = DateTime.Now,
					GaliojaIki = DateTime.Now,
					Kaina = 0
				};
			sutCE.PrekiuKainos.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

        //removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sutCE.PrekiuKainos =
				sutCE
					.PrekiuKainos
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sutCE);
			return View(sutCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for( var i = 0; i < sutCE.PrekiuKainos.Count-1; i ++ )
			{


				var refUp = sutCE.PrekiuKainos[i];

				for( var j = i+1; j < sutCE.PrekiuKainos.Count; j++ )
				{
					var testUp = sutCE.PrekiuKainos[j];
					
					if( testUp.GaliojaNuo == refUp.GaliojaNuo )
						ModelState.AddModelError($"PrekiuKainos[{j}].GaliojaNuo", "Duplicate of another added service.");
				}
			}

			//form field validation passed?
			if( ModelState.IsValid )
			{
				//update 'Sutartis'
				PrekeF2Repo.UpdatePreke(sutCE);
                
                PrekeF2Repo.DeletePrekesKainaForPreke(sutCE.Preke.Prekes_id);
                

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in sutCE.PrekiuKainos )
				{
					
            		PrekeF2Repo.InsertPrekesKaina(sutCE.Preke.Prekes_id, upVm);

				}		

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(sutCE);
				return View(sutCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

    [HttpGet]
	public ActionResult Delete(int id)
	{
		var sutCE = PrekeF2Repo.FindPrekeCE(id);
		return View(sutCE);
	}

    [HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//load 'Sutartis'
		var sutCE = PrekeF2Repo.FindPrekeCE(id);

		//'Sutartis' is in the state where deletion is permitted?
        try
        {
			PrekeF2Repo.DeletePrekesKainaForPreke(id);
			PrekeF2Repo.DeletePreke(id);

			//redired to list form
			return RedirectToAction("Index");
        }
		catch( MySql.Data.MySqlClient.MySqlException )
		{
			//enable explanatory message and show delete form
			ViewData["deletionNotPermitted"] = true;
			return View("Delete", sutCE);
		}
	}

    private void PopulateLists(PrekeCE sutCE)
    {
        var tiekejai = TiekejasRepo.List();
        var parametrai = ParametrasRepo.ListParametras();

        sutCE.Lists.Tiekejai =
			tiekejai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = $"{it.Id} - {it.Pavadinimas}"
						};
				})
				.ToList();
        sutCE.Lists.Parametrai =
			parametrai
				.Select(it =>
				{
					return
						new SelectListItem
						{
							Value = Convert.ToString(it.Id),
							Text = $"{it.Id} - {it.Medziaga} - {it.Spalva}"
						};
				})
				.ToList();
     
    }
    
}