#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas, pavadinimas;
    int metai, taskai;
};
void duomenys(int &n, prad A[], prad B[]);
int jauniausi(int n, prad H[]);
int taikliausi(int n, prad H[]);
void komanda(int n, prad A[], prad B[], prad C[], int &l);
void rezultatai(int n, prad A[], prad B[], prad C[], int l);

int main()
{
    int n, l=0;
    prad A[100], B[100], C[100];
    duomenys(n, A, B);
    komanda(n, A, B, C, l);
    rezultatai(n, A, B, C, l);
}
void duomenys(int &n, prad A[], prad B[])
{
    ifstream fd("krepsinis_data.txt");
    fd >> A[0].pavadinimas;
    fd >> n;
    for(int i=1; i<=n; i++)
    {
        fd >> A[i].vardas >> A[i].metai >> A[i].taskai;

    }
    fd >> B[0].pavadinimas;
    fd >> n;
    for(int i=1; i<=n; i++)
    {
        fd >> B[i].vardas >> B[i].metai >> B[i].taskai;
    }
}
int jauniausi(int n, prad H[])
{
    int b=100;
    for(int i=1; i<=n; i++)
    {
        if(H[i].metai < b)
        {
            b=H[i].metai;
        }
    }
    return b;
}
int taikliausi(int n, prad H[])
{
    int a=0;
    for(int i=1; i<=n; i++)
    {
        if(H[i].taskai> a)
        {
            a=H[i].taskai;
        }
    }
    return a;
}
void komanda(int n, prad A[], prad B[], prad C[], int &l)
{

    for(int i=1; i<=n; i++)
    {
        if(jauniausi(n, A) == A[i].metai)
        {
            C[l].vardas = A[i].vardas;
            l++;
        }

    }
    for(int i=1; i<=n; i++)
    {
        if(taikliausi(n, B)==B[i].taskai)
        {
            C[l].vardas = B[i].vardas;
            l++;
        }
    }

}
void rezultatai(int n, prad A[], prad B[], prad C[], int l)
{

    ofstream fr("krepsinis_res.txt");
    cout << "JAUNIAUSI"<<endl;
    cout << A[0].pavadinimas<<endl;
    for(int i=1; i<=n; i++)
    {
        if(jauniausi(n, A) == A[i].metai)
        {

            cout << A[i].vardas<<endl;

        }
    }
    cout << B[0].pavadinimas<<endl;
    for(int i=1; i<=n; i++)
    {
        if(jauniausi(n, B) == B[i].metai)
        {

            cout << B[i].vardas<<endl;
        }
    }
    cout << "TAIKLIAUSI"<<endl;
    cout << A[0].pavadinimas<<endl;
    for(int i=n; i>=1; i--)
    {
        if(taikliausi(n, A)==A[i].taskai)
        {
            cout << A[i].vardas<<endl;
        }
    }
    cout << B[0].pavadinimas<<endl;
    for(int i=n; i>=1; i--)
    {
        if(taikliausi(n, B)==B[i].taskai)
        {

            cout << B[i].vardas<<endl;

        }
    }
    cout << "NAUJA KOMANDA"<<endl;
    for(int i=0; i<l; i++)
    {
        cout << C[i].vardas<<endl;
    }


}
