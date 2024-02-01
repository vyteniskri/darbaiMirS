#include <iostream>
#include <fstream>
using namespace std;
struct kupiura
{
    int verte, kiekis;
};
struct zaidejas
{
    string vardas;
    int pinigai;
};
struct prad
{
    int atidavimas[100];
    string netaip;
};
void duomenys(int &n, kupiura A[], zaidejas B[], prad C[]);
int skaiciavimas(zaidejas B, kupiura A);
string NE(int n, kupiura A[], zaidejas B);
void rezultatai(int n, prad C[], zaidejas B[], kupiura A[], int visokiekis, int visoverte);

int main()
{
   int n, visoverte=0, visokiekis=0;
   kupiura A[100];
   zaidejas B[100];
   prad C[100];
   duomenys(n, A, B, C);
   rezultatai (n, C, B, A, visokiekis, visoverte);
}
void duomenys(int &n, kupiura A[], zaidejas B[], prad C[])
{
    ifstream fd("Duomenys.txt");
    for(int i=0; i<7; i++)
    {
        fd >> A[i].verte;
    }
    for(int i=0; i<7; i++)
    {
        fd >> A[i].kiekis;
    }
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> B[i].vardas >> B[i].pinigai;
            C[i].netaip = NE(n, A, B[i]);
        if(C[i].netaip=="GALIMA")
        {
            for(int j=0; j<7; j++)
            {


                C[i].atidavimas[j]= skaiciavimas(B[i], A[j]);
                A[j].kiekis=A[j].kiekis - C[i].atidavimas[j];
                B[i].pinigai=B[i].pinigai-(C[i].atidavimas[j] * A[j].verte);

            }
        }


    }

}
int skaiciavimas(zaidejas B, kupiura A)
{
    int S;
    S= B.pinigai/A.verte;
     if(S>A.kiekis)
     {
         return A.kiekis;
     }
     else return S;

}
string NE(int n, kupiura A[], zaidejas B)
{
    int suma=0;
    for(int i=0; i<7; i++)
    {
        suma= suma + (A[i].kiekis*A[i].verte);
    }
    if(suma<B.pinigai)
    {
        return "NEGALIMA";
    }
    else return "GALIMA";
}
void rezultatai(int n, prad C[], zaidejas B[], kupiura A[], int visokiekis, int visoverte)
{
    for(int i=0; i<n; i++)
    {
        cout << B[i].vardas<< " ";
        if(C[i].netaip=="GALIMA")
        {
            for(int j=0; j<7; j++)
            {

                cout << C[i].atidavimas[j]<< " ";

            }
        }
        else cout << C[i].netaip;
        cout << endl;
    }
    for(int i=0; i<7; i++)
    {

        visokiekis = visokiekis + A[i].kiekis;
        visoverte = visoverte + (A[i].verte* A[i].kiekis);
    }
    cout << visokiekis << " "<< visoverte;

}
