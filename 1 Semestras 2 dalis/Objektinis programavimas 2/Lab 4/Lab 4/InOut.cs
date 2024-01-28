using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab_4
{
    /// <summary>
    /// Class that reads and prints information
    /// </summary>
    public class InOut
    {
        /// <summary>
        /// Method that read information and forms a list
        /// </summary>
        /// <param name="fileName">Name of a data file</param>
        /// <returns>Formated list</returns>
        public static List<DevicesRegister> ReadFile(string fileName)
        {
            List<DevicesRegister> LibraryOfShops = new List<DevicesRegister>();

            foreach (string txtName in Directory.GetFiles(fileName, "*.txt"))
            {
                List<Device> Shop = new List<Device>();
                string[] lines = File.ReadAllLines(txtName);
                string shopName = lines[0];
                string shopAddress = lines[1];
                string phoneNumber = lines[2];
                for (int i = 3; i < lines.Length; i++)
                {
                    string[] Values = lines[i].Split(';');
                    string type = Values[0];
                    string maker = Values[1];
                    string model = Values[2];
                    string energyClass = Values[3];
                    string color = Values[4];
                    decimal price = decimal.Parse(Values[5]);

                    switch (type)
                    {
                        case "Fridge":
                            double capacity = double.Parse(Values[6]);
                            string mountingType = Values[7];
                            string has = Values[8];
                            bool hasFridge = false;
                            if (has == "turi šaldiklį")
                            {
                                hasFridge = true;
                            }
                            double hight = double.Parse(Values[9]);
                            double width = double.Parse(Values[10]);
                            double depth = double.Parse(Values[11]);
                            Fridge fridge = new Fridge(type, capacity, mountingType, hasFridge, hight, width, depth, maker, model, energyClass, color, price);
                            Shop.Add(fridge);
                            break;

                        case "Kettle":
                            double power = double.Parse(Values[6]);
                            double volume = double.Parse(Values[7]);
                            Kettle kettle = new Kettle(type, power, volume, maker, model, energyClass, color, price);
                            Shop.Add(kettle);
                            break;

                        case "Oven":
                            power = double.Parse(Values[6]);
                            int numberOfPrograms = int.Parse(Values[7]);
                            Oven oven = new Oven(type, power, numberOfPrograms, maker, model, energyClass, color, price);
                            Shop.Add(oven);
                            break;

                        default:
                            break;
                    }

                }
                DevicesRegister devices = new DevicesRegister(Shop, shopName, shopAddress, phoneNumber);
                LibraryOfShops.Add(devices);
            }
            return LibraryOfShops;
        }

        /// <summary>
        /// Method that prints initial data information to .txt file
        /// </summary>
        /// <param name="fileName">Name of a rezult file</param>
        /// <param name="allShops">List of information</param>
        public static void PrintToTxt(string fileName, List<DevicesRegister> allShops)
        {
            try
            {
                using (var writer = File.CreateText(fileName))
                {
                    foreach (DevicesRegister shop in allShops)
                    {
                        writer.WriteLine(shop.ShopName);
                        writer.WriteLine(shop.ShopAddress);
                        writer.WriteLine(shop.PhoneNumber);

                        writer.WriteLine(new string('-', 303));
                        writer.WriteLine(string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} | {15, -15} |", "Tipas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Požymis: turi šaldiklį ar ne", "Aukštis", "Plotis", "Gylis", "Galia", "Tūris", "Galingumas", "Programų skaičius"));
                        writer.WriteLine(new string('-', 303));
                        for (int i = 0; i < shop.Count(); i++)
                        {
                            writer.WriteLine(shop.Get(i).ToString());
                        }
                        writer.WriteLine(new string('-', 303));
                        writer.WriteLine();
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        /// <summary>
        /// Method that prints sertain maker's devices to .txt file
        /// </summary>
        /// <param name="fileName">Name of a rezult file</param>
        /// <param name="allShops">List of information</param>
        public static void PrintToTxtSertainItemsMakers(string fileName, List<DevicesRegister> allShops)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Skaičius „Siemens“ šaldytuvų, mikrobangų krosnelių ir virdulių modelių, kurį siūlo kiekviena parduotuvė:");
                foreach (DevicesRegister shop in allShops)
                {
                    writer.WriteLine("{0}", shop.NumberOfSertainMakersItems());
                    writer.WriteLine("Parduotuvės kontaktinė informacija:");
                    writer.WriteLine(shop.ShopName);
                    writer.WriteLine(shop.ShopAddress);
                    writer.WriteLine(shop.PhoneNumber);

                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        /// <summary>
        /// Method that print ten selected fridges to .csv file
        /// </summary>
        /// <param name="fileName">Name of a rezult file</param>
        /// <param name="tenFridges">List of fridges</param>
        public static void PrintTenFridges(string fileName, List<Device> tenFridges)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine("Dešimt pigiausių pastatomų šaldytuvų, kurių talpa yra 80 litrų ar didesnė:");
                writer.WriteLine(new string('-', 74));
                writer.WriteLine("| {0, -15} | {1, -15} | {2, 15} | {3, 15} |", "Gamintojas", "Modelis", "Talpa", "Kaina");
                writer.WriteLine(new string('-', 74));

                for (int i = 0; i < tenFridges.Count(); i++)
                {
                    Device device = tenFridges[i];
                    if (device is Fridge)
                    {
                        writer.WriteLine("| {0, -15} | {1, -15} | {2, 15} | {3, 15} |", device.Maker, (device as Fridge).MountingType, (device as Fridge).Capacity, device.Price);
                    }
                    
                }
                writer.WriteLine(new string('-', 74));

                writer.WriteLine();
                writer.Close();
            }
          
        }

        /// <summary>
        /// Method that prints certain information by a given type to .csv file
        /// </summary>
        /// <param name="fileName">Name of a rezult file</param>
        /// <param name="devices">List of devices</param>
        /// <param name="type">Certain type of devices</param>
        public static void PrintToCsv(string fileName, List<Device> devices, string type)
        {
            using (var writer = File.AppendText(fileName))
            { 

                for (int i = 0; i < devices.Count(); i++)
                {
                    if (devices[i].Type == type)
                    {
                        writer.WriteLine(devices[i].ToString());
                    }
                }

                writer.WriteLine();
                writer.Close();
            }
        }

       
    }
}