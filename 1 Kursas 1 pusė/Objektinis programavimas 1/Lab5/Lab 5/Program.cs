using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
//Main function of this program is to do all kinds of calculations with different basketball team's members information

//Vytenis Kriščiūnas

namespace Lab_5
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd1 = @"FirstYearPlayers.txt";
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd2 = @"SecondYearPlayers.txt";
        /// <summary>
        /// Represents a .txt file from which data will be read
        /// </summary>
        const string CFd3 = @"ThirdYearPlayers.txt";
        /// <summary>
        /// Represents a .txt file where data will be put
        /// </summary>
        const string CFr1 = "Rezultatai.txt";
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr2 = "Senbuviai.csv";
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr3 = "Aukštaūgiai.csv";
        /// <summary>
        /// Represents a .csv file where data will be put
        /// </summary>
        const string CFr4 = "Masažuotojai.csv";

        static void Main(string[] args)
        {
            File.Delete(CFr1);
            File.Delete(CFr4);
            MembersConteiner members1 = InOutUtils.ReadPlayers(CFd1);
            MembersConteiner members2 = InOutUtils.ReadPlayers(CFd2);
            MembersConteiner members3 = InOutUtils.ReadPlayers(CFd3);

            Register MembersOfTheFirstYear = new Register(members1);
            Register MembersOfTheSecondYear = new Register(members2);
            Register MembersOfTheThirdYear = new Register(members3);

            InOutUtils.PrintToTxt(MembersOfTheFirstYear, CFr1);
            InOutUtils.PrintToTxt(MembersOfTheSecondYear, CFr1);
            InOutUtils.PrintToTxt(MembersOfTheThirdYear, CFr1);

            // 1 punktas
            Member youngest = MembersOfTheFirstYear.YoungestStaffMember();
            Console.WriteLine("Jauniausias į rinktinę pakviestas personalo narys iš pirmųjų metų sąrašo:");
            if (youngest == null)
            {
                Console.WriteLine("Nėra personalo narių.");
            }
            else 
                 Console.WriteLine("{0};{1};{2}", youngest.Name, youngest.Surname, youngest.Age);
            Console.WriteLine();

            youngest = MembersOfTheSecondYear.YoungestStaffMember();
            Console.WriteLine("Jauniausias į rinktinę pakviestas personalo narys iš antrųjų metų sąrašo:");
            if (youngest == null)
            {
                Console.WriteLine("Nėra personalo narių.");
            }
            else
                Console.WriteLine("{0};{1};{2}", youngest.Name, youngest.Surname, youngest.Age);
            Console.WriteLine();

            youngest = MembersOfTheThirdYear.YoungestStaffMember();
            Console.WriteLine("Jauniausias į rinktinę pakviestas personalo narys iš trečiųjų metų sąrašo:");
            if (youngest == null)
            {
                Console.WriteLine("Nėra personalo narių.");
            }
            else
                Console.WriteLine("{0};{1};{2}", youngest.Name, youngest.Surname, youngest.Age);
            Console.WriteLine();

            // 2 punktas
            MembersConteiner playedInClub = MembersOfTheFirstYear.PlayedInClub("Žalgiris");
            playedInClub.Sort();
            Console.WriteLine("Krepšininkai žaidę Žalgiryje iš pirmųjų metų sąrašo:");
            if (playedInClub.Count == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            else
                InOutUtils.PrintClubPlayers(playedInClub);
            Console.WriteLine();

            playedInClub = MembersOfTheSecondYear.PlayedInClub("Žalgiris");
            playedInClub.Sort();
            Console.WriteLine("Krepšininkai žaidę Žalgiryje iš antrųjų metų sąrašo:");
            if (playedInClub.Count == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            else
                InOutUtils.PrintClubPlayers(playedInClub);
            Console.WriteLine();

            playedInClub = MembersOfTheThirdYear.PlayedInClub("Žalgiris");
            playedInClub.Sort();
            Console.WriteLine("Krepšininkai žaidę Žalgiryje iš trečiųjų metų sąrašo:");
            if (playedInClub.Count == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra.");
            }
            else
                InOutUtils.PrintClubPlayers(playedInClub);
            Console.WriteLine();

            // 3 punktas
            MembersConteiner beenToAllCamps = TaskUtils.BeenInAllCamps(MembersOfTheFirstYear, MembersOfTheSecondYear, MembersOfTheThirdYear);
            InOutUtils.PrintToCsvBeenToCamps(beenToAllCamps, CFr2);

            // 4 Punktas
            int hight = 200;
            MembersConteiner TwoMetersOrHigher1 = MembersOfTheFirstYear.TwoMetersOrHigher(hight);
            MembersConteiner TwoMetersOrHigher2 = MembersOfTheSecondYear.TwoMetersOrHigher(hight);
            MembersConteiner TwoMetersOrHigher3 = MembersOfTheThirdYear.TwoMetersOrHigher(hight);
            MembersConteiner filteredPlayers = TaskUtils.FilteredByHight(TwoMetersOrHigher1, TwoMetersOrHigher2, TwoMetersOrHigher3);
            InOutUtils.PrintToCsvHighestPlayers(filteredPlayers, CFr3);

            string type = "masažuotojas";
            string text = "Masažuotojai iš pirmojo sąrašo";
            MembersConteiner selectedStaff1 = MembersOfTheFirstYear.MassageStaff(type);
            InOutUtils.PrintToCsvMassageStaffMembers(selectedStaff1, CFr4, text);

            text = "Masažuotojai iš antrojo sąrašo";
            MembersConteiner selectedStaff2 = MembersOfTheSecondYear.MassageStaff(type);
            InOutUtils.PrintToCsvMassageStaffMembers(selectedStaff2, CFr4, text);

            text = "Masažuotojai iš trečiojo sąrašo";
            MembersConteiner selectedStaff3 = MembersOfTheThirdYear.MassageStaff(type);
            InOutUtils.PrintToCsvMassageStaffMembers(selectedStaff3, CFr4, text);

            if (selectedStaff1.Count == 0 && selectedStaff2.Count == 0 && selectedStaff3.Count == 0)
            {
                File.Delete(CFr4);
            }

        }
    }
}
