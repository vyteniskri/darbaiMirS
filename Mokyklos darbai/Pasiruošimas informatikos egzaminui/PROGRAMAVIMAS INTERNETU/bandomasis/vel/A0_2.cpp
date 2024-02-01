#include <iostream>
#include <fstream>
using namespace std;
struct mokinys
{
    string vardas;
    int valanda[100], minute[100];
    int kontrol=0;
};
void duomenys(int &n, int &mv, int &v, int &m, int mk[], int k[], mokinys A[], int &vel);
int velavo(int mk);
void kiek(int n, mokinys A[], int mv, int mk[], int k[], int v, int m);
void rezultatai(int n, mokinys A[], int vel);

int main()
{
    int n, mv, mk[100], k[100], vel=0;
    int v, m;
    mokinys A[100];
    duomenys(n, mv, v, m, mk, k, A, vel);
    kiek(n, A, mv, mk, k, v, m);
    rezultatai(n, A, vel);
}//Duomenu skaitymo funkcija
void duomenys(int &n, int &mv, int &v, int &m, int mk[], int k[], mokinys A[], int &vel)
{
    ifstream fd("U2.txt");
    fd >> n >> mv;
    fd >> v >> m >> ws;
    char eil[16];
    for(int i=0; i<n; i++)
    {
        fd.get(eil,16);
        A[i].vardas=eil;

        fd >> mk[i] >> k[i];
        vel=vel+velavo(mk[i]);
        for(int j=0; j<k[i]; j++)
        {
            fd >> A[i].valanda[j] >> A[i].minute[j];

        }
        fd >> ws;

    }
    fd.close();
}
int velavo(int mk)
{
    if(mk==0)
    {
        return 0;
    }
    else return 1;

}
void kiek(int n, mokinys A[], int mv, int mk[], int k[], int v, int m)
{
    for(int i=0; i<n; i++)
    {
        if(mk[i]!=0)
        {
            A[i].kontrol=A[i].kontrol-mk[i];

        }

        for(int j=0; j<k[i]; j++)
        {
            if(((A[i].valanda[j]*60+A[i].minute[j])-(v*60+m))>mv)
            {

                A[i].kontrol=A[i].kontrol-1;

            }

        }

        if(A[i].kontrol==0)
        {
            A[i].kontrol=A[i].kontrol+2;
        }
    }
}//Duomenu spausdinimo funkcija
void rezultatai(int n, mokinys A[], int vel)
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<n; i++)
    {
        cout << A[i].vardas<< " "<< A[i].kontrol<<endl;
    }
    cout << vel << " "<< n-vel<<endl;
    fr.close();
}
