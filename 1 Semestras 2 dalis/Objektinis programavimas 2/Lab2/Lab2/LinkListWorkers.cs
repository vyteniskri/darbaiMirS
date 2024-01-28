using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2
{
    /// <summary>
    /// Class that formats a list of workers
    /// </summary>
    public sealed class LinkListWorkers
    {
        /// <summary>
        /// Head of the information
        /// </summary>
        private Node1 head;

        /// <summary>
        /// Created for interface of list
        /// </summary>
        private Node1 d;

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkListWorkers()
        {
            this.head = new Node1(new Worker());
            this.d = null;
        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="worker">One worker</param>
        public void Add(Worker worker)
        {
            Node1 current = head;
            while (current.Link != null)
            {
                current = current.Link;
            }
            current.Link = new Node1(worker);
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
        ///  Method that return data according to the interface address
        /// </summary>
        /// <returns>Data of one worker</returns>
        public Worker Get()
        {
            return d.Data;
        }

        /// <summary>
        /// Return true if list has data
        /// </summary>
        /// <returns>If it's true or false</returns>
        public bool ListExist()
        {
            if (this.head.Link != null)
            {
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Method that finds out if list has specific data or not
        /// </summary>
        /// <param name="x">Specific data</param>
        /// <returns>If it is true or false</returns>
        public bool Contains(object x)
        {
            for (Node1 current = head.Link; current != null; current = current.Link)
            {
                if (current.Data.Equals(x))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method that sorts the list
        /// </summary>
        public void Sort()
        {
            for (Node1 d1 = head; d1 != null; d1 = d1.Link)
            {
                Node1 min = d1;
                for (Node1 d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    if (d2.Data < min.Data)
                    {
                        min = d2;
                        
                    }
                }
                Worker worker = d1.Data;
                d1.SetData = min.Data;
                min.SetData = worker;

            }
        }

    }
}