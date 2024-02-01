#include <iostream>
#include <fstream>
using namespace std;
struct zuvys
{
    int visotaskai=0, mase[30];
    string vardas, pavadinimas[30];
};
void duomenys(int &n, int &k, zuvys A[], zuvys B[]);
void keitimas(int y, zuvys H[]);
void rezultatai(zuvys A[], zuvys B[], int n, int k);
int main()
{
    int n, k;
    zuvys A[30], B[30];
    duomenys(n, k, A, B);
    keitimas(n, A);
    keitimas(k, B);
    rezultatai(A, B, n, k);

}
void duomenys(int &n, int &k, zuvys A[], zuvys B[])
{
    ifstream fd("Duomenys.txt");
    int sk[30], taskai;
    fd >> n >>ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].vardas=eil;
        fd >> sk[i] >> ws;

        for(int j=0; j<sk[i]; j++)
        {
            fd.get(eil, 21);
            A[i].pavadinimas[j]=eil;


            fd >> A[i].mase[j] >>ws;

            if(A[i].mase[j]>=200)
            {
                A[i].visotaskai=A[i].visotaskai+30;
            }
            else A[i].visotaskai=A[i].visotaskai+10;


        }
        fd >> ws;
    }
    fd >> k >>ws;
    for(int i=0; i<k; i++)
    {
        fd.get(eil, 21);
        B[i].vardas=eil;

        fd >> taskai;

        fd >>ws;
        for(int j=0; j<n; j++)
        {
            for(int z=0; z<sk[j];z++)
            {
                if(A[j].pavadinimas[z]==B[i].vardas)
                {
                    A[j].visotaskai=A[j].visotaskai+taskai;
                B[i].visotaskai=B[i].visotaskai+ A[j].mase[z];
                }
            }
        }


    }
    fd.close();

}
void keitimas(int y, zuvys H[])
{
    for(int i=0; i<y; i++)
    {
        for(int j=i+1; j<y;j++)
        {
            if(H[i].visotaskai<H[j].visotaskai || H[i].visotaskai==H[j].visotaskai && H[i].vardas < H[j].vardas)
            {
                swap(H[i], H[j]);
            }

        }
    }
}
void rezultatai(zuvys A[], zuvys B[], int n, int k)
{
    cout << "Dalyviai"<<endl;
    for(int i=0; i<n; i++)
    {
        cout << A[i].vardas <<" "<< A[i].visotaskai<<endl;
    }
    cout << "Laimikis"<<endl;
    for(int i=0; i<k; i++)
    {
        cout << B[i].vardas << " "<< B[i].visotaskai<<endl;
    }
}
