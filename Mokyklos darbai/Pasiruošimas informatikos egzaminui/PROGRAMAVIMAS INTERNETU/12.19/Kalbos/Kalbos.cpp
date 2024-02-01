#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int a[], int b[], int c[],int d[]);
void kalbu(int a[], int b[], int c[],int d[], int sk[]);
void duomenys(int sk[]);
int main()
{
    int a[100], b[100], c[100], d[100];
    int sk[100];
    duomenys(a, b, c, d);
    kalbu(a, b, c, d, sk);
    duomenys(sk);
}
void duomenys(int a[], int b[], int c[],int d[])
{
    ifstream fd ("Duomenys.txt");
    for(int i=0; i<5; i++)
    {
        fd >> a[i] >> b[i]>> c[i] >> d[i];
    }
}
void kalbu(int a[], int b[], int c[],int d[],int sk[])
{
    for(int i=0; i<5; i++)
    {
        sk[i] = a[i]+b[i]+c[i]+d[i];

    }
}
void duomenys(int sk[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<5;i++)
    {
        fr << sk[i]<< endl;
    }
}

