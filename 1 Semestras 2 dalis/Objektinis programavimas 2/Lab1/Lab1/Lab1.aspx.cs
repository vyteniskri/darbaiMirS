using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//Main function of this program is to find the number of moles and their created wholes numbers

//Vytenis Kriščiūnas
namespace Lab1
{
    /// <summary>
    /// Web form
    /// </summary>
    public partial class Lab1 : System.Web.UI.Page
    {
        /// <summary>
        /// Prints information to the screen when page loads
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (register == null)
            {
                register = new Register();
            }

            int columnSize, rowsSize;
            register = InOutUtils.ReadAllLines(Server.MapPath("App_Data/U3.txt"), out columnSize, out rowsSize);
            register.ColumnsSize = columnSize;
            register.RowsSize = rowsSize;
            InOutUtils.PrintAllLinesToTxt(Server.MapPath("GigvenData.txt"), register);
            Label1.Text = "Schemos dydis: " + register.ColumnsSize + " " + register.RowsSize;
            FormBaseDataTable(register);
            
        }

        /// <summary>
        /// Prints information to the screen when first button is clicked
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            WholesConteiner countedWholes = TaskUtils.MolesWholes(register);
            countedWholes.Sort();
            TableRow row = new TableRow();

            TableCell item = new TableCell();
            item.Text = "<b>Rezultatai</b>";
            row.Cells.Add(item);
            Table1.Rows.Add(row);

            FormTable(countedWholes);
            InOutUtils.PrintAllLinesToTxt(Server.MapPath("Rezults.txt"), countedWholes);

        }
    }
}