#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[16];
    int litai;
    int centai;
};
void duomenys(int &n, int &p, int &k, prad A[]);
void surinko(int n, int &L, int &C, int &L1, int &C1, int &V, int &V1, int p, int k, prad A[]);
void gavo(int n, prad A[], prad B[], int p, int k);
void rezultatai(int n, int L, int C, int L1, int C1, prad A[], prad B[]);
int main()
{
    int n, p, k, L, C, L1, C1, V=0, V1=0;
    prad A[100], B[100];
    duomenys(n, p, k, A);
    surinko(n, L, C, L1, C1, V, V1, p, k, A);
    gavo(n, A, B, p, k);
    rezultatai(n, L, C, L1, C1, A, B);
}
void duomenys(int &n, int &p, int &k, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 16);
        fd >> A[i].litai >> A[i].centai >> ws;
    }
    fd >> p >> k;
}
void surinko(int n, int &L, int &C, int &L1, int &C1, int &V, int &V1, int p, int k, prad A[])
{
    for(int i=0; i<n; i++)
    {
        V=V+A[i].litai;
        V1=V1+A[i].centai;


    }
    L=V+V1/100;
    C=V1%100;
    L1=((p*100+k)*(V*100+V1))/10000;
    C1=((p*100+k)*(V*100+V1))%10000/100;

}
void gavo(int n, prad A[], prad B[], int p, int k)
{
    for(int i=0; i<n; i++)
    {
        B[i].litai=((p*100+k)*(A[i].litai*100+A[i].centai))/10000;
        B[i].centai=((p*100+k)*(A[i].litai*100+A[i].centai))%10000/100;;
    }
}
void rezultatai(int n, int L, int C, int L1, int C1, prad A[], prad B[])
{
    ofstream fr("Rezultatai.txt");
    fr << L << " "<< C<<endl;
    fr << L1 << " "<< C1 << endl;
    for(int i=0; i<n;i++)
    {
        fr << A[i].vardas << " "<< A[i].litai << " "<< A[i].centai << " "<< B[i].litai << " "<< B[i].centai<<endl;
    }
}
