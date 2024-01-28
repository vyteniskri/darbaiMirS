using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab1
{
    /// <summary>
    /// Web form extention
    /// </summary>
    public partial class Lab1 : System.Web.UI.Page
    {
        /// <summary>
        /// Register for given data
        /// </summary>
        Register register;

        /// <summary>
        /// Method that forms a Table to the screen 
        /// </summary>
        /// <param name="AllData">Register of base data</param>
        protected void FormBaseDataTable(Register AllData)
        {
            TableRow row1 = new TableRow();
            TableCell item1 = new TableCell();

            item1.Text = "<b>Simboliai</b>";
            row1.Cells.Add(item1);
            Table2.Rows.Add(row1);
            for (int i = 0; i < AllData.Count(); i++)
            {
                TableRow row2 = new TableRow();
                TableCell item2 = new TableCell();
                item2.Text = AllData.WholeLine(i).LineOfSymbols;
                row2.Cells.Add(item2);
                Table2.Rows.Add(row2);
            }
        }

        /// <summary>
        /// Method that forms a Table to the screen
        /// </summary>
        /// <param name="WholesNumber">Conteiner of rezults</param>
        protected void FormTable(WholesConteiner WholesNumber)
        {
            TableRow row1 = new TableRow();
            TableCell item1 = new TableCell();

            item1.Text = string.Format("Kurmių skaičius: {0}", WholesNumber.Count);
            row1.Cells.Add(item1);
            Table1.Rows.Add(row1);

            for (int i = 0; i < WholesNumber.Count; i++)
            {
                TableRow row2 = new TableRow();
                TableCell item2 = new TableCell();
                item2.Text = string.Format("{0}", WholesNumber.GetArea(5, i));
                row2.Cells.Add(item2);
                Table1.Rows.Add(row2);
            }
        }

    }
}