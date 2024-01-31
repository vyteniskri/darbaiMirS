#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[], int B[]);
void skaiciavimas(int n, int A[], int B[], int &V, int &v);

int main()
{
    int n, A[100], B[100], V=0, v=0;
    duomenys(n, A, B);
    skaiciavimas(n, A, B, V, v);
    ofstream fr("rez2.txt");

    fr << "Is viso uz pirkinius sumokesite "<< V << " Eur "<< v<< " euro ct";
    fr.close();
}
void duomenys(int &n, int A[], int B[])
{
    ifstream fd("duom2.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i] >> B[i];
    }
    fd.close();
}
void skaiciavimas(int n, int A[], int B[], int &V, int &v)
{
    int eur=0, cnt=0;
    for(int i=0; i<n; i++)
    {
        eur = eur + A[i];
        cnt = cnt + B[i];

    }
    V= eur + (cnt/100);
    v= cnt%100;
}
