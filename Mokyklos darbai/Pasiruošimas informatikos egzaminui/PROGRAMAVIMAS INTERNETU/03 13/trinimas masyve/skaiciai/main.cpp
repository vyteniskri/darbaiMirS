#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[]);
void maz (int n, int A[], int &m);
void trinimas(int &n, int A[], int m);

int main()
{
   int n, m=99;
   int A[100];
    duomenys(n, A);
    maz(n, A, m);
    trinimas(n, A, m);
    for(int i=0; i<n; i++)
    {
        cout << A[i]<< " ";
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

void maz (int n, int A[], int &m)
{

    for(int i=0; i<n; i++)
    {
        if(A[i]<m)
        {
            m=A[i];
        }

    }



}
void trinimas(int &n, int A[], int m)
{
    for(int i=0; i<n; i++)
    {
        if(A[i]==m)
        {

            for(int j=i; j<n; j++)
            {
                A[j]=A[j+1];
            }
            i--;
            n--;
        }

    }
}
