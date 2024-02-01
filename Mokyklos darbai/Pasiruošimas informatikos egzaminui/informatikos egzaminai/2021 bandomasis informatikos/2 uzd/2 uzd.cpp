#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    string vienetai;
    int verte, did=0;
    string reiksmes[100];
};
void duomenys(int &n, int &m, prad A[], int b[]);
int vertes(prad A);
int didziausias(prad A[], int m, prad B);
int main()
{
    ofstream fr("U2rez.txt");
    int n, m, b[100]={0};
    int D=0;
    prad A[100];
    duomenys(n, m, A, b);
    for(int i=0; i<m; i++)
    {
        for(int j=0; j<b[i]; j++)
        {

            cout << A[i].reiksmes[j] << " ";

        }
            cout << A[i].did<<endl;
            if(A[i].did>D)
            {
                D=A[i].did;
            }
    }

    for(int i=0; i<m; i++)
    {
        if(A[i].did == D)
        {
            cout << i+1<<endl;
        }
    }

     fr.close();

} // Duomenis spausdinanti funkcija
void duomenys(int &n, int &m, prad A[], int b[])
{
    int a, p=0;
    ifstream fd("U2.txt");
    fd >> n >> m;
    for(int i=0; i<n/m; i++)
    {
        for(int j=0; j<m; j++)
        {
            fd >> A[j].vienetai;

             A[j].verte = vertes(A[j]);
             a= didziausias(A, m, A[j]);
        }

       for(int z=0; z<m; z++)
       {
            if(A[z].verte==a)
            {
                for(int t=0; t<m; t++)
                {
                    if(A[z].verte==A[t].verte)
                    {
                        p++;

                    }
                }
                if(p==1)
                {
                    for(int l=0; l<m; l++)
                    {

                        A[z].reiksmes[b[z]] = A[l].vienetai;
                        A[z].did = A[z].did + A[l].verte;
                        b[z]++;

                    }
                }
                else if(p>1)
                {
                    A[z].reiksmes[b[z]] = A[z].vienetai;
                    A[z].did = A[z].did + A[z].verte;

                    b[z]++;
                }
                p=0;

            }
       }



    }
    fd.close();
} // Funkcija, susiejanti informacijos matavimo vienetų simbolius su jų verte taškais.
int vertes(prad A)
{
    int k;
    if(A.vienetai=="b")
    {
        k=1;
    }
    if(A.vienetai=="B")
    {
        k=2;
    }
    if(A.vienetai=="kB")
    {
        k=3;
    }
    if(A.vienetai=="MB")
    {
        k=4;
    }
    if(A.vienetai=="GB")
    {
        k=5;
    }
    if(A.vienetai=="TB")
    {
        k=6;
    }
    if(A.vienetai=="PB")
    {
        k=7;
    }
    if(A.vienetai=="EB")
    {
        k=8;
    }
    if(A.vienetai=="ZB")
    {
        k=9;
    }
    if(A.vienetai=="YB")
    {
        k=10;
    }
    return k;
}
int didziausias(prad A[], int m, prad B)
{
    int d;
    for(int i=0; i<m; i++)
    {

        if(A[i].verte>B.verte)
        {
            B.verte=A[i].verte;
        }
    }
    return B.verte;

}
