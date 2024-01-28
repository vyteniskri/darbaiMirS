using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValidWeb
{
    public partial class Forma1 : System.Web.UI.Page
    {

        private List<Person> users;
        private int Nr;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 14; i <= 25; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }

            TableRow row = new TableRow();

            TableCell Number = new TableCell();
            Number.Text = "<b>Nr.</b>";
            row.Cells.Add(Number);

            TableCell Name = new TableCell();
            Name.Text = "<b>Vardas</b>";
            row.Cells.Add(Name);

            TableCell Surname = new TableCell();
            Surname.Text = "<b>Pavardė</b>";
            row.Cells.Add(Surname);

            TableCell School = new TableCell();
            School.Text = "<b>Mokykla</b>";
            row.Cells.Add(School);

            TableCell Age = new TableCell();
            Age.Text = "<b>Amžius</b>";
            row.Cells.Add(Age);

            TableCell ProgramingLanguages = new TableCell();
            ProgramingLanguages.Text = "<b>Programavimo kalbos</b>";
            row.Cells.Add(ProgramingLanguages);

            Table1.Rows.Add(row);

            users = Session["users"] as List<Person>;
            if (users == null)
            {
                users = new List<Person>();
            }
            
            int index = 1;
            foreach (Person user in users)
            {
                TableFill(index, user.Name, user.Surname, user.School, user.Age, user.ProgramingLanguages);
                index++;
            }
            Nr = index;

            Label7.Text = "Bendras užsiregistravusių žmonių skaičius: " + --index;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string surname = TextBox2.Text;
            string school = TextBox3.Text;
            string age = DropDownList1.Text;
            string programingLanguages = "";

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    programingLanguages = programingLanguages + CheckBoxList1.Items[i].Value + ", ";
                }
            }
            programingLanguages = programingLanguages.TrimEnd(',', ' ');

            int number = Nr;

            Person person = new Person(name, surname, school, age, programingLanguages);

            TableFill(number, name, surname, school, age, programingLanguages);

            users.Add(person);

            Session["users"] = users;

            Label7.Text = "Bendras užsiregistravusių žmonių skaičius: " + number;
        }

        private void TableFill(int number,  string name, string surname, string school, string age, string programingLanguages)
        {
            TableRow row = new TableRow();

            TableCell Number = new TableCell();
            Number.Text = number.ToString();

            TableCell Name = new TableCell();
            Name.Text = name;

            TableCell Surname = new TableCell();
            Surname.Text = surname;

            TableCell School = new TableCell();
            School.Text = school;

            TableCell Age = new TableCell();
            Age.Text = age;

            TableCell ProgramingLanguages = new TableCell();
            ProgramingLanguages.Text = programingLanguages;

            row.Cells.Add(Number);
            row.Cells.Add(Name);
            row.Cells.Add(Surname);
            row.Cells.Add(School);
            row.Cells.Add(Age);
            row.Cells.Add(ProgramingLanguages);

            Table1.Rows.Add(row);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("users");
            Label7.Text = "Bendras užsiregistravusių žmonių skaičius: 0";
            for (int i = Table1.Rows.Count-1; i > 0; i--)
            {
                Table1.Rows.RemoveAt(i);
            }
        }

    }
}