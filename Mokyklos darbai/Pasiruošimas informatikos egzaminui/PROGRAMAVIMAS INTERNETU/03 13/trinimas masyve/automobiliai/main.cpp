#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, string A[]);
void rikiavimas(int &n, string A[]);

int main()
{
   int n;
   string A[100];
    duomenys(n, A);
    rikiavimas(n, A);
    for(int i=0; i<n; i++)
    {
        cout << A[i]<<endl;
    }
}
void duomenys(int &n, string A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];

    }


}
void rikiavimas(int &n, string A[])
{
    for(int i=0; i<n; i++)
    {
        if(i==n/2)
        {
            for(int j=i; j<n;j++)
            {
                A[j]=A[j+1];
            }
            n--;


        }

    }
}
