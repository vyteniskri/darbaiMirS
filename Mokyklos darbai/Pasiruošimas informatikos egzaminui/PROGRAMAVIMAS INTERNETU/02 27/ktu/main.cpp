#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    int nr;
    int laikas;
};
void duomenys(prad A[], prad V[], prad M[], int &v, int &mm);
void keitimas(prad A[], prad V[], prad M[], int v, int mm);
void rezultatai(prad V[], prad M[], int v, int mm);

int main()
{
    int v=0, mm=0;
    prad A[30], V[30], M[30];
    duomenys(A, V, M, v, mm);
    keitimas(A, V, M, v, mm);
    rezultatai(V, M, v, mm);

}
void duomenys(prad A[], prad V[], prad M[], int &v, int &mm)
{
    int n, m, nr, h, mi, s, b1, b2, b3, b4;
    ifstream fd("U2.txt");
    fd >> n >> ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].vardas = eil;
        fd >> A[i].nr >> h >> mi >> s >> ws;
        A[i].laikas = h*3600+mi*60+s;

    }
    fd >> m;
    for(int i=0; i<m; i++)
    {
        fd >> nr;

        if(nr<200)
        {

            fd >> h >> mi >> s >> b1 >> b2;
            M[i].laikas = (h*3600)+(mi*60)+s+(5-b1)+(5-b2);
            mm++;

        }
        else if(nr>200)
        {


            fd >> h >> mi >> s >> b1 >> b2 >> b3 >> b4;
            V[i].laikas = h*3600+mi*60+s+(5-b1)+(5-b2)+(5-b3)+(5-b4);

            v++;

        }

    }
}
void keitimas(prad A[], prad V[], prad M[], int v, int mm)
{
    for(int i=0; i<v; i++)
    {
        for(int j=i; j<v; j++)
        {
            if(V[i].laikas <V[j].laikas)
                swap(V[i].laikas, V[j].laikas);

        }
    }
    for(int i=0; i<mm; i++)
    {
        for(int j=i; j<mm; j++)
        {
            if(M[i].laikas <M[j].laikas)
                swap(M[i].laikas, M[j].laikas);

        }
    }
}
void rezultatai(prad V[], prad M[], int v, int mm)
{
    ofstream fr("U2rez.txt");
    cout << "---------------------"<<endl;
    cout << "Merginos"<<endl;
    for(int i=0; i<mm; i++)
    {
        cout << M[i].laikas/3600 << " " << M[i].laikas/60 << " "<< M[i].laikas - M[i].laikas/60*60<<endl;
    }
    cout << "Vaikinai"<< endl;
    for(int i=0; i<v; i++)
    {
        cout << V[i].laikas/3600 << " " << V[i].laikas/60 << " "<<V[i].laikas - V[i].laikas/60*60<<endl;
    }

}
