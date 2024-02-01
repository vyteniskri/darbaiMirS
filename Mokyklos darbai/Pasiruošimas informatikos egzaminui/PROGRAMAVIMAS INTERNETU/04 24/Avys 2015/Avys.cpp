#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    string fragmentas;
    int koficientas;
};
void duomenys(int &n, int &m, int &a, prad A[]);
int sutapimas(prad A, prad B, int m);
void rikiavimas(int n, prad A[], int a);
void rezultatai(int n, prad A[], int a);

int main()
{
    int n, m, a;
    prad A[20];
    duomenys(n, m, a, A);
    for(int i=0; i<n; i++)
    {
        A[i].koficientas = sutapimas(A[a-1], A[i], m);

    }

    rikiavimas(n, A, a);
    rezultatai(n, A, a);
}
//Duomenų nuskaitymo funkcija
void duomenys(int &n, int &m, int &a, prad A[])
{
    ifstream fd("U2.txt");
    fd >> n >> m;
    fd >> a >> ws;
    char eil[11];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 11);
        A[i].vardas=eil;

        fd >> A[i].fragmentas >>ws;



    }
}
// Funkcija diviejų avių DNR sutapimo koficientui apskaičiuoti
int sutapimas(prad A, prad B, int m)
{
    int k=0;
    for(int i=0; i<m; i++)
    {
        if(A.fragmentas[i]==B.fragmentas[i]) // Lyginu tiriamos avies ir atsitiktinai pasirinktos avies DNR
        {
            k++;
        }

    }
    return k;
}
// Rikiavimo funkcija
void rikiavimas(int n, prad A[], int a)
{
    for(int i=0; i<n; i++)
    {

        for(int j=i+1; j<n; j++)
        {

            if(A[i].koficientas<A[j].koficientas && A[i].vardas <A[j].vardas)
            {
                swap(A[i],A[j]);

            }

        }

    }
}
// Duomenų spausdinimo funkcija
void rezultatai(int n, prad A[], int a)
{
    ofstream fr("U2rez.txt");

    for(int i=0; i<n; i++)
    {
        if(i==0)
        {
            fr <<A[i].vardas<<endl;
        }
        else fr <<A[i].vardas << " "<<  A[i].koficientas<<endl;



    }
}
