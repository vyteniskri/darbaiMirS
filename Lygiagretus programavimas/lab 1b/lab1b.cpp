#include <iostream>
#include <iostream>
#include <fstream>
#include <nlohmann/json.hpp>
#include <openssl/sha.h>
#include <omp.h>
#include <iomanip>
using namespace std;
using Jjson = nlohmann::json;

class Student
{
public:
    string Name;
    int Year;
    double Grade;
    string hash;

    Student() : Name(""), Year(0), Grade(0.0), hash("") {}

    Student(string name, int year, double grade)
        : Name(name), Year(year), Grade(grade) {}

    void Calculate()
    {
        string dataToHash = Name + to_string(Year) + to_string(Grade);

        unsigned char hashBytes[SHA_DIGEST_LENGTH];
        SHA1((const unsigned char*)dataToHash.c_str(), dataToHash.length(), hashBytes);

        char hashChars[2 * SHA_DIGEST_LENGTH + 1]; // +1 for null terminator

        for (int i = 0; i < SHA_DIGEST_LENGTH; i++)
        {
            snprintf(&hashChars[i * 2], 3, "%02x", (int)hashBytes[i]);
        }

        hash = hashChars;
    }
};

int main()
{
    string filePath1 = "IFF-1-1_KrisciunasVytenis_L1_dat_1.json"; //visi tinka
    string filePath2 = "IFF-1-1_KrisciunasVytenis_L1_dat_2.json"; //dalis tinka
    string filePath3 = "IFF-1-1_KrisciunasVytenis_L1_dat_3.json"; //neivienas netinka
    vector<Student> students;
    int Count;

    ifstream file(filePath1);
    Jjson json;
    file >> json;
    file.close();

    Jjson studentsJson = json["students"];
    Count = studentsJson.size();

    for (const auto& studentJson : studentsJson) {
        Student student(studentJson["name"], studentJson["year"], studentJson["grade"]);
        students.push_back(student);
    }

    for (auto& student : students) {
        student.Calculate();
        cout << student.Name << " " << student.Year << " " << student.Grade << " " << student.hash << endl;
    }


    vector<Student> accumulatedStudents(Count);
    double total_sum = 0;
    int index = 0;

    int numThreads = 7;
    int numStudents = students.size();
    int chunkSize = numStudents / numThreads;
    int extra = numStudents % numThreads;
   
    #pragma omp parallel num_threads(numThreads) shared(students) reduction(+ : total_sum)
    {
        int tid = omp_get_thread_num();  
        int start = tid * chunkSize + min(tid, extra);
        int end = (tid == numThreads - 1) ? numStudents : start + chunkSize + (tid < extra);

        for (int i = start; i < end; i++) 
        {
            
            Student student = students[i];
            student.Calculate();
            if (isalpha(student.hash[0]))
            {
                total_sum += student.Year + student.Grade;

                #pragma omp critical
                {
                    char firstSymbol = student.hash[0];
                    if (index == 0)
                    {
                        accumulatedStudents[index] = student;
                        index++;
                    }
                    else
                    {
                        for (int i = 0; i < index; i++)
                        {
                            char currentStudentFirstS = accumulatedStudents[i].hash[0];

                            if (firstSymbol <= currentStudentFirstS)
                            {
                                for (int j = index; j > i; j--)
                                {
                                    accumulatedStudents[j] = accumulatedStudents[j - 1];
                                }
                                accumulatedStudents[i] = student;
                                index++;
                                break;
                            }
                            else if ((i + 1) == index && firstSymbol >= currentStudentFirstS)
                            {
                                accumulatedStudents[i + 1] = student;
                                index++;
                                break;
                            }
                            else if ((i + 1) != index && firstSymbol >= currentStudentFirstS && firstSymbol <= accumulatedStudents[i + 1].hash[0])
                            {

                                for (int j = index; j > i + 1; j--)
                                {
                                    accumulatedStudents[j] = accumulatedStudents[j - 1];
                                }
                                accumulatedStudents[i + 1] = student;
                                index++;
                                break;
                            }


                        }
                    }
                    
                }
                
            }
        }

    }


    cout << "Pradiniu duomenu kiekis: " <<  Count << endl;
    cout << endl;
    cout << "Rezultatu duomenu kiekis: " << index << endl;
    cout << total_sum << endl;
    for (auto& student : accumulatedStudents)
    {
        if (student.Name != "")
        {
            cout << student.Name << " " << student.Year << " " << student.Grade << " " << student.hash << endl;
        }

    }

    string rezultFile = "IFF-1-1_KrisciunasVytenis_L1b_rez.txt";

    ofstream writer(rezultFile, ios::out | ios::trunc);

    writer << setw(78) << right << "Pradiniai duomenys" << '\n';
    writer << string(137, '-') << '\n';
    writer << setw(30) << right << "Name" << "| " << setw(30) << right << "Year" << "| " <<  setw(30) << right << "Grade" << "| " << setw(40) << right << "Hash" << "| " << '\n';
    writer << string(137, '-') << '\n';

    for (const auto& student : students) {
        writer << setw(30) << right << student.Name << "| " << setw(30) << right << to_string(student.Year) << "| " << setw(30) << right << to_string(student.Grade) << "| " << setw(40) << right << student.hash << "|" << '\n';
    }

    writer << '\n' << '\n';

    writer << setw(78) << right << "Rezultatai" << '\n';
    writer << string(137, '-') << '\n';
    writer << setw(30) << right << "Name" << "| " << setw(30) << right << "Year" << "| " << setw(30) << right << "Grade" << "| " << setw(40) << right << "Hash" << "| " << '\n';
    writer << string(137, '-') << '\n';

    for (const auto& student : accumulatedStudents) {
        if (student.Name != "")
        {
            writer << setw(30) << right << student.Name << "| " << setw(30) << right << to_string(student.Year) << "| " << setw(30) << right << to_string(student.Grade) << "| " << setw(40) << right << student.hash << "|" << '\n';
        }  
    }

    writer << "Int ir Float lauku suma: " << total_sum << '\n';

    writer.close();
}

