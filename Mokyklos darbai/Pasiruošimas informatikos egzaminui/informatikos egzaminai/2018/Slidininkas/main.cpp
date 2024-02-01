#include <iostream>
#include <fstream>
using namespace std;
struct dalyviai
{
    string vardas;
    int h, m, s, laikas;
};
void duomenys(int &n, int &m, dalyviai A[]);
void rikiavimas(dalyviai A[], int m);
void rezultatai(int m, dalyviai A[]);
int main()
{
   int n, m;
   dalyviai A[30];
   duomenys(n, m, A);
   rikiavimas(A, m);
   rezultatai(m, A);

} // Duomenu skaitymo funkcija
void duomenys(int &n, int &m, dalyviai A[])
{
    ifstream fd("U2.txt");
    string vardas[30];
    int H[30], M[30], S[30];
     char eil[21];
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        vardas[i]=eil;

        fd >> H[i] >> M[i] >> S[i] >> ws;

    }
    fd >> m >> ws;
    for(int i=0; i<m; i++)
    {
        fd.get(eil, 21);
        A[i].vardas=eil;
        fd >> A[i].h >> A[i].m >> A[i].s >> ws;
        for(int j=0; j<n; j++)
        {
            if(A[i].vardas == vardas[j])
            {
                A[i].laikas = (A[i].h*3600+A[i].m*60+A[i].s)-(H[j]*3600+M[j]*60+S[j]);
            }
        }
    }
} // Rikiavimo funkcija
void rikiavimas(dalyviai A[], int m)
{
    for(int i=0; i<m; i++)
    {
        for(int j=i+1; j<m; j++)
        {
            if(A[i].laikas>A[j].laikas)
            {
                swap(A[i],A[j]);
            }
            else if(A[i].laikas==A[j].laikas && A[i].vardas>A[j].vardas)
            {
                swap(A[i],A[j]);
            }
        }
    }
} // Rezultatu spausdinimo funkcija
void rezultatai(int m, dalyviai A[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<m; i++)
    {
        cout << A[i].vardas << " "<< A[i].laikas/60 << " "<< A[i].laikas-A[i].laikas/60*60<<endl;
    }
}
