#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;
struct prad
{
    string pavadinimas;
    double atstumas, laikas=0;
};
void duomenys(int &n, prad A[]);
void skaiciavimai(int km, prad A[], int h, int m, int n);
void rezultatai(int n, prad A[]);

int main()
{
    int n;
   prad A[100];
    duomenys(n, A);
    rezultatai(n, A);

}
void duomenys(int &n, prad A[])
{
    int km, h, m;
    ifstream fd("Duom2.txt");
    fd >> n >> km >> h >> m >> ws;

    char eil[16];
    for(int i=0; i<n; i++)
    {



        fd.get(eil, 16);
        A[i].pavadinimas=eil;
        fd >> A[i].atstumas;

        fd >> ws;


    }
    skaiciavimai(km, A, h, m, n);
}
void skaiciavimai(int km, prad A[], int h, int m, int n)
{
    double sum=0;
    for(int i=0; i<n; i++)
    {
        if(i==0)
        {
            sum=h*60+m;
        }
        sum=sum+A[i].atstumas/km*60;
        A[i].laikas=sum;


    }


}///Duomenu spausdinimo funkcija
void rezultatai(int n, prad A[])
{
    ofstream fr("Rez2.txt");
    for(int i=0; i<n; i++)
    {
        fr << A[i].pavadinimas<< round(A[i].laikas/60)<< " val. "<< int (A[i].laikas)%60<< " min."<<endl;
    }
}
