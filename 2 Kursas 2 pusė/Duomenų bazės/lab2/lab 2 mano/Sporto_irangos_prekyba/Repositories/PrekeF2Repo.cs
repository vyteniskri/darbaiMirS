namespace Sporto_irangos_prekyba.Repositories;

using MySql.Data.MySqlClient;

using Sporto_irangos_prekyba.Models.PrekeF2;

public class PrekeF2Repo
{
    public static List<PrekeL> ListPreke()
    {
         var query = $@"SELECT * FROM `{Config.TblPrefix}prekes` ORDER BY prekes_id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<PrekeL>(drc, (dre, t) => {
				t.Pavadinimas = dre.From<string>("pavadinimas");
				t.Aprasymas = dre.From<string>("aprasymas");
				t.Prekes_id = dre.From<int>("prekes_id");
			});

		return result;
    }

    public static PrekeCE FindPrekeCE(int id)
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}prekes` WHERE prekes_id=?id";
		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<PrekeCE>(drc, (dre, t) => {
				//make a shortcut
				var sut = t.Preke;

				//
				sut.Pavadinimas = dre.From<string>("pavadinimas");
				sut.Aprasymas = dre.From<string>("aprasymas");
				sut.Prekes_id = dre.From<int>("prekes_id");
				sut.FkTiekejas = dre.From<int>("fk_tiekejas");
				sut.FkParametras = dre.From<int>("fk_parametras");	
			});

		return result;
	}

    public static int InsertPreke(PrekeCE sutCE)
	{
		var query =
			$@"INSERT INTO `{Config.TblPrefix}prekes`
			(
				`pavadinimas`,
				`aprasymas`,
				`fk_tiekejas`,
				`fk_parametras`
			)
			VALUES(
				?pavadinimas,
				?aprasymas,
				?fk_tiekejas,
				?fk_parametras
			)";

		var nr =
			Sql.Insert(query, args => {
				//make a shortcut
				var sut = sutCE.Preke;

				//
				args.Add("?pavadinimas", sut.Pavadinimas);
				args.Add("?aprasymas", sut.Aprasymas);
				args.Add("?fk_tiekejas", sut.FkTiekejas);
				args.Add("?fk_parametras", sut.FkParametras);
			});

		return (int)nr;
	}

    public static void UpdatePreke(PrekeCE sutCE)
	{
		var query =
			$@"UPDATE `{Config.TblPrefix}prekes`
			SET
				`pavadinimas` = ?pavadinimas,
				`aprasymas`= ?aprasymas,
				`fk_tiekejas`= ?fk_tiekejas,
				`fk_parametras` = ?fk_parametras
			WHERE prekes_id=?prekes_id";

		Sql.Update(query, args => {
			//make a shortcut
			var sut = sutCE.Preke;

			//
			args.Add("?pavadinimas", sut.Pavadinimas);
			args.Add("?aprasymas", sut.Aprasymas);
			args.Add("?prekes_id", sut.Prekes_id);
			args.Add("?fk_tiekejas", sut.FkTiekejas);
			args.Add("?fk_parametras", sut.FkParametras);

		});
	}

    public static void DeletePreke(int id)
	{
		var query = $@"DELETE FROM `{Config.TblPrefix}prekes` where prekes_id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}

    public static List<PrekeCE.PrekesKainaM> ListPrekesKaina(int prekesId)
	{
		var query =
			$@"SELECT *
			FROM `{Config.TblPrefix}prekiu_kainos`
			WHERE fk_preke = ?prekesId
			ORDER BY galioja_nuo ASC, galioja_iki ASC";

		var drc =
			Sql.Query(query, args => {
				args.Add("?prekesId", prekesId);
			});

		var result =
			Sql.MapAll<PrekeCE.PrekesKainaM>(drc, (dre, t) => {
				t.GaliojaNuo = dre.From<DateTime>("galioja_nuo");
				t.GaliojaIki = dre.From<DateTime>("galioja_iki");
                t.Kaina = dre.From<double>("kaina");
			});

		for( int i = 0; i < result.Count; i++ )
			result[i].InListId = i;

		return result;
	}

    public static void InsertPrekesKaina(int prekesId, PrekeCE.PrekesKainaM up)
	{
		var query =
			$@"INSERT INTO `{Config.TblPrefix}prekiu_kainos`
				(
					galioja_nuo,
					galioja_iki,
					kaina,
					fk_preke
				)
				VALUES(
					?galioja_nuo,
					?galioja_iki,
					?kaina,
					?fk_preke
				)";

		Sql.Insert(query, args => {
			args.Add("?galioja_nuo", up.GaliojaNuo);
			args.Add("?galioja_iki", up.GaliojaIki);
			args.Add("?kaina", up.Kaina);
			args.Add("?fk_preke", prekesId);
		});
	}

    public static void DeletePrekesKainaForPreke(int preke)
	{
		var query =
			$@"DELETE FROM a
			USING `{Config.TblPrefix}prekiu_kainos` as a
			WHERE a.fk_preke=?preke";

		Sql.Delete(query, args => {
			args.Add("?preke", preke);
		});
	}

	public static int FindPrekesKaina(int id)
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}prekiu_kainos` WHERE galioja_nuo=?galiojaNuo";
		var drc =
			Sql.Query(query, args => {
				args.Add("?galiojaNuo", id);
			});

		if( drc.Count > 0 )
		{
			return 1;
		}
		return 0;
	}

}
