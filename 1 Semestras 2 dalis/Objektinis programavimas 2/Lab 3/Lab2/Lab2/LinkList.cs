using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Lab3
{
    /// <summary>
    /// Class that formats a list of given data
    /// </summary>
    public sealed class LinkList<T> : IEnumerable<T> where T : IComparable<T>, new()
    {
        private sealed class Node
        {
            /// <summary>
            /// Information about given data
            /// </summary>
            public T Data { get; private set; }

            /// <summary>
            /// A link to further information about given data
            /// </summary>
            public Node Link { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="value">Data's information</param>
            public Node(T value)
            {
                this.Data = value;
                this.Link = null;
            }

            /// <summary>
            /// Allows to define data's information
            /// </summary>
            public T SetData
            {
                set { this.Data = value; }
            }


        }

        /// <summary>
        /// Head of the information
        /// </summary>
        private Node head;

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkList()
        {
            this.head = new Node(new T());

        }

        /// <summary>
        /// Method that adds information to the list
        /// </summary>
        /// <param name="worker">Given data</param>
        public void Add(T data)
        {
            Node current = head;
            while (current.Link != null)
            {
                current = current.Link;
            }
            current.Link = new Node(data);
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
            for (Node current = head.Link; current != null; current = current.Link)
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
        /// <param name="first">Returns first member of the list</param>
        public void Sort(out T first)
        {
            int x = 0;
            first = default(T);

            for (Node d1 = head.Link; d1 != null; d1 = d1.Link)
            {
                Node min = d1;
                for (Node d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    if (d2.Data.CompareTo(min.Data) < 0)
                    {
                        min = d2;
                        
                    }
                }
                T worker = d1.Data;
                d1.SetData = min.Data;
                min.SetData = worker;

                if (x == 0)
                {
                    first = d1.Data;
                }
                x++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node dd = head.Link; dd != null; dd = dd.Link)
            {
                yield return dd.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}