using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Parts node class
    /// </summary>
    public sealed class Node2
    {
        /// <summary>
        /// Data about a part
        /// </summary>
        public Part Data { get; private set; }

        /// <summary>
        /// A link to further information about parts 
        /// </summary>
        public Node2 Link { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">One part's information</param>
        public Node2(Part value)
        {
            this.Data = value;
            this.Link = null;
        }

        /// <summary>
        /// Allows to define data's information
        /// </summary>
        public Part SetData
        {
            set { this.Data = value; }
        }
    }
}