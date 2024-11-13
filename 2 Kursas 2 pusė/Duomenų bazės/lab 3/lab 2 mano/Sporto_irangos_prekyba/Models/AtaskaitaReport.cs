namespace Sporto_irangos_prekyba.Models.AtaskaitaReport;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


public class Ataskaita
{   
	public string TiekejoPavadinimas { get; set; }

    [DisplayName("Pavadinimas")]
    public string PrekesPavadinimas { get; set; }

    public int Id { get; set; }

    [DisplayName("Svoris")]
    public double Svoris { get; set; }

    [DisplayName("Galioja nuo")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime GaliojaNuo { get; set; }

    [DisplayName("Galioja iki")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime GaliojaIki { get; set; }

    [DisplayName("Kaina")]
    public double Kaina { get; set; }

    public int BendraSumaPrekiu { get; set; }

    public double MaxSvoris { get; set; }

    public int BendraSumaDatu { get; set; }

    public double BendraSumaKainu { get; set; }
}

public class Report
{
    [DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateFrom { get; set; }

	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
	public DateTime? DateTo { get; set; }

    public double? KainaNuo { get; set; }

    public List<Ataskaita> Tiekejai { get; set;}


    public int VisuPrekiuSkaicius { get; set;}

    public double BendrasDidziausiasSvoris { get; set;}

    public int VisuDatuSkaicius { get; set;}

    public double VisuKainuSuma { get; set;}

}