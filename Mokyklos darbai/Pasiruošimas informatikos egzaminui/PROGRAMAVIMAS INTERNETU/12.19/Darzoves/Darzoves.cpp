#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(double &ak, double &bk, double &rk, double &n, double a[], double b[], double r[]);
void dar(double ak, double bk, double rk, double n, double a[], double b[], double r[], double a1[], double b1[], double r1[], double vand[]);
void rezultatai(double n, double a1[], double b1[], double r1[], double vand[]);
int main()
{
   double ak, bk, rk, n, a[100] , b[100], r[100], a1[100], b1[100], r1[100], vand[100];
   duomenys(ak, bk, rk, n, a, b, r);
   dar(ak, bk, rk, n, a, b, r, a1, b1, r1, vand);
   rezultatai(n, a1, b1, r1, vand);
}
void duomenys(double &ak, double &bk, double &rk, double &n, double a[], double b[], double r[])
{
    fstream fd ("Duomenys.txt");
    fd >> ak >> bk >> rk;
    fd >> n;
    for (int i=0; i<n; i++)
    {
        fd >> a[i] >> b[i] >> r[i];
    }
}
void dar(double ak, double bk, double rk, double n, double a[], double b[], double r[], double a1[], double b1[], double r1[], double vand[])
{
    for(int i=0; i<n;i++)
    {
        a1[i]=a[i]/ak;
        b1[i]=b[i]/bk;
        r1[i]=r[i]/rk;
        vand[i]= 100 -a1[i]-b1[i]-r1[i];

    }
}
void rezultatai(double n, double a1[], double b1[], double r1[], double vand[])
{
    ofstream fr ("Rezultatai.txt");
    for(int i=0; i<n; i++)
    {
        fr << fixed << setprecision(1);
        fr << a1[i] << " "<< b1[i]<< " "<< r1[i]<< " " << vand[i]<< endl;
    }
}
