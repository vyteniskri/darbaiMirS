#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[20];
    int nr;
    int H;
    int M;
    int S;
    int balai[100];
    int viso;
    int H1;
    int M1;
    int S1;
};
void duomenys(int &n, int &m, prad A[]);
int skaiciavimas1(int m, prad A[], int nr, int &viso1);
int skaiciavimas2(int m, prad A[], int nr);
int skaiciavimas3(int m, prad A[], int nr);

int main()
{
    int n, m, viso1;
    prad A[100];
    duomenys(n,m, A);

}
void duomenys(int &n, int &m, prad A[])
{
    int H, M, S, k, k1, viso1, nr;
    ifstream fd("U2.txt");
    fd >> n >> ws;
    for (int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 20);
        fd >> A[i].nr >> A[i].H >> A[i].M >> A[i].S >> ws;
        A[i].viso =A[i].H*3600+A[i].M*60+A[i].S;
    }
    fd >> m;
     for (int i=0; i<m; i++)
     {
         fd >> nr >> H >> M >> S;
         for(int j=0; j<4; j++)
         {
             fd >> A[i].balai[j];
             if(A[i].balai[j]<5)
             {
                 k=5-A[i].balai[j];
                 k1=k1+k;
             }
         }

        viso1 = H*3600+M*60+S+k1;
        A[i].H1= skaiciavimas1(m, A, nr, viso1);
        A[i].M1= skaiciavimas2(m, A, nr);
        A[i].S1= skaiciavimas3(m, A, nr);
        cout << nr << endl;
     }
}
int skaiciavimas1(int m, prad A[], int nr, int &viso1)
{
    for(int i=0; i<m;i++)
    {
        if(nr=A[i].nr)
        {

            A[i].H1=viso1-A[i].viso;
        }
    }
}
int skaiciavimas2(int m, prad A[], int nr)
{
    for(int i=0; i<m;i++)
    {
        if(nr=A[i].nr)
        {

            A[i].M1=A[i].H1/60;

        }
    }
}
int skaiciavimas3(int m, prad A[], int nr)
{
    for(int i=0; i<m;i++)
    {
        if(nr=A[i].nr)
        {

            A[i].S1=A[i].H1-A[i].M1*60;
        }
    }
}
