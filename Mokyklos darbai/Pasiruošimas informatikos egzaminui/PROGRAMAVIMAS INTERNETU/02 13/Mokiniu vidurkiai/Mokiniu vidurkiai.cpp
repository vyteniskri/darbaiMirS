#include <iostream>
#include <fstream>
#include <iomanip>
#include <cmath>
using namespace std;
struct prad
{
    char vardas[20];
    string klase;
    int paz[100];
    double vidurkis;
    int a;
};
void duomenys(int &n, prad A[]);
double vidur(int n, int paz[]);
void rezultatai(int n, prad A[]);
prad didziausias(int n, prad A[]);
prad maziausias(int n, prad A[]);
int main()
{
   int n;
   prad A[100];
   duomenys(n, A);
    rezultatai(n, A);
}
void duomenys(int &n, prad A[])
{

    ifstream fd("Duomenys.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 20);

        fd >> A[i].klase >> A[i].a;
        for(int j=0; j<A[i].a; j++)
        {
            fd >> A[i].paz[j];

        }
        A[i].vidurkis = vidur(A[i].a, A[i].paz);
        fd >> ws;
    }
}
double vidur(int n, int paz[])
{

    double sum=0, vid;
        for(int i=0; i<n;i++)
        {
            sum=sum+ paz[i];
        }
        vid=sum/n;
        return vid;

}
void rezultatai(int n, prad A[])
{
    prad did = didziausias(n, A);
    prad maz = maziausias(n, A);
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n;i++)
    {
        if(A[i].klase!="0")
        {
        cout <<endl<< A[i].klase << endl;
        cout <<fixed << setprecision(1)<< A[i].vardas << " "<< A[i].vidurkis<< " ";
        cout << fixed << setprecision(0)<< round(A[i].vidurkis)<<endl;
        }

        for(int j=i+1;j<n;j++)
        {
            if(A[i].klase==A[j].klase && A[i].klase !="0")
            {

            cout <<fixed << setprecision(1)<< A[j].vardas << " "<< A[j].vidurkis<< " ";
            cout << fixed << setprecision(0)<< round(A[j].vidurkis)<<endl;
            A[j].klase = "0";
            }



        }
    }

    cout << endl << did.vardas << " "<< did.klase << endl;
    cout << maz.vardas << " "<< maz.klase << endl;

}
prad didziausias(int n, prad A[])
{
    prad d;
    d.vidurkis=0;
    for(int i=0; i<n;i++)
    {
        if(A[i].vidurkis > d.vidurkis)
        {
            d=A[i];cout << d.vidurkis <<endl; cout <<endl;
        }

    }
    return d;
}
prad maziausias(int n, prad A[])
{
    prad d;
    d.vidurkis=100;
    for(int i=0;i<n;i++)
    {
        if(A[i].vidurkis<d.vidurkis)
        {
            d=A[i];
        }
    }
    return d;
}

