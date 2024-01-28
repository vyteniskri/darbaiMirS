using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Workers node class
    /// </summary>
    public sealed class Node1
    {
        /// <summary>
        /// Data about a worker
        /// </summary>
        public Worker Data { get; private set; }

        /// <summary>
        /// A link to further information about workers 
        /// </summary>
        public Node1 Link { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">One worker's information</param>
        public Node1(Worker value)
        {
            this.Data = value;
            this.Link = null;
        }

        /// <summary>
        /// Allows to define data's information
        /// </summary>
        public Worker SetData
        {
            set { this.Data = value; }
        }

    }
}