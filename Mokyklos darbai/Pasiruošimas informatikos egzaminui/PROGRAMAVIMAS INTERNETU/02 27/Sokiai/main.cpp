#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[20];
    int art[10];
    int tech[10];
    int suma=0;
};
void duomenys(int &n, int &m, prad A[]);
void skaiciavimas(int n, int m, prad A[]);
int taskai(int tech[], int m);
void rezultatai(int n, prad A[]);
void rikiavimas(int n, prad A[]);
int main()
{
    int n, m;
    prad A[100];
    duomenys(n, m, A);
    skaiciavimas(n, m, A);
    rikiavimas(n, A);
    rezultatai(n, A);


}
void duomenys(int &n, int &m, prad A[])
{
    ifstream fd("U2.txt");
    fd >> n >> m >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 20);

        for(int j=0; j<m; j++)
        {
            fd >> A[i].art[j];
        }
        for(int j=0; j<m; j++)
        {
            fd >> A[i].tech[j];
        }
        fd >> ws;
    }
}
void skaiciavimas(int n, int m, prad A[])
{
    for(int i=0; i<n ;i++)
    {
        A[i].suma = A[i].suma + taskai(A[i].art, m);
        A[i].suma = A[i].suma + taskai(A[i].tech, m);
    }
}
int taskai(int tech[], int m)
{
    int sum=0, maz=10, did=0;
    for(int i=0; i<m; i++)
    {
        sum = sum + tech[i];
        if(maz>tech[i])
        {
            maz =tech[i];
        }
        if(did<tech[i])
        {
            did = tech[i];
        }

    }
    sum =  sum - maz - did;
    return sum;
}
void rikiavimas(int n, prad A[])
{
    for(int i=0; i<n ;i++)
    {
        for(int j=i; j<n; j++)
        {
            if(A[i].suma<A[j].suma)
            {
                swap(A[i], A[j]);
            }
        }
    }
}
void rezultatai(int n, prad A[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<n; i++)
    {
        cout << A[i]. vardas << " "<< A[i].suma <<endl;
    }
}
