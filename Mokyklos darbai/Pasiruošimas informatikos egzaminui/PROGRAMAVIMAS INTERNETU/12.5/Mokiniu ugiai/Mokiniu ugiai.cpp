#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n,int N[]);
int did(int n, int N[]);
int maz(int n, int N[]);
void rezultatai(int n, int N[]);
int main()
{
   int n, N[100];
   duomenys(n, N);
   rezultatai(n, N);
}
void duomenys(int &n,int N[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i =0; i<n; i++)
    {
        fd >> N[i];
    }
}
int did(int n, int N[])
{
    int a=0;
    for(int i=0; i<n;i++)
    {
        if (N[i]>a)
        {
            a=N[i];
        }
    }
    return a;
}
int maz(int n, int N[])
{
    int b=1000;
    for(int i=0; i<n; i++)
    {
        if (b>N[i])
        {
            b=N[i];
        }
    }
    return b;
}
void rezultatai(int n, int N[])
{
    ofstream fr ("Rezultatai.txt");
    fr << "Didziausias ugis: "<<did(n, N)<<endl;
    fr << "Maziausias ugis: "<<maz(n, N);
}


