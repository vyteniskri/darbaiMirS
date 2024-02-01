#include <iostream>
#include <fstream>
using namespace std;
struct pratimai ///Struktura skirta Vytauto duomenims saugoti
{
    string pavadinimas;
    int kiek, viso=0;
};
void duomenys(int &n, pratimai A[]);
void rikiavimas(pratimai A[], int n);
int main()
{
    ofstream fr("U2rez.txt");
    int n;
    pratimai A[100];
    duomenys(n, A);
    rikiavimas(A, n);
    for(int i=0; i<n; i++)
    {
        fr << A[i].pavadinimas << " "<< A[i].viso<<endl;
    }

}///Duomenu spausdinimo funkcija
void duomenys(int &n, pratimai A[])
{
    ifstream fd("U2.txt");
    fd >> n >> ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].pavadinimas = eil;
        fd >> A[i].kiek >> ws;


    }
    for(int i=0; i<n; i++)
    {
        A[i].viso=A[i].kiek;
        for(int j=i+1; j<n; j++)
        {
            if(A[i].pavadinimas ==A[j].pavadinimas)
            {
                A[i].viso=A[i].viso+ A[j].kiek;
                for(int z=j; z<n; z++)
                {
                    A[z]=A[z+1];
                }
                j--;
                n--;
            }
        }

    }
}///Duomenu rikiavimo funkcija
void rikiavimas(pratimai A[], int n)
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].viso<A[j].viso)
            {
                swap(A[i], A[j]);
            }
        }
    }
}
