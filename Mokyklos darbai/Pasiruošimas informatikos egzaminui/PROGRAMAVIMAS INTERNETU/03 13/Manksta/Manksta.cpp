#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string pavadinimas;
    int kiek;
};
void duomenys(int &n, prad A[]);
void salinimas(int &n, prad A[]);
void rikiavimas(int n, prad A[]);
void rezultatai(int n, prad A[]);
int main()
{
    int n;
    prad A[100];
    duomenys (n, A);
    salinimas(n, A);
    rikiavimas(n, A);
    rezultatai(n, A);


}
void duomenys(int &n, prad A[])
{
    ifstream fd("U2.txt");
    fd >> n >> ws;
    for(int i=0; i<n;i++)
    {
        char eil[21];
        fd.get(eil, 21);
        A[i].pavadinimas = eil;
        fd >> A[i].kiek >> ws;

    }
}
void salinimas(int &n, prad A[])
{
    for(int i=0; i<n;i++)
    {
        for(int j=i+1; j<n;j++)
        {
            if(A[i].pavadinimas == A[j].pavadinimas)
            {
                A[i].kiek = A[i].kiek + A[j].kiek;
                for(int z=j; z<n; z++)
                {
                    A[z]=A[z+1];
                }
                n--;
                j--;
            }
        }
    }
}
void rikiavimas(int n, prad A[])
{
    for(int i=0; i<n;i++)
    {
        for(int j=i; j<n;j++)
        {
            if(A[i].kiek<A[j].kiek || A[i].kiek == A[j].kiek && A[i].pavadinimas>A[j].pavadinimas)
            {
                swap(A[i],A[j]);
            }
        }

    }
}
void rezultatai(int n, prad A[])
{
    ofstream fr("U2.rez");
   for(int i=0; i<n; i++)
    {
        cout << A[i].pavadinimas << " "<< A[i].kiek <<endl;
    }
}
