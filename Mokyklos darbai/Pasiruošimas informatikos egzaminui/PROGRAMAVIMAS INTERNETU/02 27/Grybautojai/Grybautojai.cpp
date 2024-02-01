#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char vardas[15];
    int b=0;
    int r=0;
    int l=0;
    int geriausias;
};
void duomenys(int &n, prad A[]);
void rezultatai(int n, prad A[]);
int ger(int n, prad A[]);
int main()
{
    int n;
    prad A[100];
    duomenys(n, A);
    rezultatai(n, A);


}
void duomenys(int &n, prad A[])
{
    int k;
    int b, r, l;
    ifstream fd("U2.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 15);
        fd >> k;
        for(int j=0; j<k; j++)
        {
            fd >>  b >> r >> l;
            A[i].b = A[i].b + b;
            A[i].r= A[i].r + r;
            A[i].l = A[i].l + l;
        }
        fd >> ws;


    }
}
int ger(int n, prad A[])
{
    int k=0;
    for(int i=0; i<n; i++)
    {
        if(A[k].b+A[k].r+A[k].l< A[i].b+A[i].r+A[i].l)
        {
            k=i;
        }
    }
    return k;
}
void rezultatai(int n, prad A[])
{
    ofstream fr("U2rez.txt");
    int ind = ger(n, A);
    for(int i=0; i<n; i++)
    {
        cout << A[i].vardas <<setw(5)<< A[i].b <<" "<< A[i].r <<" " << A[i].l <<endl;

    }
    cout << A[ind].vardas << " "<< A[ind].b + A[ind].r + A[ind].l;


}
