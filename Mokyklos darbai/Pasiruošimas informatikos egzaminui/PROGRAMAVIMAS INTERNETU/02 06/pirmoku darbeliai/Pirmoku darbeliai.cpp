#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[15];
    int skaiciai, sk[100];
};
void duomenys(int &n, int &k, prad A[]);
void spausd(int n, int k, prad A[]);
int main()
{
    int n, k, l=0;
    prad A[100];
    duomenys(n, k , A);
    spausd(n, k, A);


}
void duomenys(int &n, int &k, prad A[])
{

    ifstream fd ("Duomenys.txt");
    fd >> n >> k >> ws;
    for(int i=0; i<n;i++)
    {
        fd.get(A[i].vardas, 15);

        for(int j=1; j<=k;j++)
            {
                fd >> A[j].skaiciai >> ws;
            }
        for(int j=1; j<=k; j++)
        {
            A[i].sk[j]=0;
           for(int z=1; z<=k;z++)
           {
               if(A[z].skaiciai==j)
               {
                   A[i].sk[j]++;
               }
           }
        }

    }

}
void spausd(int n, int k, prad A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n;i++)
    {
        fr << A[i].vardas << " ";
        for(int j=1;j<=k;j++)
        {
            fr << A[i].sk[j]<< " ";
        }
        fr << endl;

    }
}
