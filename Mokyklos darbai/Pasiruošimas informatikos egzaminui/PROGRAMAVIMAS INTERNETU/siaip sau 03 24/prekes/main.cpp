#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, string A[]);
void salinimas(int &n, string A[]);

int main()
{
  int n;
  string A[100];
    duomenys(n, A);
    salinimas(n, A);
    for(int i=1;i<=n; i++)
    {
        cout << A[i]<<endl;
    }
}
void duomenys(int &n, string A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=1; i<=n; i++)
    {
        fd >> A[i];

    }
}
void salinimas(int &n, string A[])
{
    for(int i=1; i<=n; i++)
    {

            if(n/2==n-i)
            {

                for(int j=i; j<n; j++)
                {
                    A[j]=A[j+1];

                }
                n--;
                break;
            }

    }

}
