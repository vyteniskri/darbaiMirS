namespace Sporto_irangos_prekyba.Models.PrekeF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class PrekeL
{
    [DisplayName("Pavadinimas")]
    public string Pavadinimas { get;  set; }

    [DisplayName("Aprašymas")]
    public string Aprasymas { get;  set; }

    [DisplayName("Prekės id")]
    public int Prekes_id { get;  set; }
}

public class PrekeCE
{
    public class PrekeM
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get;  set; }

        [DisplayName("Aprašymas")]
        [Required]
        public string Aprasymas { get;  set; }

        [DisplayName("Prekės id")]
        [Required]
        public int Prekes_id { get;  set; }

        [DisplayName("Tiekėjas")]
        [Required]
        public int FkTiekejas { get;  set; }

        [DisplayName("Parametras")]
        [Required]
        public int FkParametras { get;  set; }
    }

    public class PrekesKainaM
    {
        public int InListId { get; set; }

        [DisplayName("Galioja nuo")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime GaliojaNuo { get;  set; }

        [DisplayName("Galioja iki")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime GaliojaIki { get;  set; }

        [DisplayName("Kaina")]
        [Required]
        public double Kaina { get;  set; }


    }

    public class ListM
    {
        public IList<SelectListItem> Tiekejai { get; set; }
        public IList<SelectListItem> Parametrai { get; set; }
    }

    public PrekeM Preke { get; set; } = new PrekeM();

    public IList<PrekesKainaM> PrekiuKainos { get; set; } = new List<PrekesKainaM>();

    public ListM Lists { get; set; } = new ListM();
}