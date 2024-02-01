#include <iostream>
#include <fstream>
using namespace std;
struct balai
{
    string sokejai;
    int taskai, suma;
};
void duomenys(int &n, int &k, balai A[]);
int sum(int k, balai A[]);
void rikiavimas(int n, balai A[]);

int main()
{
    ofstream fr("U2rez.txt");
    int n, k;
    balai A[100];
    duomenys (n, k, A);
    rikiavimas (n, A);
    for(int i=0; i<n; i++)
    {
        fr << A[i].sokejai << " "<< A[i].suma<<endl;
    }

}///Duomenu spausdinimo funkcija
void duomenys(int &n, int &k, balai A[])
{
    int d=0, m=100, suma1, suma2;
    ifstream fd("U2.txt");
    fd >> n >> k >> ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].sokejai=eil;
        for(int j=0; j<k; j++)
        {
            fd >> A[j].taskai;
            if(A[j].taskai>d)
            {
                d=A[j].taskai;
            }
            if(A[j].taskai<m)
            {
                m=A[j].taskai;
            }
        }
         suma1= sum(k, A)-d-m;
        d=0;
        m=100;
        for(int j=0; j<k; j++)
        {
            fd >> A[j].taskai;
            if(A[j].taskai>d)
            {
                d=A[j].taskai;
            }
            if(A[j].taskai<m)
            {
                m=A[j].taskai;
            }
        }

        fd >> ws;
       suma2= sum(k, A)-d-m;
       A[i].suma=suma1+suma2;
       d=0;
       m=100;
    }
} ///Poros balu skaiciavimo funkcija
int sum(int k, balai A[])
{
    int s=0;
    for(int i=0; i<k; i++)
    {
        s=s+A[i].taskai;
    }
    return s;
}///Rikiavimo funkcija
void rikiavimas(int n, balai A[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].suma<A[j].suma)
            {
                swap(A[i], A[j]);
            }
        }
    }
}
