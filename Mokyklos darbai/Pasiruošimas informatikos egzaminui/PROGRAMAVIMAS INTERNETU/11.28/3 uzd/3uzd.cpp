#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int k[], int r[], int b[], double vnt[]);
void nebrokuotos(int n,  int r[], int b[], double vnt[], int n0[], double n1[], double n2[]);
int brokuotu(int n, int b[]);
double visosdetales(int n, double n2[]);
double nuostoliai(int n, int b[], double vnt[], double n2[]);
void Rezultatai (int n, int k[], int r[], int b[], int n0[], double vnt[], double n1[], double n2[]);

int main()
{

    int n;
    int k[1000], r[1000], b[1000], n0[1000];
    double vnt[1000], n1[1000], n2[1000];
    duomenys(n, k, r, b, vnt);
    nebrokuotos(n, r, b, vnt, n0, n1, n2);
    Rezultatai(n, k, r, b, n0, vnt, n1, n2);

}
void duomenys(int &n, int k[], int r[], int b[], double vnt[])
{
    ifstream fd ("detales.txt");
    fd >> n;
    for (int i=0; i<n;i++)
    {
        fd >> k[i] >> r[i]>> vnt[i]>> b[i];

    }
}
void nebrokuotos(int n,  int r[], int b[], double vnt[], int n0[], double n1[], double n2[])
{


    for (int i=0; i<n;i++)
    {
        n0[i] = r[i]-b[i];
        n1[i] = vnt[i]*n0[i];
        n2[i] = r[i]*vnt[i];
    }
}
int brokuotu(int n, int b[])
{
    int sum=0;
    for (int i=0; i<n;i++)
    {

        sum=sum+b[i];
    }
    return sum;
}
double visosdetales(int n, double n2[])
{
        double suma=0;
     for (int i=0; i<n;i++)
     {

         suma=suma+n2[i];


     }

   return suma;

}
double nuostoliai(int n, int b[], double vnt[], double n2[])
{
   double k1, sum=0;
    double  nuost;
     for (int i=0; i<n;i++)
     {

        k1=b[i]*vnt[i];
            sum = sum + k1;

     }
       nuost= (sum*100/visosdetales(n, n2));

   return nuost;
}
void Rezultatai (int n, int k[], int r[], int b[], int n0[], double vnt[], double n1[], double n2[])
{
     ofstream fr ("detalesz.txt");
     for(int i=0;i<n;i++)
     {
        fr  << k[i] << " " << r[i]<< " "<< vnt[i]<< " "<< b[i]<< " " << n0[i]<< " "<< fixed << setprecision(2) << n1[i] << " "<< n2[i] << endl;

     }


     fr << brokuotu(n, b)<< endl<< fixed << setprecision(2)<<visosdetales(n, n2) << endl<< nuostoliai(n, b, vnt, n2);


}
