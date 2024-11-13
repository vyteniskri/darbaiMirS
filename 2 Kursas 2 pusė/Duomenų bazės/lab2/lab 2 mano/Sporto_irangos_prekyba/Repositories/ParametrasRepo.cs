namespace Sporto_irangos_prekyba.Repositories;

using MySql.Data.MySqlClient;

using Sporto_irangos_prekyba.Models.Parametras;

public class ParametrasRepo
{
    public static List<ParametrasL> ListParametras()
    {
        //var query =
			//$@"SELECT * FROM `{Config.TblPrefix}parametrai` ORDER BY parametro_id ASC";
		var query =
			$@"SELECT
				a.parametro_id,
				b.name AS medziaga,
				m.name AS spalva
			FROM
				{Config.TblPrefix}parametrai a
				LEFT JOIN `{Config.TblPrefix}medziagos` b ON b.medziagos_id = a.medziaga
				LEFT JOIN `{Config.TblPrefix}spalvos` m ON m.spalvos_id = a.spalva
			ORDER BY a.parametro_id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<ParametrasL>(drc, (dre, t) => {
                t.Id = dre.From<int>("parametro_id");
				t.Medziaga = dre.From<string>("medziaga");
				t.Spalva = dre.From<string>("spalva");
			});

		return result;
    }

    public static ParametrasCE FindParametras(int id)
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}parametrai` WHERE parametro_id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<ParametrasCE>(drc, (dre, t) => {
				//make a shortcut
				var auto = t.Parametras;

				//
				auto.Svoris = dre.From<double>("svoris");
				auto.Ilgis = dre.From<double>("ilgis");
				auto.Patvarumas = dre.From<string>("patvarumas");
				auto.Plotis = dre.From<double>("plotis");
				auto.Medziaga = dre.From<int>("medziaga");		
				auto.Spalva = dre.From<int>("spalva");
				auto.Id = dre.From<int>("parametro_id");
			});

		return result;
	}

    public static void InsertParametras(ParametrasCE autoCE)
	{
		var query =
			$@"INSERT INTO `{Config.TblPrefix}parametrai`
			(
				`svoris`,
				`ilgis`,
				`patvarumas`,
				`plotis`,
				`medziaga`,	
				`spalva`
			)
			VALUES (
				?svoris,
				?ilgis,
				?patvarumas,
				?plotis,
				?medziaga,
				?spalva
			)";

		Sql.Insert(query, args => {
			//make a shortcut
			var auto = autoCE.Parametras;

			//
			args.Add("?svoris", auto.Svoris);
			args.Add("?ilgis", auto.Ilgis);
			args.Add("?patvarumas", auto.Patvarumas);
			args.Add("?plotis", auto.Plotis);
			args.Add("?medziaga", auto.Medziaga);
			args.Add("?spalva", auto.Spalva);
		
		});
	}

    public static void UpdateParametras(ParametrasCE autoCE)
	{
		var query =
			$@"UPDATE `{Config.TblPrefix}parametrai`
			SET
				`svoris` = ?svoris,
				`ilgis` = ?ilgis,
				`patvarumas` = ?patvarumas,
				`plotis` = ?plotis,
				`medziaga` = ?medziaga,
				`spalva` = ?spalva
			WHERE
				parametro_id=?id";

		Sql.Update(query, args => {
			//make a shortcut
			var auto = autoCE.Parametras;

			//
			args.Add("?svoris", auto.Svoris);
			args.Add("?ilgis", auto.Ilgis);
			args.Add("?patvarumas", auto.Patvarumas);
			args.Add("?plotis", auto.Plotis);
			args.Add("?medziaga", auto.Medziaga);
			args.Add("?spalva", auto.Spalva);

			args.Add("?id", auto.Id);
		});
	}

    public static void DeleteParametras(int id)
	{
		var query = $@"DELETE FROM `{Config.TblPrefix}parametrai` WHERE parametro_id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}

    public static List<MedziagosTipas> ListMedziagosTipas()
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}medziagos` ORDER BY medziagos_id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<MedziagosTipas>(drc, (dre, t) => {
				t.Id = dre.From<int>("medziagos_id");
				t.Pavadinimas = dre.From<string>("name");
			});

		return result;
	}

    public static List<Spalva> ListSpalva()
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}spalvos` ORDER BY spalvos_id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Spalva>(drc, (dre, t) => {
				t.Id = dre.From<int>("spalvos_id");
				t.Pavadinimas = dre.From<string>("name");
			});

		return result;
	}

}