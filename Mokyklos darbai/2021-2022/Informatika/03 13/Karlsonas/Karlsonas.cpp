#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int A[], int &n, int &m);
int skaiciavimas(int n, int m, int A[]);

int main()
{
    int n, m, A[100];
    duomenys(A, n, m);

    cout << skaiciavimas(n, m, A)<<endl;

}
void duomenys(int A[], int &n, int &m)
{
    ifstream fd("Duomenys.txt");
    cin >> n >> m;
    for(int i=0; i<m; i++)
    {
        cin >> A[i];
        if(A[i]==1)
        {
            A[i]=2;
        }
        else if(A[i]==2)
        {
            A[i]=5;
        }
        else A[i]=3;
    }
}
int skaiciavimas(int n, int m, int A[])
{
    int sk=n;
    for(int i=0; i<m; i++)
    {
       sk=sk-A[i];
       if(sk<=0)
       {
           sk=0;
       }
    }
    return sk;
}
