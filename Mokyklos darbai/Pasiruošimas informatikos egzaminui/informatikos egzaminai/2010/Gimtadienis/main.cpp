#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string pavadinimas;
    int kiekis, kaina;
    int suma;
};
int KAINA(prad A[], int N);
int viso(prad A[], int P);
int main()
{
    ifstream fd("U2.txt");
    ofstream fr("U2rez.txt");
    int N, P;
    prad A[12];
    char eil[16];
    fd >> N >> P;
    for(int i=0; i<N; i++)
    {
        fd >> A[i].kaina;
    }
    fd >> ws;
    for(int i=0; i<P; i++)
    {
        fd.get(eil, 16);
        A[i].pavadinimas=eil;
        for(int j=0; j<N; j++)
        {
            fd >> A[j].kiekis;
        }
        fd >> ws;
        A[i].suma= KAINA(A, N);

    }///Spausdinu atsakymus i U2rez.txt
    for(int i=0; i<P; i++)
    {
        fr << A[i].pavadinimas << " "<< A[i].suma<<endl;
    }
    fr << viso(A, P)/100 << " "<< viso(A, P)%100;

}///vieno patiekalo kainą centais
int KAINA(prad A[], int N)
{
    int s=0;
    for(int i=0; i<N; i++)
    {
        s=s+A[i].kiekis*A[i].kaina;
    }
    return s;
}///vieno svečio pietų kainą centais
int viso(prad A[], int P)
{
    int sum=0;
    for(int i=0; i<P; i++)
    {
        sum=sum + A[i].suma;
    }
    return sum;
}
