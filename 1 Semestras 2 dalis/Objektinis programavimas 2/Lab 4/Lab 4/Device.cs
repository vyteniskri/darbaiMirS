using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_4
{
    /// <summary>
    /// Class of device data
    /// </summary>
    public abstract class Device : IEquatable<Device>, IComparable<Device>
    {
        /// <summary>
        /// Device maker
        /// </summary>
        public string Maker { get; set; }

        /// <summary>
        /// Device model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Device energy class
        /// </summary>
        public string EnergyClass { get; set; }

        /// <summary>
        /// Device color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Device price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Device type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Device class constructor
        /// </summary>
        /// <param name="maker">Device maker</param>
        /// <param name="model">Device model</param>
        /// <param name="energyClass">Device energy class></param>
        /// <param name="color">Device color</param>
        /// <param name="price">Device price</param>
        /// <param name="type">Device type</param>
        public Device(string maker, string model, string energyClass, string color, decimal price, string type)
        {
            this.Maker = maker;
            this.Model = model;
            this.EnergyClass = energyClass;
            this.Color = color;
            this.Price = price;
            this.Type = type;
        }

        /// <summary>
        /// An abstract Equals method
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>True of falce value</returns>
        public abstract bool Equals(Device other);

        /// <summary>
        /// An abstract CompareTo method
        /// </summary>
        /// <param name="other">Device information</param>
        /// <returns>True of falce value</returns>
        public abstract int CompareTo(Device other);

    }
}