#include <iostream>
#include <fstream>
using namespace std;
struct avis
{
    string vardas;
    string fragmentas;
    int koficientas;
};
void duomenys(int &n, int &m, int &nr, avis A[]);
int sutapimas(avis H, avis A, int m);
void rikiavimas(int n, avis A[]);
void rezultatai(int n, avis A[], int nr);
int main()
{
   int n, m, nr;
   avis A[20];
   duomenys(n, m, nr, A);
   for(int i=0; i<n; i++)
   {
       A[i].koficientas = sutapimas(A[nr-1], A[i], m);

   }
   rikiavimas(n, A);
   rezultatai(n, A, nr);
}///Duomenu spausdinimo funkcija
void duomenys(int &n, int &m, int &nr, avis A[])
{
    ifstream fd("U2.txt");
    fd >> n >> m;
    fd >> nr >> ws;
    char eil[11];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 11);
        A[i].vardas=eil;
        fd >> A[i].fragmentas >> ws;


    }
}
int sutapimas(avis H, avis A, int m)
{
    int k=0;
    for(int i=0; i<m; i++)
    {
        if(H.fragmentas[i]==A.fragmentas[i])
        {
            k++;
        }
    }
    return k;
} ///Rikiavimo funkcija
void rikiavimas(int n, avis A[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].koficientas<A[j].koficientas)
            {
                swap(A[i], A[j]);
            }
            if(A[i].koficientas==A[j].koficientas && A[i].vardas > A[j].vardas)
            {
                swap(A[i], A[j]);
            }
        }
    }
}///Duomenu spausdinimo funkcija
void rezultatai(int n, avis A[], int nr)
{
    ofstream fr("U2rez.txt");
    fr << A[0].vardas<<endl;
    for(int i=0; i<n; i++)
    {
        if(i!=0)
        {
            fr << A[i].vardas << " "<<  A[i].koficientas<<endl;
        }

    }
}
