namespace Sporto_irangos_prekyba.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

/// <summary>
/// 'Miestas' in create and edit forms.
/// </summary>
public class Miestas
{
	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }

	[DisplayName("Miesto_id")]
	public int Miesto_id { get; set; }

}


