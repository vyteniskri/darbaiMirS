#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, string A[], string &pav);
void rikiavimas(int &n, string A[], string pav);

int main()
{
    int n;
    string pav, A[100];
    duomenys(n, A, pav);
    rikiavimas(n, A, pav);

    for(int i=0; i<n; i++)
    {
        cout << A[i]<<endl;
    }

}
void duomenys(int &n, string A[], string &pav)
{
    ifstream fd("Duomenys.txt");
    fd >> n >> pav;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];
    }
}
void rikiavimas(int &n, string A[], string pav)
{
    int k=n;
    for(int i=0; i<n; i++)
    {
        if(i==k/2)
        {

            for(int j=n; i<j; j--)
            {

                A[j]=A[j-1];
            }
            n++;
            A[i]=pav;

        }

    }
}
