using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Class that formats a list of parts
    /// </summary>
    public sealed class LinkListParts
    {
        /// <summary>
        /// Head of the information
        /// </summary>
        private Node2 head;

        /// <summary>
        /// Created for interface of list
        /// </summary>
        private Node2 d;

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkListParts()
        {
            this.head = new Node2(new Part());
            this.d = null;
        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="part">Single part</param>
        public void Add(Part part)
        {
            Node2 current = head;
            while (current.Link != null)
            {
                current = current.Link;
            }
            current.Link = new Node2(part);
        }

        /// <summary>
        /// Address of the head of the list is assigned
        /// </summary>
        public void Begin()
        {
            d = head.Link;
        }

        /// <summary>
        /// Interface variable gets address of the next entry
        /// </summary>
        public void Next()
        {
            d = d.Link;
        }

        /// <summary>
        /// Return true, if list is empty
        /// </summary>
        /// <returns>If it's true or false</returns>
        public bool Exist()
        {
            return d != null;
        }

        /// <summary>
        /// Method that return data according to the interface address
        /// </summary>
        /// <returns>Data of one part</returns>
        public Part Get()
        {
            return d.Data;
        }
    }
}