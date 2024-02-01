#include <iostream>
#include <fstream>
using namespace std;
struct ideja //vienos idejos struktura
{
    string pavadinimas[100];
    int balsai[100];
};
struct visi
{
    string vardas;
    int balsas;
    string grupes;
};
void duomenys(int &n, int k[], ideja A[], string grupe[], visi B[], int &l, visi C[]);
int didziausias(int l, visi B[]);
void rezultatai(int n, int l, int D[], visi C[]);
int main()
{
   int n, k[20], l=0, D[100];
   string grupe[20];
   ideja A[100];
   visi B[100], C[100];
   duomenys(n, k, A, grupe, B, l, C);

    for(int i=0; i<3; i++) // ciklas, kuris 3 kartus kreipiasi i dizdiausios reiksmes paieskos funkcija
    {
            D[i]=didziausias(l, B);
            for(int j=0; j<l;j++)
            {
                if(D[i]==B[j].balsas)
                {
                    for(int z=j; z<l; z++)
                    {
                        B[z]=B[z+1];
                    }
                    j--;
                    n--;
                }
            }

    }
rezultatai(n, l, D, C);

} //Duomenu skaitymo funkcija
void duomenys(int &n, int k[], ideja A[], string grupe[], visi B[], int &l, visi C[])
{
    ifstream fd("ideja_data.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> grupe[i] >> k[i];
        for(int j=0; j<k[i]; j++)
        {
            fd >> A[i].pavadinimas[j] >> A[i].balsai[j];
            B[l].vardas = A[i].pavadinimas[j];
             B[l].balsas = A[i].balsai[j];
             B[l].grupes= grupe[i];
             C[l].vardas = A[i].pavadinimas[j];
             C[l].balsas = A[i].balsai[j];
             C[l].grupes= grupe[i];
             l++;
        }


    }
} // Didziausios reiksmes paieskos funkcija
int didziausias(int l, visi B[])
{
    int m=0;
    for(int i=0; i<l; i++)
    {
        if(B[i].balsas>m)
        {
            m=B[i].balsas;
        }
    }
    return m;
}
void rezultatai(int n, int l, int D[], visi C[])
{
    ofstream fr("ideja_res.txt");
    for(int i=0; i<3; i++)
    {
        for(int j=0; j<l; j++)
        {
            if(C[j].balsas==D[i])
            {
                fr << C[j].grupes << " "<< C[j].vardas << " "<< C[j].balsas<<endl;
            }

        }

    }
}

