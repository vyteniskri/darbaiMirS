#include <iostream>
#include <fstream>
using namespace std;
struct miestas
{
    string miesto, apskrities;
    int n;
};
struct galinis
{
    int maz=600001, viso=0;
    string pavadinimas;
};
void rikiavimas(galinis B[], int k);
int main()
{
    ifstream fd("U2.txt");
    ofstream fr("U2rez.txt");
    int k, Sk;
    miestas A[103];
    galinis B[103];
    fd >> k >> ws;
    char eil[21];
    for(int i=0; i<k; i++)
    {
        fd.get(eil, 21);
        A[i].miesto=eil;
        fd.get(eil, 14);
        A[i].apskrities=eil;
        fd >> A[i].n >> ws;

    }
    for(int i=0; i<k; i++)
    {
        B[i].pavadinimas=A[i].apskrities;
        B[i].viso=B[i].viso + A[i].n;
        for(int j=i+1; j<k; j++)
        {
            if(A[i].apskrities==A[j].apskrities)
            {
                B[i].viso=B[i].viso+A[j].n;
                if(A[j].n<B[i].maz)
                {
                    B[i].maz=A[j].n;
                }
                for(int z=j; z<k; z++)
                {
                    A[z]=A[z+1];
                }
                j--;
                k--;


            }
        }
    }
    rikiavimas(B, k);
    fr << k<<endl;///Spausdinu rezultatus i U2rez.txt faila
    for(int i=0; i<k; i++)
    {
        fr << B[i].pavadinimas << " "<< B[i].maz << " "<< B[i].viso<<endl;
    }

}///Rikiavimo funkcija
void rikiavimas(galinis B[], int k)
{
    for(int i=0; i<k; i++)
    {
        for(int j=i+1; j<k; j++)
        {
            if(B[i].maz>B[j].maz || B[i].maz==B[j].maz && B[i].pavadinimas>B[j].pavadinimas)
            {
                swap(B[i], B[j]);
            }
        }
    }
}
