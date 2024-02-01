#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys (int &n, int k[], double vk[]);
void pilnoskainos (int n, int k[], double vk[], double kiek[]);
double kiekkainavo(int n, double kiek[]);
int daugiau5(int n, int k[]);
void Rezultatai(int n, int k[], double vk[], double kiek[]);
int main()
{
    int n, k[20];
    double vk[20], kiek[20];
    duomenys(n, k, vk);
    pilnoskainos(n, k, vk, kiek);
    Rezultatai(n, k, vk, kiek);

}
void duomenys (int &n, int k[], double vk[])
{
    ifstream fd ("prekes.txt");
    fd >> n;
    for (int i = 0; i<n; i++)
    {
        fd >> vk[i] >> k[i];
    }
    fd.close();

}
void pilnoskainos (int n, int k[], double vk[], double kiek[])
{

    for (int i = 0; i<n; i++)
    {
        kiek[i] = vk[i] * k[i];
    }
}
double kiekkainavo(int n, double kiek[])
{
    double sum = 0;
    for (int i = 0; i<n; i++)
    {
        sum = sum + kiek[i];
    }
    return sum;
}
int daugiau5(int n, int k[])
{
    int l=0;
    for(int i = 0; i<n; i++)
    {
        if (k[i]>5)
        {
            l++;
        }
    }
    return l;
}
void Rezultatai(int n, int k[], double vk[], double kiek[])
{
    ofstream fr ("rezultatai.txt");
    for (int i = 0; i<n; i++)
    {

        fr << vk[i] << " "<< k[i]<<" "<< fixed << setprecision (2)<< kiek[i]<<endl;
    }


    fr << kiekkainavo(n, kiek) <<endl<<daugiau5(n, k);
    fr.close();
}

