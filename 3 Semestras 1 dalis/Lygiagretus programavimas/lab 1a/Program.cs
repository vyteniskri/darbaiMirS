using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath1 = "..\\..\\..\\IFF-1-1_KrisciunasVytenis_L1_dat_1.json";
            string filePath2 = "..\\..\\..\\IFF-1-1_KrisciunasVytenis_L1_dat_2.json";
            string filePath3 = "..\\..\\..\\IFF-1-1_KrisciunasVytenis_L1_dat_3.json";
            Student[] students = null;
            int Count;

            using (StreamReader file = File.OpenText(filePath1))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    
                    JObject json = (JObject)JToken.ReadFrom(reader);
                    JArray studentsJson = (JArray)json["students"];
                    students = new Student[studentsJson.Count];
                    Count = studentsJson.Count;

                    for (int i = 0; i < studentsJson.Count; i++)
                    {
                        JObject studentJson = (JObject)studentsJson[i];
                        Student student = new Student((string)studentJson["name"], (int)studentJson["year"], (double)studentJson["grade"]);
                        students[i] = student;
                    }

                    
                }
            }

            for (int i = 0; i < students.Length; i++)
            {
                students[i].Calculate();
                Console.WriteLine("{0} {1} {2} {3}", students[i].Name, students[i].Year, students[i].Grade, students[i].hash);
            }

            

            DataMonitor dataMonitor = new DataMonitor(Count);
            SortedResultMonitor sortedResultMonitor = new SortedResultMonitor(Count);

            object ob = new object();

            var threads = Enumerable.Range(0, 5).Select(_ =>
            {
                var worker = new WorkerThread(ob);
                return new Thread(() => worker.removeData(dataMonitor, sortedResultMonitor));
            }).ToList();

            foreach (var thread in threads)
            {
                thread.Start();
                
            }
            
           

            foreach (Student student in students)
            {
                
                if (dataMonitor.Count == Count / 2)
                {
                    
                    while (true)
                    {
                        if (dataMonitor.Count < Count / 2)
                        {
                           
                            break;
                        }
                    }
                }
                dataMonitor.AddItem(student);
               
            }
           

            foreach (var thread in threads)
            {
                thread.Join();
                
            }

            Console.WriteLine("Pradiniu duomenu kiekis: {0}", Count);
            Console.WriteLine();
            Console.WriteLine("Rezultatu duomenu kiekis: {0}", sortedResultMonitor.Count);
            for (int i = 0; i < sortedResultMonitor.Count; i++)
            {
                Student student = sortedResultMonitor.GetItem();
                Console.WriteLine("{0} {1} {2} {3}", student.Name, student.Year, student.Grade, student.hash);

            }
            
            
            string rezultFile = "..\\..\\..\\IFF-1-1_KrisciunasVytenis_L1a_rez.txt";

            using (StreamWriter writer = new StreamWriter(rezultFile, false, Encoding.UTF8))
            {
                writer.WriteLine("{0, 78}", "Pradiniai duomenys");
                writer.WriteLine(new string('-', 137));
                writer.WriteLine("{0, 30}| {1, 30}| {2, 30}| {3, 40}", "Name", "Year", "Grade", "Hash");
                writer.WriteLine(new string('-', 137));

                for (int i = 0; i < students.Length; i++)
                {
                    
                    writer.WriteLine(string.Format("{0, 30}| {1, 30}| {2, 30}| {3, 30}", students[i].Name, students[i].Year, students[i].Grade, students[i].hash));
                }

                writer.WriteLine();
                writer.WriteLine();

                writer.WriteLine("{0, 78}", "Rezultatai");
                writer.WriteLine(new string('-', 137));
                writer.WriteLine("{0, 30}| {1, 30}| {2, 30}| {3, 40}", "Name", "Year", "Grade", "Hash");
                writer.WriteLine(new string('-', 137));

                for (int i = 0; i < sortedResultMonitor.Count; i++)
                {
                    Student student = sortedResultMonitor.GetItem();
                    writer.WriteLine(string.Format("{0, 30}| {1, 30}| {2, 30}| {3, 30}", student.Name, student.Year, student.Grade, student.hash));
                }

                writer.Close();
            }
            
        }
    }

}
