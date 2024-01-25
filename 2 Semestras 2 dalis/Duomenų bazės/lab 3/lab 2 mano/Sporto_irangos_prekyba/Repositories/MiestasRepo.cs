namespace Sporto_irangos_prekyba.Repositories;

using MySql.Data.MySqlClient;

using Sporto_irangos_prekyba.Models;


/// <summary>
/// Database operations related to 'Automobilis'.
/// </summary>
public class MiestasRepo
{
	public static List<Miestas> List()
	{
		var query =
			$@"SELECT * FROM `{Config.TblPrefix}miestai` ORDER BY miesto_id ASC";
//LEFT JOIN `{Config.TblPrefix}sporto_irangos_parduotuves` b ON b.fk_miestas = a.miesto_id
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Miestas>(drc, (dre, t) => {
				t.Miesto_id = dre.From<int>("miesto_id");
				t.Pavadinimas = dre.From<string>("pavadinimas");
			});

		return result;
	}

	public static Miestas Find(int id)
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}miestai` WHERE miesto_id=?id";

		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<Miestas>(drc, (dre, t) => {
				//make a shortcut
				t.Miesto_id = dre.From<int>("miesto_id");
				t.Pavadinimas = dre.From<string>("pavadinimas");

			});

		return result;
	}

	public static void InsertMiestas(Miestas autoCE)
	{
		var query =
			$@"INSERT INTO `{Config.TblPrefix}miestai`
			(
				pavadinimas
			)
			VALUES (
				?pavad
			)";

		Sql.Insert(query, args => {
			args.Add("?pavad", autoCE.Pavadinimas);
		});
	}

	public static void UpdateMiestas(Miestas autoCE)
	{
		var query =
			$@"UPDATE `{Config.TblPrefix}miestai`
			SET
				pavadinimas=?pavad
			WHERE
				miesto_id=?id";

		Sql.Update(query, args => {
			args.Add("?pavad", autoCE.Pavadinimas);

			args.Add("?id", autoCE.Miesto_id);
		});
	}

	public static void DeleteMiestas(int id)
	{
		var query = $@"DELETE FROM `{Config.TblPrefix}miestai` WHERE miesto_id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});
	}

}
