using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Class of kettle data
    /// </summary>
    public class Kettle : Device
    {
        /// <summary>
        /// Kettle's power
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Kettle's volume
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Kettle's class constructor
        /// </summary>
        /// <param name="type">Device type</param>
        /// <param name="power">Kettle power</param>
        /// <param name="volume">Kettle volume</param>
        /// <param name="maker">Kettle maker</param>
        /// <param name="model">Kettle model</param>
        /// <param name="energyClass">Kettle energy class</param>
        /// <param name="color">Kettle color</param>
        /// <param name="price">Kettle price</param>
        public Kettle(string type, double power, double volume, string maker, string model, string energyClass, string color, decimal price) : base(maker, model, energyClass, color, price, type)
        {
            this.Power = power;
            this.Volume = volume;
        }

        /// <summary>
        /// Method that forms a line of data in text
        /// </summary>
        /// <returns>Formated string</returns>
        public override string ToString()
        {
            return string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} | {15, -15} |", Type, Maker, Model, EnergyClass, Color, Price, "-", "-", "-", "-", "-", "-", Power,  Volume, "-", "-");
        }

        /// <summary>
        /// Method finds out if information is equal or not
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>True or false value</returns>
        public override bool Equals(Device other)
        {
            return Type.CompareTo(other.Type) == 0 && Maker.CompareTo(other.Maker) == 0 && Model.CompareTo(other.Model) == 0 && EnergyClass.CompareTo(other.EnergyClass) == 0 && Color.CompareTo(other.Color) == 0 && Price.CompareTo(other.Price) == 0;
        }

        /// <summary>
        /// Method that compares information by hight
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>Int type value</returns>
        public override int CompareTo(Device other)
        {
            if (other is Kettle)
            {
                return this.Power.CompareTo((other as Kettle).Power);
            }
            return 0;
        }
    }
}