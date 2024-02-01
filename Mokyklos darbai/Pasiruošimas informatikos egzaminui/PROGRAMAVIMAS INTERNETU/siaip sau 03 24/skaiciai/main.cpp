#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[]);
void rikiavimas(int &n, int A[]);

int main()
{
    int n, A[100];
    duomenys(n, A);
    rikiavimas(n, A);
    for(int i=0; i<n; i++)
    {
        cout << A[i];
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
void rikiavimas(int &n, int A[])
{
    int m=99;
    for(int i=0; i<n; i++)
    {
        if(A[i]<m)
        {
            m=A[i];
        }


    }
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
