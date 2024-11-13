using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Register of devices list
    /// </summary>
    public class DevicesRegister
    {
        /// <summary>
        /// List of all data
        /// </summary>
        private List<Device> AllData;

        /// <summary>
        /// Name of the shop
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Address of the shop
        /// </summary>
        public string ShopAddress { get; set; }

        /// <summary>
        /// Shop's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// DeviceRegister class constructor
        /// </summary>
        /// <param name="data">List of all data</param>
        /// <param name="shopName">Name of the shop</param>
        /// <param name="shopAddress">Address of the shop</param>
        /// <param name="phoneNumber">Shop's phone number</param>
        public DevicesRegister(List<Device> data, string shopName, string shopAddress, string phoneNumber)
        {
            this.AllData = data;
            this.ShopName = shopName;
            this.ShopAddress = shopAddress;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Method that count the number of total data
        /// </summary>
        /// <returns>Int type value</returns>
        public int Count()
        {
            return AllData.Count;
        }

        /// <summary>
        /// Method that gives information about one device
        /// </summary>
        /// <param name="index">Int type variable</param>
        /// <returns>Single device</returns>
        public Device Get(int index)
        {
            return AllData[index];
        }

        /// <summary>
        /// Method that finds a number of sertain maker's devices
        /// </summary>
        /// <returns>Int type valiable</returns>
        public int NumberOfSertainMakersItems()
        {
            int sum = 0;

            for (int i = 0; i < AllData.Count(); i++)
            {
                if (AllData[i].Maker == "Siemens")
                {
                    sum++;
                }
            }
            return sum;
        }

        /// <summary>
        /// Method that forms a list of fridges
        /// </summary>
        /// <returns>List of fridges</returns>
        public List<Device> AllFridges()
        {
            List<Device> fridges = new List<Device>();

            for (int i = 0; i < AllData.Count(); i++)
            {
                if (AllData[i] is Fridge)
                {
                    fridges.Add(AllData[i]);
                }
            }
            return fridges;
        }

        /// <summary>
        /// Method that forms a list of expencive devices
        /// </summary>
        /// <returns>List of expencive devices</returns>
        public List<Device> ExpenciveDevices()
        {
            List<Device> expencive = new List<Device>();

            for (int i = 0; i < AllData.Count(); i++)
            {
                if (AllData[i] is Fridge && (AllData[i] as Fridge).Price > 1000)
                {
                    expencive.Add(AllData[i]);
                }
                else if (AllData[i] is Oven && (AllData[i] as Oven).Price > 500)
                {
                    expencive.Add(AllData[i]);
                }
                else if (AllData[i] is Kettle && (AllData[i] as Kettle).Price > 50)
                {
                    expencive.Add(AllData[i]);
                }
            }
            return expencive;
        }
        
    }
}