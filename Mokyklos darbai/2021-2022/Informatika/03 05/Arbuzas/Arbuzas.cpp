#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, double A[]);
double skaiciavimas(int n, double A[]);
void rezultatai(int n, double A[]);
int main()
{
    int n;
    double A[100];
    duomenys(n, A);
    skaiciavimas(n, A);
    rezultatai(n, A);

}
void duomenys(int &n, double A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];

    }
}
double skaiciavimas(int n, double A[])
{
    int vid, sum=0, did=0, maz=100;
    for(int i=0; i<n; i++)
    {
        sum=sum+A[i];
    }
    vid=sum/n;
    for(int i=0; i<n; i++)
    {
        if(A[i]<=vid && A[i]>did)
        {
            did=A[i];
        }
        if(A[i]>vid && A[i]<maz)
        {
            maz=A[i];
        }
    }
    if(vid-did==maz-vid)
    {
        return did;
    }
    else if(vid-did>maz-vid)
    {
        return maz;
    }
    else return did;


}
void rezultatai(int n, double A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n; i++)
    {

        if(skaiciavimas(n, A)==A[i])
        {
            fr << i+1;
            break;
        }
    }
    fr << " " << fixed << setprecision(2)<< skaiciavimas(n, A);
}


