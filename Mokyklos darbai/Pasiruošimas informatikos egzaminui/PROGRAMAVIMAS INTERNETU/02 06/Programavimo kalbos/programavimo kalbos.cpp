#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char pavadinimas[16];
    double procentai;
};
void duomenys(int &n, prad A[], prad a[], prad b[]);
void pokytis(int n,  prad A[], prad a[], prad b[]);
void rezultatai(int n, prad A[]);
int main()
{
    int n;
    prad A[100], a[100], b[100];
    duomenys(n, A, a, b);
    pokytis(n, A, a, b);
    rezultatai(n, A);

}
void duomenys(int &n, prad A[], prad a[], prad b[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].pavadinimas, 16);
        fd >> a[i].procentai >> b[i].procentai >> ws;

    }
}
void pokytis(int n,  prad A[], prad a[], prad b[])
{
    for(int i=0;i<n;i++)
    {
        A[i].procentai= a[i].procentai - b[i].procentai;
    }
}
void rezultatai(int n, prad A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n;i++)
    {
        cout <<fixed << setprecision(2)<< A[i].pavadinimas << A[i].procentai<< endl;
    }
}
