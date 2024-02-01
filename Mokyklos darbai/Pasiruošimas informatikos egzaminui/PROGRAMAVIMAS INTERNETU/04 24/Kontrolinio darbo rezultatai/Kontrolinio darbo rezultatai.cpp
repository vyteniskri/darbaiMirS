#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;
struct prad
{
    string vardas;
    double rezultatas;

};
void duomenys(int &n, int &k, prad A[], double K[], prad V[]);
double vieno(int k, double K[], int Vieno[]);
int geriausi(int n, prad A[], prad S[]);
int blogiausi(int n, prad A[], prad s[]);
void Gsarasas(int n, prad A[], prad S[], int &Gg);
void Bsarasas(int n, prad A[], prad s[], int &Bb);
void rezultatai(int P, string zodis, prad H[], ofstream &fr);
int main()
{
  ofstream fr(" kontrolinis_res.txt");
    int n, k, Gg=0, Bb=0;
    double K[7];
    prad A[100], V[100], S[100], s[100];
    duomenys(n, k, A, K, V);
    geriausi(n, A, S);
    blogiausi(n, A, s);
    Gsarasas(n, A, S, Gg);
    Bsarasas(n, A, s, Bb);
    rezultatai(n, "VISI", V, fr);
    rezultatai(Gg, "GERIAUSI", S, fr);
    rezultatai(Bb, "BLOGIAUSI", s, fr);

}//Duomenų spausdinimo funkcija
void duomenys(int &n, int &k, prad A[], double K[], prad V[])
{
    int Vieno[7];
    ifstream fd("kontrolinis_data.txt");
    fd >> n >> k;
    for(int i=0; i<k; i++)
    {
        fd >> K[i];

    }
    char eil[20];
    fd >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 20);
        A[i].vardas=eil;
        for(int j=0; j<k; j++)
        {
            fd >> Vieno[j];

        }
        A[i].rezultatas = vieno(k, K, Vieno); // Kiekvieno mokinio galutis įvertinimas
        fd >> ws;
        V[i].vardas=A[i].vardas;
        V[i].rezultatas=A[i].rezultatas;

    }
}//Funkcija, skaičiuojanti galutinį įvertinimą
double vieno(int k, double K[], int Vieno[])
{
    double l=0;
    for(int i=0; i<k; i++)
    {
        l=l+(K[i]*Vieno[i]);
    }
    return round(l);
} //Geriausią įvertinimą skaičiuojanti funkcija
int geriausi(int n, prad A[], prad S[])
{
    int t=0;
    for(int i=0; i<n; i++)
    {
        if(A[i].rezultatas>t)
        {
            t=A[i].rezultatas;
        }


    }
    return t;
}
int blogiausi(int n, prad A[], prad s[])
{
    int t=99;
    for(int i=0; i<n; i++)
    {
        if(A[i].rezultatas<t)
        {
            t=A[i].rezultatas;
        }


    }
    return t;
}
void Gsarasas(int n, prad A[], prad S[], int &Gg)
{

    for(int i=0; i<n; i++)
    {

        if(geriausi(n, A, S)==A[i].rezultatas)
        {
            S[Gg].vardas=A[i].vardas;
            S[Gg].rezultatas=A[i].rezultatas;
            Gg++;


        }


    }
}
void Bsarasas(int n, prad A[], prad s[], int &Bb)
{

    for(int i=0; i<n; i++)
    {

        if (blogiausi(n, A, s)==A[i].rezultatas)
        {
            s[Bb].vardas=A[i].vardas;
            s[Bb].rezultatas=A[i].rezultatas;

            Bb++;


        }



    }
}
void rezultatai(int P, string zodis, prad H[], ofstream &fr)
{

    fr << zodis <<endl;
    for(int i=0; i<P; i++)
    {

        fr << H[i].vardas << " "<< H[i].rezultatas<<endl;


    }
}
