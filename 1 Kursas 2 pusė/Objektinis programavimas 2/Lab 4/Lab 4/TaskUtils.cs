using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Class for sertain calcultaions
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Method that forms a list of all fridges 
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>Formated list</returns>
        private static List<Device> AllFridges(List<DevicesRegister> shops)
        {
            List<Device> allFridges = new List<Device>();

            foreach (DevicesRegister shop in shops)
            {
                List<Device> fridges = shop.AllFridges();

                for (int i = 0; i < fridges.Count(); i++)
                {
                    if (!allFridges.Exists(x => x.Equals(fridges[i])))
                    {
                        allFridges.Add(fridges[i]);
                    }
                }
            }
            return allFridges;
        }

        /// <summary>
        /// Method that forms a list of sorted fridges by price
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>formated list</returns>
        private static List<Device> SortedFridges(List<DevicesRegister> shops)
        {
            List<Device> allFridges = AllFridges(shops);

            for (int i = 0; i < allFridges.Count(); i++)
            {
                for (int j = i + 1; j < allFridges.Count(); j++)
                {
                    if (allFridges[j].Price < allFridges[i].Price)
                    {
                        Device device = allFridges[i];
                        allFridges[i] = allFridges[j];
                        allFridges[j] = device;
                    }
                }
            }
            return allFridges;
        }

        /// <summary>
        /// Method that filters list of fridges by mounting type and capacity
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>Formated list</returns>
        private static List<Device> FilteredFridges(List<DevicesRegister> shops)
        {
            List<Device> sortedFridges = SortedFridges(shops);
            List<Device> filteredFridges = new List<Device>();

            for (int i = 0; i < sortedFridges.Count(); i++)
            {
                if ((sortedFridges[i] as Fridge).MountingType == "Pastatomas" && (sortedFridges[i] as Fridge).Capacity >= 80)
                {
                    filteredFridges.Add(sortedFridges[i]);
                }
            }
            return filteredFridges;
        }

        /// <summary>
        /// Method that forms a list of first ten fridges
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>Formated list</returns>
        public static List<Device> TenSelectedFridges(List<DevicesRegister> shops)
        {
            List<Device> allFridges = FilteredFridges(shops);

            List<Device> onlyTenFridges = new List<Device>();

            for (int i = 0; i < allFridges.Count(); i++)
            {
                if (i == 10)
                {
                    break;
                }
                onlyTenFridges.Add(allFridges[i]);
            }
            return onlyTenFridges;
        }

        /// <summary>
        /// Method that finds out if a device exsist only in one shop or not
        /// </summary>
        /// <param name="index">An index of certain place in the list</param>
        /// <param name="shops">List of all devices</param>
        /// <param name="device">Certain device</param>
        /// <returns>True or false value</returns>
        private static bool Exsist(int index, List<DevicesRegister> shops, Device device)
        {
            int x = 0;
            foreach (DevicesRegister shop in shops)
            {
                if (x != index)
                {
                    for (int i = 0; i < shop.Count(); i++)
                    {
                        if (shop.Get(i).Equals(device))
                        {
                            return true;
                        }
                    }
                }
                x++;
            }
            return false;
        }

        /// <summary>
        /// Method that forms a list of devices that belong only in one shop
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>Formated list</returns>
        public static List<Device> OnlyThere(List<DevicesRegister> shops)
        {
            List<Device> onlyThere = new List<Device>();

            int index = 0;
            foreach (DevicesRegister shop in shops)
            {
                for (int i = 0; i < shop.Count(); i++)
                {
                    if(Exsist(index, shops, shop.Get(i)) == false)
                    {
                        onlyThere.Add(shop.Get(i));
                    }
                }
                index++;
            }
            return onlyThere;
        }

        /// <summary>
        /// Method that forms a list of all expencive devices
        /// </summary>
        /// <param name="shops">List of all devices</param>
        /// <returns>Formated list</returns>
        public static List<Device> AllExpenciveDevices(List<DevicesRegister> shops)
        {
            List<Device> allExpenciveDevices = new List<Device>();

            foreach (DevicesRegister shop in shops)
            {
                List<Device> expenciveDevices = shop.ExpenciveDevices();

                for (int i = 0; i < expenciveDevices.Count(); i++)
                {
                    if (!allExpenciveDevices.Exists(x => x.Equals(expenciveDevices[i])))
                    {
                        allExpenciveDevices.Add(expenciveDevices[i]);
                    }
                }
            }

            return allExpenciveDevices;
        }

        /// <summary>
        /// Method that sorts a list of expencive devies by sertain atributes
        /// </summary>
        /// <param name="expenciveDevices">List of expenncive devices</param>
        public static void Sort(List<Device> expenciveDevices)
        {
            for (int i = 0; i < expenciveDevices.Count(); i++)
            {
                for (int j = i + 1; j < expenciveDevices.Count(); j++)
                {
                    if (expenciveDevices[j].CompareTo(expenciveDevices[i]) < 0)
                    {
                        Device device = expenciveDevices[i];
                        expenciveDevices[i] = expenciveDevices[j];
                        expenciveDevices[j] = device;

                    }
                }
            }
        }
    }
}