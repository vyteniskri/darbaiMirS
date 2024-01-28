using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab_4
{
    /// <summary>
    /// Class that forms tables
    /// </summary>
    public partial class Main : System.Web.UI.Page
    {
        /// <summary>
        /// Method that creates first table of given data
        /// </summary>
        /// <param name="allShops">List of all devices</param>
        protected void CreateTable(List<DevicesRegister> allShops)
        {
            foreach (DevicesRegister shop in allShops)
            {
                TableRow row1 = new TableRow();

                TableCell Cell1 = new TableCell();
                Cell1.Text = string.Format("{0}",shop.ShopName);
                row1.Cells.Add(Cell1);
                row1.CssClass = "ShopInformation";
                Table1.Rows.Add(row1);

                TableRow row2 = new TableRow();

                TableCell Cell2 = new TableCell();
                Cell2.Text = string.Format("{0}", shop.ShopAddress);
                row2.Cells.Add(Cell2);

                TableCell Cell20 = new TableCell();
                Cell20.Text = "Parduotuvės informacija";
                row2.Cells.Add(Cell20);
                row2.CssClass = "ShopInformation";
                Table1.Rows.Add(row2);
                
                TableRow row3 = new TableRow();

                TableCell Cell3 = new TableCell();
                Cell3.Text = string.Format("{0}", shop.PhoneNumber);
                row3.Cells.Add(Cell3);
                row3.CssClass = "ShopInformation";
                Table1.Rows.Add(row3);

                TableRow row = new TableRow();

                TableCell cell0 = new TableCell();
                cell0.Text = "Tipas";
                row.Cells.Add(cell0);

                TableCell cell1 = new TableCell();
                cell1.Text = "Gamintojas";
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = "Modelis";
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "Energijos klasė";
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "Spalva";
                row.Cells.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "Kaina";
                row.Cells.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "Talpa";
                row.Cells.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "Montavimo tipas";
                row.Cells.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "Požymis: turi šaldiklį ar ne";
                row.Cells.Add(cell8);

                TableCell cell9 = new TableCell();
                cell9.Text = "Aukštis";
                row.Cells.Add(cell9);

                TableCell cell10 = new TableCell();
                cell10.Text = "Plotis";
                row.Cells.Add(cell10);

                TableCell cell11 = new TableCell();
                cell11.Text = "Gylis";
                row.Cells.Add(cell11);

                TableCell cell12 = new TableCell();
                cell12.Text = "Galia";
                row.Cells.Add(cell12);

                TableCell cell13 = new TableCell();
                cell13.Text = "Tūris";
                row.Cells.Add(cell13);

                TableCell cell14 = new TableCell();
                cell14.Text = "Galingumas";
                row.Cells.Add(cell14);

                TableCell cell15 = new TableCell();
                cell15.Text = "Programų skaičius";
                row.Cells.Add(cell15);
                row.CssClass = "Header";
                Table1.Rows.Add(row);

                for (int i = 0; i < shop.Count(); i++)
                {
                    Device device = shop.Get(i);

                    TableRow newRow = new TableRow();

                    TableCell newCell0 = new TableCell();
                    newCell0.Text = string.Format("{0}", device.Type);
                    newRow.Cells.Add(newCell0);

                    TableCell newCell1 = new TableCell();
                    newCell1.Text = string.Format("{0}", device.Maker);
                    newRow.Cells.Add(newCell1);

                    TableCell newCell2 = new TableCell();
                    newCell2.Text = string.Format("{0}", device.Model);
                    newRow.Cells.Add(newCell2);

                    TableCell newCell3 = new TableCell();
                    newCell3.Text = string.Format("{0}", device.EnergyClass);
                    newRow.Cells.Add(newCell3);

                    TableCell newCell4 = new TableCell();
                    newCell4.Text = string.Format("{0}", device.Color);
                    newRow.Cells.Add(newCell4);

                    TableCell newCell5 = new TableCell();
                    newCell5.Text = string.Format("{0}", device.Price);
                    newRow.Cells.Add(newCell5);

                    if (device is Fridge)
                    {
                        TableCell newCell6 = new TableCell();
                        newCell6.Text = string.Format("{0}", (device as Fridge).Capacity);
                        newRow.Cells.Add(newCell6);

                        TableCell newCell7 = new TableCell();
                        newCell7.Text = string.Format("{0}", (device as Fridge).MountingType);
                        newRow.Cells.Add(newCell7);

                        TableCell newCell8 = new TableCell();
                        newCell8.Text = string.Format("{0}", (device as Fridge).HasFridge);
                        newRow.Cells.Add(newCell8);

                        TableCell newCell9 = new TableCell();
                        newCell9.Text = string.Format("{0}", (device as Fridge).Hight);
                        newRow.Cells.Add(newCell9);

                        TableCell newCell10 = new TableCell();
                        newCell10.Text = string.Format("{0}", (device as Fridge).Width);
                        newRow.Cells.Add(newCell10);

                        TableCell newCell11 = new TableCell();
                        newCell11.Text = string.Format("{0}", (device as Fridge).Depth);
                        newRow.Cells.Add(newCell11);
                    }

                    if (device is Kettle)
                    {
                        TableCell newCell6 = new TableCell();
                        newCell6.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell6);

                        TableCell newCell7 = new TableCell();
                        newCell7.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell7);

                        TableCell newCell8 = new TableCell();
                        newCell8.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell8);

                        TableCell newCell9 = new TableCell();
                        newCell9.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell9);

                        TableCell newCell10 = new TableCell();
                        newCell10.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell10);

                        TableCell newCell11 = new TableCell();
                        newCell11.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell11);

                        TableCell newCell12 = new TableCell();
                        newCell12.Text = string.Format("{0}", (device as Kettle).Power);
                        newRow.Cells.Add(newCell12);

                        TableCell newCell13 = new TableCell();
                        newCell13.Text = string.Format("{0}", (device as Kettle).Volume);
                        newRow.Cells.Add(newCell13);
                    }

                    if (device is Oven)
                    {
                        TableCell newCell6 = new TableCell();
                        newCell6.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell6);

                        TableCell newCell7 = new TableCell();
                        newCell7.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell7);

                        TableCell newCell8 = new TableCell();
                        newCell8.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell8);

                        TableCell newCell9 = new TableCell();
                        newCell9.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell9);

                        TableCell newCell10 = new TableCell();
                        newCell10.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell10);

                        TableCell newCell11 = new TableCell();
                        newCell11.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell11);

                        TableCell newCell12 = new TableCell();
                        newCell12.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell12);

                        TableCell newCell13 = new TableCell();
                        newCell13.Text = string.Format("{0}", " ");
                        newRow.Cells.Add(newCell13);

                        TableCell newCell14 = new TableCell();
                        newCell14.Text = string.Format("{0}", (device as Oven).Power);
                        newRow.Cells.Add(newCell14);

                        TableCell newCell15 = new TableCell();
                        newCell15.Text = string.Format("{0}", (device as Oven).NumberOfPrograms);
                        newRow.Cells.Add(newCell15);
                    }

                    Table1.Rows.Add(newRow);
                }
     
            }
        }

        /// <summary>
        /// Method that print information to second table
        /// </summary>
        /// <param name="allShops">List of all data</param>
        protected void PrintTable2(List<DevicesRegister> allShops)
        {
            foreach (DevicesRegister shop in allShops)
            {
                TableRow row1 = new TableRow();

                TableCell Cell1 = new TableCell();
                Cell1.Text = string.Format("{0}", shop.ShopName);
                row1.Cells.Add(Cell1);
                row1.CssClass = "ShopInformation";
                Table2.Rows.Add(row1);

                TableRow row2 = new TableRow();

                TableCell Cell2 = new TableCell();
                Cell2.Text = string.Format("{0}", shop.ShopAddress);
                row2.Cells.Add(Cell2);

                TableCell Cell20 = new TableCell();
                Cell20.Text = "Parduotuvės informacija";
                row2.Cells.Add(Cell20);
                row2.CssClass = "ShopInformation";
                Table2.Rows.Add(row2);

                TableRow row3 = new TableRow();

                TableCell Cell3 = new TableCell();
                Cell3.Text = string.Format("{0}", shop.PhoneNumber);
                row3.Cells.Add(Cell3);
                row3.CssClass = "ShopInformation";
                Table2.Rows.Add(row3);

                TableRow row4 = new TableRow();

                TableCell Cell4 = new TableCell();
                Cell4.Text = string.Format("{0}", shop.NumberOfSertainMakersItems());
                row4.Cells.Add(Cell4);
                Table2.Rows.Add(row4);
            }
        }

        /// <summary>
        /// Method that forms a third table
        /// </summary>
        /// <param name="tenFridges">List of ten fridges</param>
        protected void PrintTable3(List<Device> tenFridges)
        {
            TableRow row = new TableRow();

            TableCell cell1 = new TableCell();
            cell1.Text = "Gamintojas";
            row.Cells.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Text = "Modelis";
            row.Cells.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.Text = "Talpa";
            row.Cells.Add(cell3);

            TableCell cell4 = new TableCell();
            cell4.Text = "Kaina";
            row.Cells.Add(cell4);

            row.CssClass = "Header";
            Table3.Rows.Add(row);

            for (int i = 0; i < tenFridges.Count(); i++)
            {
                TableRow newRow = new TableRow();

                TableCell Cell1 = new TableCell();
                Cell1.Text = string.Format("{0}", tenFridges[i].Maker);
                newRow.Cells.Add(Cell1);

                TableCell Cell2 = new TableCell();
                Cell2.Text = string.Format("{0}", (tenFridges[i] as Fridge).MountingType);
                newRow.Cells.Add(Cell2);

                TableCell Cell3 = new TableCell();
                Cell3.Text = string.Format("{0}", (tenFridges[i] as Fridge).Capacity);
                newRow.Cells.Add(Cell3);

                TableCell Cell4 = new TableCell();
                Cell4.Text = string.Format("{0}", (tenFridges[i] as Fridge).Price);
                newRow.Cells.Add(Cell4);

                Table3.Rows.Add(newRow);
            }

        }

    }
}