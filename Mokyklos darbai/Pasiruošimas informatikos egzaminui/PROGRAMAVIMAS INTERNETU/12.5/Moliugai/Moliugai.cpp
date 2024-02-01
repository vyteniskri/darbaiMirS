#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void Duomenys ( int &n, double &p1, double &p2, double A[]);
void skaiciavimas(int n, double p1, double p2, double A[],double B[], double &sum, double &vid, int &k);
double vidurkis(int n, double A[]);
void Rezultatai (int n, double p1, double p2, double A[], double B[], double sum, double vid, int k);
int main()
{
    int n;
    double p1, p2, A[100], B[100], sum=0, vid;
    int k=0;
    Duomenys (n, p1, p2, A);
    skaiciavimas(n, p1, p2, A, B, sum, vid, k);
    Rezultatai (n, p1, p2, A, B, sum, vid, k);

}
void Duomenys ( int &n, double &p1, double &p2, double A[])
{
    ifstream fd ("Duomenys.txt");
    fd >> n;
    fd >> p1;
    fd >> p2;
    for (int i=0; i<n; i++)
    {
        fd >> A[i];

    }
    fd.close();
}
void skaiciavimas(int n, double p1, double p2, double A[], double B[], double &sum, double &vid, int &k)
{


    for (int i=0; i<n; i++)
    {
        if (p1<=A[i] && p2>=A[i])
        {
            sum = sum + A[i];




         B[k]=A[i];

         k++;
        }
    }
    vid = sum/k;
}
double vidurkis(int n, double A[])
{
    double suma=0;
    for (int i=0; i<n; i++)
    {
        suma=suma+A[i];
    }
    double vidur;
    vidur=suma/n;

    return vidur;
}
void Rezultatai (int n, double p1, double p2, double A[], double B[], double sum, double vid, int k)
{
    ofstream fr ("Rezultatai.txt");
    fr << fixed << setprecision (3)<<vidurkis(n, A) << endl << k << endl << vid << endl;
    for (int i=0; i<k; i++)
    {
        fr << B[i] << " ";
    }
}
