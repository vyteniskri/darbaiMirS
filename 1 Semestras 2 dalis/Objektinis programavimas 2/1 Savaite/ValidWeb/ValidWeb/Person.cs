using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidWeb
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string School { get; set; }
        public string Age { get; set; }
        public string ProgramingLanguages { get; set; }

        public Person(string name, string surname, string school, string age, string programingLanguages)
        {
            this.Name = name;
            this.Surname = surname;
            this.School = school;
            this.Age = age;
            this.ProgramingLanguages = programingLanguages;
        }

    }
}