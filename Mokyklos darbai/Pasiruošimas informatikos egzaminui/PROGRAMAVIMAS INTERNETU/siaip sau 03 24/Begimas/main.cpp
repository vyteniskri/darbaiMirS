#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    int eile;
    double laikas;
};
void duomenys(int &n, prad A[]);
void rikiavimas(int n, prad A[]);
void rezultatai(int n, prad A[]);
int main()
{
   int n;
   prad A[50];
    duomenys(n, A);
    rikiavimas(n, A);
    rezultatai(n, A);
}
void duomenys(int &n, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd>> A[i].eile >> A[i].laikas;
    }
    fd.close();
}
void rikiavimas(int n, prad A[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i; j<n; j++)
        {
            if(A[i].laikas>A[j].laikas)
            {
                swap(A[i].laikas,A[j].laikas);
            }
            if(A[i].eile > A[j].eile)
            {
                swap(A[i].eile,A[j].eile);
            }
        }
    }
}
void rezultatai(int n, prad A[])
{
    for(int i=0; i<n; i++)
    {
        cout << A[i].eile << " "<< A[i].laikas<<endl;
    }
}
