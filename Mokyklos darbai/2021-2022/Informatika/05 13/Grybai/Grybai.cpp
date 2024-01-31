#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int M[],int D[], double Mase[], int B[], int R[]);
double derlingiausia(int n, double Mase[]);
int baravykai(int n, int B[]);
int raudonvirsiai(int n, int R[]);
int main()
{

   int n, M[100], D[100], B[100], R[100];
   double Mase[100];
   duomenys(n, M, D, Mase, B, R);

   for(int i=0; i<n; i++)
   {
       if(derlingiausia(n, Mase)==Mase[i])
       {
           cout << "Derlingiausias diena: " << M[i] << " "<< D[i]<<endl;
       }
   }
   for(int i=0; i<n; i++)
   {
       if(baravykai(n, B)==B[i])
       {
           cout << "Derlingiausias baravyku diena: " << M[i] << " "<< D[i]<<endl;
       }
   }
   for(int i=0; i<n; i++)
   {
       if(raudonvirsiai(n, R)==R[i])
       {
           cout << "Derlingiausias raudonvirsiu diena: " << M[i] << " "<< D[i]<<endl;
       }
   }
}
void duomenys(int &n, int M[],int D[], double Mase[], int B[], int R[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> M[i] >> D[i] >> Mase[i] >> B[i] >> R[i];
    }
    fd.close();
}
double derlingiausia(int n, double Mase[])
{
    double l=0;
    for(int i=0; i<n; i++)
    {
        if(Mase[i]>l)
        {
            l=Mase[i];
        }
    }
    return l;
}
int baravykai(int n, int B[])
{
    int l=0;
    for(int i=0; i<n; i++)
    {
        if(B[i]>l)
        {
            l=B[i];
        }
    }
    return l;
}
int raudonvirsiai(int n, int R[])
{
    int l=0;
    for(int i=0; i<n; i++)
    {
        if(R[i]>l)
        {
            l=R[i];
        }
    }
    return l;
}
