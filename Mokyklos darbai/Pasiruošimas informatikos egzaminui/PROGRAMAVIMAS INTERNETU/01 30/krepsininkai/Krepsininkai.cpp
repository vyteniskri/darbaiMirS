#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[16];
    int taskai;
    double ugis;
};
void duomenys(int &n, prad D[], int &p, int &k);
void gali(int n, prad D[], int p, int k, int &an, prad T[], double u, int t);
void aukstirtaikl(int n, prad D[], double &u, int &t);
void rezultatai(prad T[], int an);
int main()
{
    int n, p, k, an=0, t=0;
    double u=0;
    prad D[100], T[100];
    duomenys (n, D, p, k);
    aukstirtaikl (n, D, u, t);

    gali (n, D, p, k, an, T, u, t);
    rezultatai(T, an);

}
void duomenys(int &n, prad D[], int &p, int &k)
{
    ifstream fd ("Duomenys.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(D[i].vardas, 16);
        fd  >> D[i].ugis >> D[i].taskai >> ws;
    }
    fd >> p >> k;
}
void aukstirtaikl(int n, prad D[], double &u, int &t)
{
    for(int i=0; i<n;i++)
    {
        if(D[i].ugis>u)
        {
            u=D[i].ugis;
        }
        if(D[i].taskai>t)
        {
            t=D[i].taskai;
        }
    }
}
void gali(int n, prad D[], int p, int k, int &an, prad T[], double u, int t)
{
    for(int i=0; i<n;i++)
    {
        if(D[i].ugis >= ((100.0-p)/100.0)*u || D[i].taskai >= ((100.0-k)/100.0)*t)
        {
             T[an] = D[i];
            an++;
        }
    }

}
void rezultatai(prad T[], int an)
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<an;i++)
    {
        fr << T[i].vardas << " "<< T[i]. ugis << " " << T[i].taskai<<endl;
    }
}
