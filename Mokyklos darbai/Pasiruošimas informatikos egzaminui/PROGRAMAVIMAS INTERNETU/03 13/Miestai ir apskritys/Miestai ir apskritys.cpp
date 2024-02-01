#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string miestai;
    string apskritys;
    int gyventojai;
};
struct apskritys
{
    string apskritis;
    int maz;
    int viso;
};
void duomenys(int &n, prad A[]);
void skaiciavimas(int n, prad M[], int &k, apskritys A[]);
void rikiavimas(int k, apskritys A[]);
void rezultatai(int k, apskritys A[]);

int main()
{
    int n, k;
    prad M[103];
    apskritys A[10];
    duomenys(n, M);
    skaiciavimas(n, M, k, A);
    rikiavimas(k, A);
    rezultatai(k, A);

}
void duomenys(int &n, prad M[])
{
    ifstream fd("U2.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        char eil[21];
        fd.get(eil, 21);
        M[i].miestai = eil;

        fd.get(eil,14);
        M[i].apskritys = eil;

        fd >> M[i].gyventojai>>ws;
    }
}
void skaiciavimas(int n, prad M[], int &k, apskritys A[])
{
    for(int i=0; i<n; i++)
    {
        A[i].apskritis = M[i].apskritys;
        A[i].maz = M[i].gyventojai;
        A[i].viso = M[i].gyventojai;
        for(int j=i+1; j<n; j++)
        {
            if(M[i].apskritys == M[j].apskritys)
            {
                A[i].viso = A[i].viso + M[j].gyventojai;
                if(A[i].maz>M[j].gyventojai)
                {
                    A[i].maz=M[j].gyventojai;
                }
                for(int z=j; z<n; z++)
                {
                    M[z]=M[z+1];
                }
                n--;
                j--;
            }
        }
    }
    k=n;
}
void rikiavimas(int k, apskritys A[])
{
    for(int i=0; i<k; i++)
    {
        for(int j=i; j<k; j++)
        {
            if(A[i].viso>A[j].viso)
            {
                swap(A[i],A[j]);
            }
        }
    }
}
void rezultatai(int k, apskritys A[])
{
    ofstream fr("U2.rez");
    for(int i=0; i<k; i++)
    {
        cout << A[i].apskritis << " "<< A[i].maz << " "<< A[i].viso<<endl;
    }
}
