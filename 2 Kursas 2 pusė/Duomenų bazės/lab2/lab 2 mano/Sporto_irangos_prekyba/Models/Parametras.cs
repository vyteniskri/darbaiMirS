namespace Sporto_irangos_prekyba.Models.Parametras;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ParametrasL
{
    [DisplayName("Id")]
	public int Id { get; set; }

	[DisplayName("Medžiaga")]
	public string Medziaga { get; set; }

    [DisplayName("Spalva")]
	public string Spalva { get; set; }

}

public class ParametrasCE
{
    public class ParametrasM
    {
        [DisplayName("Id")]
	    public int Id { get; set; }

        [DisplayName("Svoris")]
	    [Required]
	    public double Svoris { get; set; }

        [DisplayName("Ilgis")]
	    [Required]
	    public double Ilgis { get; set; }

        [DisplayName("Patvarumas")]
	    [Required]
	    public string Patvarumas { get; set; }

        [DisplayName("Medžiaga")]
	    [Required]
	    public int Medziaga { get; set; }

        [DisplayName("Plotis")]
	    [Required]
	    public double Plotis { get; set; }

        [DisplayName("Spalva")]
	    [Required]
	    public int Spalva { get; set; }
    }

    public class ListM
    {
        public IList<SelectListItem> Medziagos { get; set; }
        public IList<SelectListItem> Spalvos { get; set; }
    }

    public ParametrasM Parametras { get; set; } = new ParametrasM(); 

    public ListM Lists { get; set; } = new ListM(); 
}

public class MedziagosTipas
{
	public int Id { get; set; }

	public string Pavadinimas { get; set; }
}

public class Spalva
{
	public int Id { get; set; }

	public string Pavadinimas { get; set; }
}