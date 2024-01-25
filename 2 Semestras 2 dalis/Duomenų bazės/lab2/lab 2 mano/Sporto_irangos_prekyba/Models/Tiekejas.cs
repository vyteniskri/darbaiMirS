namespace Sporto_irangos_prekyba.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class Tiekejas
{
	[DisplayName("Id")]
	[Required]
	public int Id { get; set; }

	[DisplayName("Pavadinimas")]
    [Required]
	public string Pavadinimas { get; set; }

    [DisplayName("Telefono numeris")]
    [Required]
	public string PhoneNumber { get; set; }

    [DisplayName("Elektroninio pašto adresas")]
    [Required]
	public string Email { get; set; }

    [DisplayName("Adresas")]
    [Required]
	public string Address { get; set; }

}