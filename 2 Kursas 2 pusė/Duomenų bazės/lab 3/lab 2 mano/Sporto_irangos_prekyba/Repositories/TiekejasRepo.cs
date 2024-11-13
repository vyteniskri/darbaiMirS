namespace Sporto_irangos_prekyba.Repositories;

using MySql.Data.MySqlClient;

using Sporto_irangos_prekyba.Models;


public class TiekejasRepo
{
    public static List<Tiekejas> List()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}tiekejai` ORDER BY tiekejo_id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Tiekejas>(drc, (dre, t) => {
				t.Id = dre.From<int>("tiekejo_id");
				t.Pavadinimas = dre.From<string>("pavadinimas");
				t.PhoneNumber = dre.From<string>("telefonas");
                t.Email = dre.From<string>("e_pastas");
                t.Address = dre.From<string>("adresas");
			});

		return result;
    }

    public static Tiekejas Find(int id)
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}tiekejai` WHERE tiekejo_id=?id";

		var drc = 
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		if( drc.Count > 0 )
		{
			var result = 
				Sql.MapOne<Tiekejas>(drc, (dre, t) => {
					t.Id = dre.From<int>("tiekejo_id");
				    t.Pavadinimas = dre.From<string>("pavadinimas");
				    t.PhoneNumber = dre.From<string>("telefonas");
                    t.Email = dre.From<string>("e_pastas");
                    t.Address = dre.From<string>("adresas");
				});
			
			return result;
		}

		return null;
	}

    public static void Update(Tiekejas tiek)
	{						
		var query = 
			$@"UPDATE `{Config.TblPrefix}tiekejai`
			SET 
				pavadinimas=?pavadinimas,
                telefonas=?telefonas,
                e_pastas=?e_pastas,
                adresas=?adresas
			WHERE 
				tiekejo_id=?id";

		Sql.Update(query, args => {
			args.Add("?pavadinimas", tiek.Pavadinimas);
			args.Add("?telefonas", tiek.PhoneNumber);
			args.Add("?e_pastas", tiek.Email);
            args.Add("?adresas", tiek.Address);
            args.Add("?id", tiek.Id);
		});				
	}

    public static void Insert(Tiekejas tiek)
	{							
		var query = 
			$@"INSERT INTO `{Config.TblPrefix}tiekejai`
			(
				tiekejo_id,
				pavadinimas,
				telefonas,
                e_pastas,
                adresas
			)
			VALUES(
				?id,
				?pavadinimas,
				?telefonas,
                ?e_pastas,
                ?adresas
			)";

		Sql.Insert(query, args => {
			args.Add("?pavadinimas", tiek.Pavadinimas);
			args.Add("?telefonas", tiek.PhoneNumber);
			args.Add("?e_pastas", tiek.Email);
            args.Add("?adresas", tiek.Address);
            args.Add("?id", tiek.Id);
		});	

    }

    public static void Delete(int id)
	{			
		var query = $@"DELETE FROM `{Config.TblPrefix}tiekejai` WHERE tiekejo_id=?id";
		Sql.Delete(query, args => {
			args.Add("?id", id);
		});			
	}
}