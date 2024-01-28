using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Class of oven data
    /// </summary>
    public class Oven : Device
    {
        /// <summary>
        /// Oven power
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Oven number of programs
        /// </summary>
        public int NumberOfPrograms { get; set; }

        /// <summary>
        /// Oven class constructor
        /// </summary>
        /// <param name="type">Device type</param>
        /// <param name="power">Oven power</param>
        /// <param name="numberOfPrograms">Oven number of programs</param>
        /// <param name="maker">Oven maker</param>
        /// <param name="model">Oven model</param>
        /// <param name="energyClass">Oven energy class</param>
        /// <param name="color">Oven color</param>
        /// <param name="price">Oven price</param>
        public Oven(string type, double power, int numberOfPrograms, string maker, string model, string energyClass, string color, decimal price) : base(maker, model, energyClass, color, price, type)
        {
            this.Power = power;
            this.NumberOfPrograms = numberOfPrograms;
        }

        /// <summary>
        ///  Method that forms a line of data in text
        /// </summary>
        /// <returns>Formated string</returns>
        public override string ToString()
        {
            return string.Format("| {0, 15} | {1, 15} | {2, 15} | {3, 15} | {4, 15} | {5, -15} | {6, -15} | {7, 15} | {8, -28} | {9, -15} | {10, -15} | {11, -15} | {12, -15} | {13, -15} | {14, -15} | {15, -15} |", Type, Maker, Model, EnergyClass, Color, Price, "-", "-", "-", "-", "-", "-", "-", "-", Power, NumberOfPrograms);
        }

        /// <summary>
        /// Method finds out if information is equal or not
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>True of false value</returns>
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
            if (other is Oven)
            {
                return this.Power.CompareTo((other as Oven).Power);
            }
            return 0;
        }
    }
}