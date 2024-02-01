#include <iostream>
#include <fstream>
using namespace std;
struct informacija
{
    string pavadinimas;
    int taskai, suma=0;
    int k=0;
};
void duomenys(int &n, informacija A[]);
void rikiavimas(int n, informacija A[]);
void rezultatai(int n, informacija A[]);

int main()
{
    int n;
    informacija A[20];
    duomenys(n, A);
    rikiavimas(n, A);
    rezultatai(n, A);
}
void duomenys(int &n, informacija A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> ws;
    char eil[26];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 26);
        A[i].pavadinimas=eil;

        for(int j=0; j<5; j++)
        {
            fd >> A[j].taskai;
            A[i].suma=A[i].suma+A[j].taskai;
            if(A[j].taskai==100)
            {
                A[i].k++;
            }

        }
        fd >> ws;
    }
}
void rikiavimas(int n, informacija A[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].k<A[j].k|| A[i].k==A[j].k && A[i].suma<A[j].suma)
            {
                swap(A[i],A[j]);
            }

        }
    }
}
void rezultatai(int n, informacija A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n; i++)
    {
        if(i<3)
        {
            cout << A[i].pavadinimas << " "<< A[i].suma << " "<< A[i].k<<endl;
        }
        else if(i=n-1)
        {
            cout << A[i].pavadinimas << " "<< A[i].suma << " "<< A[i].k<<endl;
        }

    }

}
