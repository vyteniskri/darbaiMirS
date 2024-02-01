#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas, pavadinimas[30];
    int mase[30], taskai, suma=0, sk;
};
void duomenys(int &n, prad A[], int &k, prad B[]);
void rikiavimas(int o, prad H[]);
void rezultatai(int n, int k, prad A[], prad B[]);

int main()
{
    int n, k;
    prad A[30], B[30];
    duomenys(n, A, k, B);
    rikiavimas(n, A);
    rikiavimas(k, B);
    rezultatai(n, k, A, B);

}///Duomenu skaitymo funkcija
void duomenys(int &n, prad A[], int &k, prad B[])
{
    int sk;
    ifstream fd("U2.txt");
    fd >> n >> ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].vardas=eil;
        fd >> A[i].sk >> ws;

        for(int j=0; j<A[i].sk; j++)
        {
            fd.get(eil, 21);
            A[i].pavadinimas[j]=eil;
            fd >> A[i].mase[j] >> ws;

            if (A[i].mase[j]>=200)
            {
                A[i].suma=A[i].suma+30;
            }
            else A[i].suma=A[i].suma+10;
        }
        fd >> ws;
    }
    fd >> k >> ws;

    for(int i=0; i<k; i++)
    {
        fd.get(eil, 21);
        B[i].vardas=eil;

        fd >> A[i].taskai >> ws;

        for(int j=0; j<n; j++)
        {
            for(int z=0; z<A[j].sk; z++)
            {
                if(B[i].vardas==A[j].pavadinimas[z])
                {
                    A[j].suma=A[j].suma+A[i].taskai;
                    B[i].suma=B[i].suma+A[j].mase[z];

                }
            }
        }
    }

} ///Rikiavimo funkcija i kuria kreipiuosi 2 kartus
void rikiavimas(int o, prad H[])
{
    for(int i=0; i<o; i++)
    {
        for(int j=i+1; j<o; j++)
        {
            if(H[i].suma < H[j].suma || H[i].suma == H[j].suma && H[i].vardas< H[j].vardas)
            {
                swap(H[i], H[j]);
            }
        }
    }
}///Rezultatu spausdinimo funkcija
void rezultatai(int n, int k, prad A[], prad B[])
{
    ofstream fr("U2rez.txt");
    fr << "Dalyviai"<<endl;
    for(int i=0; i<n; i++)
    {
        fr << A[i].vardas <<" "<< A[i].suma<<endl;
    }
    fr << "Laimikis"<<endl;
    for(int i=0; i<k; i++)
    {
        fr << B[i].vardas << " "<< B[i].suma<<endl;
    }

}
