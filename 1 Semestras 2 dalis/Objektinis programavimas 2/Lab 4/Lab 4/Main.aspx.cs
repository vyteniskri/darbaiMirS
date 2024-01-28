using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//Main function of this program is to do all kinds of calculations with given data of devices in shops

//Vytenis Kriščiūnas
namespace Lab_4
{
    /// <summary>
    /// Web Form
    /// </summary>
    public partial class Main : System.Web.UI.Page
    {
        
      
        /// <summary>
        /// Prints information to the screen when page loads
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Prints and reads given information when the first button is clicked
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            List<DevicesRegister> allShops = new List<DevicesRegister>();
            List<Device> TenFridges = new List<Device>();
            List<Device> OnlyThere = new List<Device>();
            List<Device> allExpenciveDevices = new List<Device>();

            Label2.Text = "";
            string pathToFile1 = Server.MapPath("App_Data/Data");
            string pathToFile2 = Server.MapPath("App_Data/Results/Results.txt");
            string pathToFile3 = Server.MapPath("App_Data/Results/TikTen.csv");
            string pathToFile4 = Server.MapPath("App_Data/Results/Brangus.csv");

            File.Delete(pathToFile2);
            File.Delete(pathToFile3);
            File.Delete(pathToFile4);

            if (FileUpload1.HasFile)
            {
                
                Label1.Text = "Pradiniai duomenys pasirinkti.";
                allShops = InOut.ReadFile(pathToFile1);
                InOut.PrintToTxt(pathToFile2, allShops);
                CreateTable(allShops);
                Session["allShops"] = allShops;

                PrintTable2(allShops);
                InOut.PrintToTxtSertainItemsMakers(pathToFile2, allShops);

                TenFridges = TaskUtils.TenSelectedFridges(allShops);
                PrintTable3(TenFridges);
                InOut.PrintTenFridges(pathToFile2, TenFridges);
                Session["TenFridges"] = TenFridges;


                OnlyThere = TaskUtils.OnlyThere(allShops);
                try
                {
                    string type = OnlyThere[0].Type;
                    Label2.Text = "Tokių buitinių prietaisų yra.";

                    File.AppendAllText(pathToFile3, string.Format("Prietaisai, kurių galima įsigyti tik vienoje parduotuvėje: \n"));
                    File.AppendAllText(pathToFile3, string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} |\n", "Tipas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Požymis: turi šaldiklį ar ne", "Aukštis", "Plotis", "Gylis", "Galia", "Tūris", "Galingumas", "Programų skaičius"));
                    InOut.PrintToCsv(pathToFile3, OnlyThere, "Fridge");
                    InOut.PrintToCsv(pathToFile3, OnlyThere, "Kettle");
                    InOut.PrintToCsv(pathToFile3, OnlyThere, "Oven");
                }
                catch (Exception)
                {
                    Label2.Text = "Tokių buitinių prietaisų nėra.";
                }

                allExpenciveDevices = TaskUtils.AllExpenciveDevices(allShops);
                try
                {
                    string type = allExpenciveDevices[0].Type;
                    TaskUtils.Sort(allExpenciveDevices);

                    File.AppendAllText(pathToFile4, string.Format("Brangiausių buitinių prekių sąrašas: \n"));
                    File.AppendAllText(pathToFile4, string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} |\n", "Tipas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Požymis: turi šaldiklį ar ne", "Aukštis", "Plotis", "Gylis", "Galia", "Tūris", "Galingumas", "Programų skaičius"));
                    InOut.PrintToCsv(pathToFile4, allExpenciveDevices, "Fridge");
                    InOut.PrintToCsv(pathToFile4, allExpenciveDevices, "Kettle");
                    InOut.PrintToCsv(pathToFile4, allExpenciveDevices, "Oven");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                Label1.Text = "Pradiniai duomenys nepasirinkti.";
            }
            

        }
    }
}