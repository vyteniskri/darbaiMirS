#include <iostream>
#include <fstream>
using namespace std;
struct pirstines
{
    int lytis;
    int ranka;
    int dydis;
};
void duomenys(int &n, pirstines A[]);
void moteriskos(int n, pirstines A[], int &m, int &m1);
void vyriskos(int n, pirstines A[], int &v, int &v1);

int main()
{
   int n;
   int m=0, m1=0, v=0, v1=0;
   pirstines A[100];
   duomenys(n, A);
   moteriskos(n, A, m, m1);
   vyriskos(n, A, v, v1);
   ofstream fr("U1rez.txt");
   cout << m << endl;
   cout << v << endl;
   cout << m1 << endl;
   cout << v1 << endl;
}
void duomenys(int &n, pirstines A[])
{
    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].lytis >> A[i].ranka >> A[i].dydis;
    }
}
void moteriskos(int n, pirstines A[], int &m, int &m1)
{
    int M=0;
    for(int i=0; i<n; i++)
    {
        if(A[i].lytis==4)
        {
            for(int j=i+1; j<n; j++)
            {
                if(A[i].ranka!=A[j].ranka && A[i].dydis==A[j].dydis && A[j].lytis==4)
                {
                    m++;

                    for(int z=j; z<n; z++)
                    {
                        A[z]=A[z+1];

                    }
                    n--;
                    j--;
                    for(int z=i; z<n; z++)
                    {
                        A[z]=A[z+1];

                    }
                    n--;
                    i--;
                }


            }
            M++;
        }

    }
 m1=M-m;
}
void vyriskos(int n, pirstines A[], int &v, int &v1)
{
    int V=0;
    for(int i=0; i<n; i++)
    {
        if(A[i].lytis==3)
        {
            for(int j=i+1; j<n; j++)
            {
                if(A[i].ranka!=A[j].ranka && A[i].dydis==A[j].dydis && A[j].lytis == A[i].lytis)
                {
                    v++;

                    for(int z=j; z<n; z++)
                    {
                        A[z]=A[z+1];
                    }
                    n--;
                    j--;
                    for(int z=i; z<n; z++)
                    {
                        A[z]=A[z+1];
                    }
                    n--;
                    i--;
                }

            }
            V++;
        }

    }
    v1=V-v;
}

