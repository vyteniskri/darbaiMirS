namespace Sporto_irangos_prekyba.Repositories;

using MySql.Data.MySqlClient;

using AtaskaitaReport = Sporto_irangos_prekyba.Models.AtaskaitaReport;

public class AtaskaitaRepo
{
    public static List<AtaskaitaReport.Ataskaita> GetTiekejai(DateTime? dateFrom, DateTime? dateTo, double? kaina) ///, float kaina
    {
        DateTime date0 = DateTime.MinValue;
        var query =
			$@"SELECT 
                UPPER(tiek.pavadinimas) AS pavadinimas,
                prek.pavadinimas AS PrekesPavadinimas,
                tiek.tiekejo_id,
                par.svoris,
                gc.Count,
                gc2.max_svoris,
                IFNULL(Pkain.galioja_nuo, ?date0) AS preke_galioja_nuo,
                IFNULL(Pkain.galioja_iki, ?date0) AS preke_galioja_iki,
                IFNULL(Pkain.kaina, 0) AS prekes_kaina,
                gc3.DateCount,
                gc3.KainuSum
            FROM `{Config.TblPrefix}prekes` prek
                INNER JOIN `{Config.TblPrefix}tiekejai` tiek ON tiek.tiekejo_id = prek.fk_tiekejas
                INNER JOIN `{Config.TblPrefix}parametrai` par ON par.parametro_id = prek.fk_parametras
                LEFT JOIN `{Config.TblPrefix}prekiu_kainos` Pkain ON Pkain.fk_preke = prek.prekes_id
                INNER JOIN
                    (   SELECT 
                            tiek1.tiekejo_id,
                            COUNT(DISTINCT prek1.prekes_id) AS Count
                        FROM `{Config.TblPrefix}prekes` prek1
                        INNER JOIN `{Config.TblPrefix}tiekejai` tiek1 ON tiek1.tiekejo_id = prek1.fk_tiekejas
                        LEFT JOIN `{Config.TblPrefix}prekiu_kainos` Pkain0 ON Pkain0.fk_preke = prek1.prekes_id
                        WHERE
                            Pkain0.galioja_nuo >= IFNULL(?nuo, Pkain0.galioja_nuo) 
                            AND Pkain0.galioja_iki <= IFNULL(?iki, Pkain0.galioja_iki)
                            AND Pkain0.kaina >= IFNULL(?kaina, Pkain0.kaina)
                        GROUP BY tiek1.tiekejo_id
                    ) AS gc ON gc.tiekejo_id = tiek.tiekejo_id
                INNER JOIN 
                    (   SELECT
                            tiek2.tiekejo_id,
                            floor(MAX(par2.svoris)) AS max_svoris
                        FROM `{Config.TblPrefix}prekes` prek2
                            INNER JOIN `{Config.TblPrefix}tiekejai` tiek2 ON tiek2.tiekejo_id = prek2.fk_tiekejas
                            INNER JOIN `{Config.TblPrefix}parametrai` par2 ON par2.parametro_id = prek2.fk_parametras
                            LEFT JOIN `{Config.TblPrefix}prekiu_kainos` Pkain1 ON Pkain1.fk_preke = prek2.prekes_id
                            WHERE
                                Pkain1.galioja_nuo >= IFNULL(?nuo, Pkain1.galioja_nuo)
                                AND Pkain1.galioja_iki <= IFNULL(?iki, Pkain1.galioja_iki)
                                AND Pkain1.kaina >= IFNULL(?kaina, Pkain1.kaina)
                        GROUP BY tiek2.tiekejo_id
                    ) AS gc2 ON gc2.tiekejo_id = tiek.tiekejo_id
                LEFT JOIN
                    (   SELECT
                            tiek3.tiekejo_id,
                            COUNT(*) AS DateCount,
                            SUM( Pkain2.kaina ) AS KainuSum
                        FROM `{Config.TblPrefix}prekes` prek3
                            INNER JOIN `{Config.TblPrefix}tiekejai` tiek3 ON tiek3.tiekejo_id = prek3.fk_tiekejas
                            LEFT JOIN `{Config.TblPrefix}prekiu_kainos` Pkain2 ON Pkain2.fk_preke = prek3.prekes_id
                        WHERE
                            Pkain2.galioja_nuo >= IFNULL(?nuo, Pkain2.galioja_nuo)
                            AND Pkain2.galioja_iki <= IFNULL(?iki, Pkain2.galioja_iki)
                            AND Pkain2.kaina >= IFNULL(?kaina, Pkain2.kaina)
                        GROUP BY tiek3.tiekejo_id
                    ) AS gc3 ON gc3.tiekejo_id = tiek.tiekejo_id
            WHERE
                Pkain.galioja_nuo >= IFNULL(?nuo, Pkain.galioja_nuo)
                AND Pkain.galioja_iki <= IFNULL(?iki, Pkain.galioja_iki)
                AND Pkain.kaina >= IFNULL(?kaina, Pkain.kaina)
            ORDER BY 
                tiek.pavadinimas";

        var drc =
			Sql.Query(query, args => {
				args.Add("?nuo", dateFrom);
				args.Add("?iki", dateTo);
                args.Add("?kaina", kaina);
                args.Add("?date0", date0);
			});

        var result = 
			Sql.MapAll<AtaskaitaReport.Ataskaita>(drc, (dre, t) => {
				t.TiekejoPavadinimas = dre.From<string>("pavadinimas");
                t.PrekesPavadinimas = dre.From<string>("PrekesPavadinimas");
                t.Id = dre.From<int>("tiekejo_id");
                t.BendraSumaPrekiu = dre.From<int>("Count");
                t.Svoris = dre.From<double>("svoris");
                t.MaxSvoris = dre.From<double>("max_svoris");
                t.GaliojaNuo = dre.From<DateTime>("preke_galioja_nuo");
                t.GaliojaIki = dre.From<DateTime>("preke_galioja_iki");
                t.Kaina = dre.From<double>("prekes_kaina");
                t.BendraSumaDatu = dre.From<int>("DateCount");
                t.BendraSumaKainu = dre.From<int>("KainuSum");
			});

		return result;
    }
}