using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//Main function of this program is to do all kinds of calculations with given data of devices in shops

//Vytenis Kriščiūnas
namespace Lab5
{
    /// <summary>
    /// Web form
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// List of subscribers
        /// </summary>
        List<Subscriber> subscribers = new List<Subscriber>();

        /// <summary>
        /// List of publications
        /// </summary>
        List<Publication> publications = new List<Publication>();

        /// <summary>
        /// Dictionary of sorted information
        /// </summary>
        Dictionary<string, decimal> sortedDictionary = new Dictionary<string, decimal>();

        /// <summary>
        /// Method that prints information to the screen when page loads
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Pradiniai duomenys nepasirinkti";
            subscribers = Session["1"] as List<Subscriber>;
            publications = Session["2"] as List<Publication>;
            sortedDictionary = Session["4"] as Dictionary<string, decimal>;

            if (subscribers != null && publications != null)
            {
                Label1.Text = "Pradiniai duomenys užkrauti";
                PrintToTable1(publications);
                PrintToTable2(subscribers);            
            }

            if (sortedDictionary != null)
            {
                PrintToTable3(sortedDictionary, publications);
            }

        }

        /// <summary>
        /// Prints and reads given information when the first button is clicked
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = Table1.Rows.Count - 1; i >= 0; i--)
            {
                Table1.Rows.RemoveAt(i);
            }

            for (int i = Table2.Rows.Count - 1; i >= 0; i--)
            {
                Table2.Rows.RemoveAt(i);
            }

            for (int i = Table3.Rows.Count - 1; i >= 0; i--)
            {
                Table3.Rows.RemoveAt(i);
            }

            Session.Clear();
            string FilesPath = Server.MapPath("App_Data/SubData");
            string FilePath = Server.MapPath("App_Data/PublicationsData.txt");
            string GivenData = Server.MapPath("App_Data/Rezults/GivenData.txt");

            File.Delete(GivenData);
            Label1.Text = "Pradiniai duomenys nepasirinkti";
            Label2.Text = "";

            if (FileUpload1.HasFile)
            {
                Label1.Text = "Pradiniai duomenys užkrauti";

                subscribers = InOut.ReadSubscribers(FilesPath);
                publications = InOut.ReadPublications(FilePath);
                Session["1"] = subscribers;
                Session["2"] = publications;

                InOut.PrintDataToTxt(GivenData, publications);
                InOut.PrintDataToTxt(GivenData, subscribers);

                PrintToTable1(publications);
                PrintToTable2(subscribers);
            }

        }

        /// <summary>
        /// Prints and does calculations when the second button is clicked
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Rezults = Server.MapPath("App_Data/Rezults/Rezults.txt");
            File.Delete(Rezults);
            Label2.Text = "";

            try
            {
                publications.ForEach(x => x.Income = 0);

                for (int i = Table3.Rows.Count - 1; i >= 0; i--)
                {
                    Table3.Rows.RemoveAt(i);
                }

                List<Subscriber> selectedSubscribers = TaskUtils.FilteredByMonth(subscribers, int.Parse(TextBox1.Text));

                if (selectedSubscribers[0].Surname != null)
                {
                    TaskUtils.CountPublicationIncome(selectedSubscribers, publications);

                    Dictionary<string, decimal> publishersInfo = TaskUtils.CountPublichersIncome(publications);

                    sortedDictionary = TaskUtils.SortedDictionary(publishersInfo);

                    Session["4"] = sortedDictionary;

                    InOut.PrintRezults(Rezults, sortedDictionary, publications);

                    PrintToTable3(sortedDictionary, publications);
                }
               
            }
            catch (Exception)
            {
                Label2.Text = "Užkrauti rezultatų nepavyko.";
            }
             
        }
    }
}