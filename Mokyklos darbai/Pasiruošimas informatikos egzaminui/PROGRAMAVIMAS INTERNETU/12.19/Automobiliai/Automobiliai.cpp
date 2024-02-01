#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int pm[], int v[], int &m, int &p, double ak[]);
void prad(int n, int pm[], int m, int p, double ak[], double k[]);
void rezultatai(int n, int pm[], int v[], double ak[], double k[]);
int main()
{
    int n, pm[100], v[100], m, p;
    double ak[100], k[100];
    duomenys(n, pm, v, m, p, ak);
    prad(n, pm, m, p, ak, k);
    rezultatai(n, pm, v, ak, k);
}
 void duomenys(int &n, int pm[], int v[], int &m, int &p, double ak[])
 {
     ifstream fd ("Duomenys.txt");
     fd >> n;
     for(int i=0; i<n;i++)
     {
         fd >> pm[i] >> v[i] >> ak[i];
     }
     fd >> m >> p;

 }
void prad(int n, int pm[], int m, int p, double ak[], double k[])
{

    for(int i=0; i<n;i++)
    {
        k[i]=ak[i]/((m-pm[i])/double (p));

    }
}
void rezultatai(int n, int pm[], int v[], double ak[], double k[])
{
    ofstream fr ("Rezultatai.txt");
    for (int i=0; i<n;i++)
    {
        fr << fixed << setprecision(2);
        fr << i+1 << " "<< pm[i] << " "<< v[i]<< " "<< ak[i]<< " "<< k[i]<< endl;
    }
}
