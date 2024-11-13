using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab5
{
    /// <summary>
    /// Web form
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Method that forms a first table
        /// </summary>
        /// <param name="publications">List of publications</param>
        protected void PrintToTable1(List<Publication> publications)
        {
            TableRow row0 = new TableRow();

            TableCell cell0 = new TableCell();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();

            cell0.Text = "Kodas";
            cell1.Text = "Pavadinimas";
            cell2.Text = "Leidėjo pavadinimas";
            cell3.Text = "Vieno mėnesio kaina";

            row0.Cells.Add(cell0);
            row0.Cells.Add(cell1);
            row0.Cells.Add(cell2);
            row0.Cells.Add(cell3);

            row0.CssClass = "Header1";

            Table1.Rows.Add(row0);
            foreach (Publication publication in publications)
            {
                TableRow row1 = new TableRow();

                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                TableCell cell6 = new TableCell();
                TableCell cell7 = new TableCell();

                cell4.Text = string.Format("{0}", publication.Code);
                cell5.Text = string.Format("{0}", publication.PublicationName);
                cell6.Text = string.Format("{0}", publication.PublichersName);
                cell7.Text = string.Format("{0}", publication.OneMonthPrice);

                row1.Cells.Add(cell4);
                row1.Cells.Add(cell5);
                row1.Cells.Add(cell6);
                row1.Cells.Add(cell7);

                Table1.Rows.Add(row1);
            }
        }

        /// <summary>
        /// Method that forms a second table
        /// </summary>
        /// <param name="subscribers">List of subscribers</param>
        protected void PrintToTable2(List<Subscriber> subscribers)
        {
            TableRow row0 = new TableRow();

            TableCell cell0 = new TableCell();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();

            cell0.Text = "Įvedimo data";
            cell1.Text = "Pavardė";
            cell2.Text = "Adresas";
            cell3.Text = "Laikotarpio pradžia";
            cell4.Text = "Laikotarpio ilgis";
            cell5.Text = "Leidinio kodas";
            cell6.Text = "Leidinių kiekis";

            row0.Cells.Add(cell0);
            row0.Cells.Add(cell1);
            row0.Cells.Add(cell2);
            row0.Cells.Add(cell3);
            row0.Cells.Add(cell4);
            row0.Cells.Add(cell5);
            row0.Cells.Add(cell6);

            row0.CssClass = "Header1";

            Table2.Rows.Add(row0);
            foreach (Subscriber subscriber in subscribers)
            {
                TableRow row1 = new TableRow();

                TableCell cell7 = new TableCell();
                TableCell cell8 = new TableCell();
                TableCell cell9 = new TableCell();
                TableCell cell10 = new TableCell();
                TableCell cell11 = new TableCell();
                TableCell cell12 = new TableCell();
                TableCell cell13 = new TableCell();

                cell7.Text = string.Format("{0:yyyy-MM-dd}", subscriber.Date);
                cell8.Text = string.Format("{0}", subscriber.Surname);
                cell9.Text = string.Format("{0}", subscriber.Address);
                cell10.Text = string.Format("{0}", subscriber.StartingMonth);
                cell11.Text = string.Format("{0}", subscriber.SubcribeLenght);
                cell12.Text = string.Format("{0}", subscriber.Code);
                cell13.Text = string.Format("{0}", subscriber.Count);

                row1.Cells.Add(cell7);
                row1.Cells.Add(cell8);
                row1.Cells.Add(cell9);
                row1.Cells.Add(cell10);
                row1.Cells.Add(cell11);
                row1.Cells.Add(cell12);
                row1.Cells.Add(cell13);

                Table2.Rows.Add(row1);
            }
        }

        /// <summary>
        /// Method that forms a third table
        /// </summary>
        /// <param name="publichersInfo">Formated dictionary of publishers and their income</param>
        /// <param name="publications">List of publications</param>
        protected void PrintToTable3(Dictionary<string, decimal> publichersInfo, List<Publication> publications)
        {
            foreach (var publisher in publichersInfo)
            {
                TableRow row0 = new TableRow();

                TableCell cell0 = new TableCell();
                TableCell cell1 = new TableCell();

                cell0.Text = "Leidėjo pavadinimas";
                cell1.Text = "Leidėjo pajamos";

                row0.Cells.Add(cell0);
                row0.Cells.Add(cell1);

                row0.CssClass = "Header1";

                Table3.Rows.Add(row0);


                TableRow row1 = new TableRow();

                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();

                cell2.Text = string.Format("{0}", publisher.Key);
                cell3.Text = string.Format("{0}", publisher.Value);

                row1.Cells.Add(cell2);
                row1.Cells.Add(cell3);
                Table3.Rows.Add(row1);


                TableRow row2 = new TableRow();

                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();

                cell4.Text = "Leidėjo leidiniai";
                cell5.Text = "Leidinių atneštos pajamos";

                row2.Cells.Add(cell4);
                row2.Cells.Add(cell5);

                row2.CssClass = "Header2";

                Table3.Rows.Add(row2);


                List<Publication> selectedPublications = TaskUtils.AllSpecificPublications(publications, publisher.Key);

                foreach (Publication publication in selectedPublications)
                {
                    TableRow row3 = new TableRow();

                    TableCell cell6 = new TableCell();
                    TableCell cell7 = new TableCell();

                    cell6.Text = string.Format("{0}", publication.PublicationName);
                    cell7.Text = string.Format("{0}", publication.Income);

                    row3.Cells.Add(cell6);
                    row3.Cells.Add(cell7);

                    Table3.Rows.Add(row3);

                }
            }
        }
    }
}