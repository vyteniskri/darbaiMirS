#include <iostream>
#include <fstream>
using namespace std;

struct duomenys
   {
       string vardas;
       int taskai;

   };

void nuskaitymas(int &n, duomenys D[]);
void ats(int n, duomenys D[], int an, duomenys A[]);
void atrinkimas(int n, duomenys D[], int &an, duomenys A[]);
int suma(int n, duomenys D[], int an, duomenys A[]);

int main()
{
   int n, an=0;
   duomenys D[100], A[100];
   nuskaitymas(n, D);
   ats(n, D, an, A);
   atrinkimas(n, D, an, A);



}
void nuskaitymas(int &n, duomenys D[])
{
    ifstream fd("Duota.txt");
    fd >> n;
    for(int i=0; i<n;i++)
    {
        fd >> D[i].vardas >> D[i].taskai;
    }
}
void atrinkimas(int n, duomenys D[], int &an, duomenys A[])
{
    for(int i=0; i<n;i++)
    {
        if(D[i].taskai>15)
        {
            A[an]=D[i];
            an++;
        }
    }
}
int suma(int n, duomenys D[], int an, duomenys A[])
{
    int s=0;
    for(int i=0; i<n; i++)
    {
        s=s+D[i].taskai;
    }
    return s;
}
void ats(int n, duomenys D[], int an, duomenys A[])
{
    ofstream fr("Rezultai.txt");
    for(int i=0; i<n;i++)
    {
        cout << D[i].vardas << D[i].taskai<< endl;
    }
    cout << "vidutiniskai "<< suma(n, D, an, A)<< endl;
    cout << "vidutiniskai surinko "<< suma(n, D, an, A)<< endl;

}
