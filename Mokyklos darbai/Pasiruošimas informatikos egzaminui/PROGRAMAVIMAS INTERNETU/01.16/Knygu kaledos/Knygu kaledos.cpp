#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys (int &n, double x[], int y[]);
void piln(int n, double x[], int y[], double s[]);
void maz(int n, double x[], int y[], double s[]);
double suma(int n, double s[]);
int kiek(int n, int y[]);
void rezultatai(int n, double x[], int y[], double s[]);
int main()
{
    int n, y[100];
    double x[100],s[100];
    duomenys(n, x, y);
    piln(n, x, y, s);
    maz(n, x, y, s);
    rezultatai(n, x, y, s);
}
void duomenys (int &n, double x[], int y[])
{
    ifstream fd ("Duomenys1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> x[i] >> y[i];
    }
}
void piln(int n, double x[], int y[], double s[])
{
    for(int i=0; i<n; i++)
    {
        s[i]= x[i]*y[i];
    }
}
void maz(int n, double x[], int y[], double s[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i; j<n; j++)
        {
            if(x[i]>x[j])
            {
                swap(s[i], s[j]);
                swap(y[i], y[j]);
                swap(x[i], x[j]);
            }


        }
    }
}
double suma(int n, double s[])
{
    int a=0;
    for(int i=0; i<n; i++)
    {
        a= a + s[i];
    }
    return a;
}
int kiek(int n, int y[])
{
    int y1=0;
    for(int i =0; i<n; i++)
    {
        if(y[i]>5)
        {
            y1++;
        }
    }
    return y1;
}
void rezultatai(int n, double x[], int y[], double s[])
{
    ofstream fr("Rezultatai1.txt");
    for(int i =0; i<n; i++)
    {
        fr << fixed << setprecision(2)<<x[i]<< " " << y[i] << " " << s[i]<<endl;
    }
    fr << suma(n, s)<< endl;
    fr << kiek(n, y);
}
