using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lab1
{
    [DataContract]
    internal class Student
    {
        [DataMember]
        public string Name;

        [DataMember]
        public int Year;

        [DataMember]
        public double Grade;

        public string hash;

        public Student(string name, int year, double grade)
        {
            this.Name = name;
            this.Year = year;
            this.Grade= grade; 
        }

        public void Calculate()
        {
            string dataToHash = $"{this.Name}{this.Year}{this.Grade}";

            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                this.hash = hashString;
                
            }

        }

    }
}
