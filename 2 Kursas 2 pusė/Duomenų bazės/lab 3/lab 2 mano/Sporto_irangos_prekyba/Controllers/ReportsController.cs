namespace Sporto_irangos_prekyba.Controllers;

using Microsoft.AspNetCore.Mvc;

using Sporto_irangos_prekyba.Repositories;

using AtaskaitaReport = Sporto_irangos_prekyba.Models.AtaskaitaReport;

public class ReportsController : Controller
{

	/// <summary>
	/// Produces contracts report.
	/// </summary>
	/// <param name="dateFrom">Starting date. Can be null.</param>
	/// <param name="dateTo">Ending date. Can be null.</param>
	/// <returns>Report view.</returns>
	[HttpGet]
	public ActionResult Ataskaita(DateTime? dateFrom, DateTime? dateTo, double? KainaNuo)
	{
		List<int> ids = new List<int>();
		var report = new AtaskaitaReport.Report();
		report.DateFrom = dateFrom;
		report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day
		report.KainaNuo = KainaNuo;

		report.Tiekejai = AtaskaitaRepo.GetTiekejai(report.DateFrom, report.DateTo, report.KainaNuo);

		foreach (var item in report.Tiekejai)
		{
			if (!ids.Contains(item.Id))
			{
				report.VisuPrekiuSkaicius += item.BendraSumaPrekiu;
				if (report.BendrasDidziausiasSvoris < item.MaxSvoris)
				{
					report.BendrasDidziausiasSvoris = item.MaxSvoris;
				}
				report.VisuDatuSkaicius += item.BendraSumaDatu;
				report.VisuKainuSuma += item.BendraSumaKainu;

				ids.Add(item.Id);
			}
			
		}
		return View(report);
	}

}