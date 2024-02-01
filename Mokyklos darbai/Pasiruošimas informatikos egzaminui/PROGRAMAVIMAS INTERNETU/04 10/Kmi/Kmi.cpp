#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    double ugis, KMI;
    int svoris;
    int metai;
};
void duomenys(int &n, int &m1, int &m2, prad A[]);
double vieno(int n, int m1, int m2, prad A);
double vidurkis(int n, prad A[]);

int main()
{
    int n, m1, m2;
    prad A[100];
    duomenys(n, m1, m2, A);
    cout << fixed << setprecision(2) <<vidurkis(n, A);
}
void duomenys(int &n, int &m1, int &m2, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> m1 >> m2;
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].ugis >> A[i].svoris >> A[i].metai;
        A[i].KMI=vieno(n, m1, m2, A[i]);

    }
}
double vieno(int n, int m1, int m2, prad A)
{
    double v;

    if(A.metai>=m1 && A.metai<=m2)
    {
        v= A.svoris/(A.ugis*A.ugis);
    }

    return v;
}
double vidurkis(int n, prad A[])
{
    double vidur, suma=0;
    for(int i=0; i<n; i++)
    {
        suma= suma + A[i].KMI;

    }

    vidur=suma/n;
    return vidur;
}
