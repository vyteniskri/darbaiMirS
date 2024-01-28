using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//Main function of this program is to do all kinds of calculations with given data of workers and different parts

//Vytenis Kriščiūnas
namespace Lab2
{
    /// <summary>
    /// Web form
    /// </summary>
    public partial class Factory : System.Web.UI.Page
    {
        /// <summary>
        /// List of parts
        /// </summary>
        LinkListParts parts;

        /// <summary>
        /// List of workers
        /// </summary>
        LinkListWorkers workers;

        /// <summary>
        /// The richest worker
        /// </summary>
        Worker richestWorker;

        /// <summary>
        /// List of workers who allways make the same parts
        /// </summary>
        LinkListWorkers singlePartMakers;

        /// <summary>
        /// List formed by given attributes
        /// </summary>
        LinkListWorkers listByAttributes;

        /// <summary>
        /// Prints information to the screen when page loads
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (parts == null)
            {
                parts = new LinkListParts();
            }
            if (workers == null)
            {
                workers = new LinkListWorkers();
            }
            if (richestWorker == null)
            {
                richestWorker = new Worker();
            }
            if (singlePartMakers == null)
            {
                singlePartMakers = new LinkListWorkers();
            }
            if (listByAttributes == null)
            {
                listByAttributes = new LinkListWorkers();
            }
            
            parts = Session["parts"] as LinkListParts;
            workers = Session["workers"] as LinkListWorkers;
            

            if (workers != null && parts != null)
            {
                PrintTable1(workers);
                PrintTable2(parts);
            }
           
        }

        /// <summary>
        /// Prints and reads given information when the first button is clicked
        /// </summary>
        /// <param name="sender">An object variable</param>
        /// <param name="e">EventArgs variable</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("parts");
            Session.Remove("workers");
            for (int i = Table1.Rows.Count - 1; i >= 0; i--)
            {
                Table1.Rows.RemoveAt(i);
            }
            for (int i = Table2.Rows.Count - 1; i >= 0; i--)
            {
                Table2.Rows.RemoveAt(i);
            }

            string Fr = Server.MapPath("App_Data/GivenData.txt");
            File.Delete(Fr);

            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                string Fd1 = Server.MapPath("App_Data/U10a.txt"); // workers
                string Fd2 = Server.MapPath("App_Data/U10b.txt"); // parts

                if (FileUpload1.FileName.EndsWith("a.txt") && FileUpload2.FileName.EndsWith("b.txt"))
                {

                    parts = InOutUtils.ReadInfo2(Fd2);
                    workers = InOutUtils.ReadInfo1(Fd1);

                    PrintTable1(workers);
                    PrintTable2(parts);

                    InOutUtils.PrintGivenData(Fr, workers, "");
                    InOutUtils.PrintGivenData(Fr, parts);


                    Session["parts"] = parts;
                    Session["workers"] = workers;
                    
                }
            }
        }

        /// <summary>
        /// Calculates needed information and prints it when the second button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string Fr = Server.MapPath("App_Data/Rezults.txt");
            File.Delete(Fr);
            int S = 0;
            decimal K = 0;

            if (TextBox1.Text != "" && TextBox2.Text != "" && TaskUtils.ContainsLetter(TextBox1.Text) == false && TaskUtils.ContainsLetter(TextBox2.Text) == false)
            {
                S = int.Parse(TextBox1.Text);
                K = decimal.Parse(TextBox2.Text);
            }

            if (workers != null && parts != null)
            {
                richestWorker = TaskUtils.RichestWorker(workers, parts);

                singlePartMakers = TaskUtils.SinglePartMakers(workers, parts);
                singlePartMakers.Sort();

            }

            PrintRichestWorker(richestWorker);
           
            PrintSinglePartMakers(singlePartMakers);

            if (workers != null && parts != null && S != 0 && K != 0)
            {
                listByAttributes = TaskUtils.ListByAttributes(S, K, workers, parts);
                listByAttributes.Sort();
                
            }

            PrintTable5(listByAttributes);

            if (richestWorker.Surname != null)
            {
                InOutUtils.PrintRichestWorker(Fr, richestWorker);
            }

            if (singlePartMakers.ListExist() == true)
            {
                InOutUtils.PrintSinglePartMakers(Fr, singlePartMakers);
            }
            
            if (listByAttributes.ListExist() == true)
            {
                InOutUtils.PrintGivenData(Fr, listByAttributes, string.Format("Sudarytas naujas duomenų rinkinys pagal požymius S ir K:"));
            }

            if (richestWorker.Surname == null && singlePartMakers.ListExist() == false && listByAttributes.ListExist() == false)
            {
                File.Delete(Fr);
            }
        }
    }
}