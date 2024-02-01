#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[]);
void did (int n, int A[], int &d);
void rikiavimas(int &n, int A[], int d);

int main()
{
   int n, d=0;
   int A[100];
    duomenys(n, A);
    did(n, A, d);
    rikiavimas(n, A, d);
    for(int i=0; i<n; i++)
    {
        cout << A[i]<<" ";
    }

}
void duomenys(int &n, int A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];


    }
}
void did (int n, int A[], int &d)
{
    for(int i=0; i<n; i++)
    {
        if(A[i]>d)
        {
            d=A[i];
        }
    }
}
void rikiavimas(int &n, int A[], int d)
{
    for(int i=0; i<n; i++)
    {
        if(A[i]==d)
        {
            for(int j=n; i<j; j--)
            {
                A[j]=A[j-1];
            }
            n++;
            i++;
            A[i]=0;
        }
    }
}
