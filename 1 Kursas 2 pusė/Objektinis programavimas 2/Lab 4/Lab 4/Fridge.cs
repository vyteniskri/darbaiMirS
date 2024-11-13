using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Class of fridge data
    /// </summary>
    public class Fridge : Device 
    {
        /// <summary>
        /// Fridge capacity
        /// </summary>
        public double Capacity { get; set; }
        
        /// <summary>
        /// Fridge mounting type
        /// </summary>
        public string MountingType { get; set; }
        
        /// <summary>
        /// Fridge has a cooler or not
        /// </summary>
        public bool HasFridge { get; set; }

        /// <summary>
        /// Fridge hight
        /// </summary>
        public double Hight { get; set; }

        /// <summary>
        /// Fridge width
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Fridge depth
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Fridge constructor
        /// </summary>
        /// <param name="type">Device type</param>
        /// <param name="capacity">Fridge capacity</param>
        /// <param name="mountingType">Fridge mounting type</param>
        /// <param name="hasFridge">Fridge has a cooler or not</param>
        /// <param name="hight">Fridge hight</param>
        /// <param name="width">Fridge width</param>
        /// <param name="depth">Fridge depth</param>
        /// <param name="maker">Fridge maker</param>
        /// <param name="model">Fridge model</param>
        /// <param name="energyClass">Frdige energy class</param>
        /// <param name="color">Fridge color</param>
        /// <param name="price">Fridge price</param>
        public Fridge(string type, double capacity, string mountingType, bool hasFridge, double hight, double width, double depth, string maker, string model, string energyClass, string color, decimal price) : base(maker, model, energyClass, color, price, type)
        {
            this.Capacity = capacity;
            this.MountingType = mountingType;
            this.HasFridge = hasFridge;
            this.Hight = hight;
            this.Width = width;
            this.Depth = depth;
        }

        /// <summary>
        /// Method that forms a line of data in text
        /// </summary>
        /// <returns>Formated string</returns>
        public override string ToString()
        {
            return string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} | {15, -15} |", Type, Maker, Model, EnergyClass, Color, Price, Capacity, MountingType, HasFridge, Hight, Width, Depth, "-", "-", "-", "-");
        }

        /// <summary>
        /// Method finds out if information is equal or not
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>Ture or false value</returns>
        public override bool Equals(Device other)
        {
            return Type.CompareTo(other.Type) == 0 &&  Maker.CompareTo(other.Maker) == 0 && Model.CompareTo(other.Model) == 0 && EnergyClass.CompareTo(other.EnergyClass) == 0 && Color.CompareTo(other.Color) == 0 && Price.CompareTo(other.Price) == 0;
        }

        /// <summary>
        /// Method that compares information by hight
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>Int type value</returns>
        public override int CompareTo(Device other)
        {
            if (other is Fridge)
            {
                return this.Hight.CompareTo((other as Fridge).Hight);
            }
            return 0;
        }
    }
}