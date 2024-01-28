using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab2
{
    /// <summary>
    /// Web form extention
    /// </summary>
    public partial class Factory : System.Web.UI.Page
    {
        /// <summary>
        /// Method that forms Table1
        /// </summary>
        /// <param name="workers">List of wrokers</param>
        protected void PrintTable1(LinkListWorkers workers)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "<b>Data</b>";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "<b>Pavardė</b>";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "<b>Vardas</b>";
            row.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            cell4.Text = "<b>Kodas</b>";
            row.Cells.Add(cell4);

            TableCell cell5 = new TableCell();
            cell5.Text = "<b>Detalių skaičius</b>";
            row.Cells.Add(cell5);

            Table1.Rows.Add(row);

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                TableRow newRow = new TableRow();

                TableCell newCell1 = new TableCell();
                newCell1.Text = string.Format("{0:yyyy-MM-dd}", workers.Get().Date);
                newRow.Cells.Add(newCell1);

                TableCell newCell2 = new TableCell();
                newCell2.Text = string.Format("{0}", workers.Get().Surname);
                newRow.Cells.Add(newCell2);

                TableCell newCell3 = new TableCell();
                newCell3.Text = string.Format("{0}", workers.Get().Name);
                newRow.Cells.Add(newCell3);

                TableCell newCell4 = new TableCell();
                newCell4.Text = string.Format("{0}", workers.Get().Code);
                newRow.Cells.Add(newCell4);

                TableCell newCell5 = new TableCell();
                newCell5.Text = string.Format("{0}", workers.Get().VntCount);
                newRow.Cells.Add(newCell5);

                Table1.Rows.Add(newRow);
            }
        }

        /// <summary>
        /// Method that forms Table2
        /// </summary>
        /// <param name="parts">List of parts</param>
        protected void PrintTable2(LinkListParts parts)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "<b>Kodas</b>";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "<b>Pavadinimas</b>";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "<b>Kaina</b>";
            row.Cells.Add(cell3);

            Table2.Rows.Add(row);

            for (parts.Begin(); parts.Exist(); parts.Next())
            {
                TableRow newRow = new TableRow();

                TableCell newCell1 = new TableCell();
                newCell1.Text = string.Format("{0}", parts.Get().Code);
                newRow.Cells.Add(newCell1);

                TableCell newCell2 = new TableCell();
                newCell2.Text = string.Format("{0}", parts.Get().Name);
                newRow.Cells.Add(newCell2);

                TableCell newCell3 = new TableCell();
                newCell3.Text = string.Format("{0}", parts.Get().Price);
                newRow.Cells.Add(newCell3);

                Table2.Rows.Add(newRow);
            }
        }

        /// <summary>
        /// Method that forms Table3
        /// </summary>
        /// <param name="richestWorker">A single worker</param>
        protected void PrintRichestWorker(Worker richestWorker)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "<b>Pavardė</b>";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "<b>Dirbtų dienų skaičius</b>";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "<b>Pagamintų detalių skaičius</b>";
            row.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            cell4.Text = "<b>Uždirbti pinigai</b>";
            row.Cells.Add(cell4);

            Table3.Rows.Add(row);

            if (richestWorker.Surname != null)
            {
                TableRow newRow = new TableRow();

                TableCell cell5 = new TableCell();
                cell5.Text = string.Format("{0}", richestWorker.Surname);
                newRow.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = string.Format("{0}", richestWorker.DaysWorked);
                newRow.Cells.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = string.Format("{0}", richestWorker.PartsCount);
                newRow.Cells.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = string.Format("{0}", richestWorker.MoneyCount);
                newRow.Cells.Add(cell8);

                Table3.Rows.Add(newRow);
            }
            
        }

        /// <summary>
        /// Method that forms Table4
        /// </summary>
        /// <param name="workers">List of workers</param>
        protected void PrintSinglePartMakers(LinkListWorkers workers)
        {
            
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "<b>Pavardė</b>";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "<b>Vardas</b>";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "<b>Detalės kodas</b>";
            row.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            cell4.Text = "<b>Skaičius vienodų detalių</b>";
            row.Cells.Add(cell4);

            TableCell cell5 = new TableCell();
            cell5.Text = "<b>Uždirbtų pinigų suma</b>";
            row.Cells.Add(cell5);

            Table4.Rows.Add(row);

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                TableRow newRow = new TableRow();

                TableCell newCell1 = new TableCell();
                newCell1.Text = string.Format("{0}", workers.Get().Surname);
                newRow.Cells.Add(newCell1);

                TableCell newCell2 = new TableCell();
                newCell2.Text = string.Format("{0}", workers.Get().Name);
                newRow.Cells.Add(newCell2);

                TableCell newCell3 = new TableCell();
                newCell3.Text = string.Format("{0}", workers.Get().Code);
                newRow.Cells.Add(newCell3);

                TableCell newCell4 = new TableCell();
                newCell4.Text = string.Format("{0}", workers.Get().PartsCount);
                newRow.Cells.Add(newCell4);

                TableCell newCell5 = new TableCell();
                newCell5.Text = string.Format("{0}", workers.Get().MoneyCount);
                newRow.Cells.Add(newCell5);

                Table4.Rows.Add(newRow);
            }
        }

        /// <summary>
        /// Method that forms Table5
        /// </summary>
        /// <param name="workers">List of workers</param>
        protected void PrintTable5(LinkListWorkers workers)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "<b>Data</b>";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "<b>Pavardė</b>";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "<b>Vardas</b>";
            row.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            cell4.Text = "<b>Kodas</b>";
            row.Cells.Add(cell4);

            TableCell cell5 = new TableCell();
            cell5.Text = "<b>Detalių skaičius</b>";
            row.Cells.Add(cell5);

            Table5.Rows.Add(row);

            for (workers.Begin(); workers.Exist(); workers.Next())
            {
                TableRow newRow = new TableRow();

                TableCell newCell1 = new TableCell();
                newCell1.Text = string.Format("{0:yyyy-MM-dd}", workers.Get().Date);
                newRow.Cells.Add(newCell1);

                TableCell newCell2 = new TableCell();
                newCell2.Text = string.Format("{0}", workers.Get().Surname);
                newRow.Cells.Add(newCell2);

                TableCell newCell3 = new TableCell();
                newCell3.Text = string.Format("{0}", workers.Get().Name);
                newRow.Cells.Add(newCell3);

                TableCell newCell4 = new TableCell();
                newCell4.Text = string.Format("{0}", workers.Get().Code);
                newRow.Cells.Add(newCell4);

                TableCell newCell5 = new TableCell();
                newCell5.Text = string.Format("{0}", workers.Get().VntCount);
                newRow.Cells.Add(newCell5);

                Table5.Rows.Add(newRow);
            }
        }
    }
}