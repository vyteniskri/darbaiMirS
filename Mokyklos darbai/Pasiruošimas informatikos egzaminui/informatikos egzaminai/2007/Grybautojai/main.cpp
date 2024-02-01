#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    string vardas;
    int baravykai={0}, raudonvirsiai={0}, lepsiai={0};
};
void duomenys(int &n, prad A[]);
string daug(int n, prad A[]);
void rezultatai(int n, prad A[]);

int main()
{
    int n;
    prad A[101];
    duomenys(n, A);
    rezultatai(n, A);

}///Skaitau duomenis is failo
void duomenys(int &n, prad A[])
{
    int d, b, r, l;
    ifstream fd("U2.txt");
    fd >> n >> ws;
    char eil[16];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 16);
        A[i].vardas=eil;

        fd >> d >> ws;
        for(int j=0; j<d; j++)
        {
            fd >> b >> r >> l;
            A[i].baravykai=A[i].baravykai+b;
            A[i].raudonvirsiai=A[i].raudonvirsiai+r;
            A[i].lepsiai=A[i].lepsiai+l;
        }
        fd >> ws;
    }
    fd.close();
}///Spausdinu rezultatus
void rezultatai(int n, prad A[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<n; i++)
    {
        fr << A[i].vardas<< setw(6)<< A[i].baravykai<< setw(6)<< A[i].raudonvirsiai<< setw(6)<< A[i].lepsiai<<endl;
    }
    fr << daug(n, A)<<" ";
    for(int i=0; i<n; i++)
    {
        if(daug(n, A)==A[i].vardas)
        {
            fr << A[i].baravykai+A[i].raudonvirsiai+A[i].lepsiai;
        }
    }
    fr.close();

} ///Randu geriausia grybautoja
string daug(int n, prad A[])
{
    string v;
    int s=0;
    for(int i=0; i<n; i++)
    {
        if(A[i].baravykai+A[i].raudonvirsiai+A[i].lepsiai>s)
        {
            s=A[i].baravykai+A[i].raudonvirsiai+A[i].lepsiai;
            v=A[i].vardas;
        }
    }
    return v;
}
