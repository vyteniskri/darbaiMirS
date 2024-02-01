#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string pavadinimas;
    int skaicius, numeriai[100]={0}, n[100];
};
void duomenys(int &n, prad A[]);
int numeris(int n, prad A[]);
void rezultatai(int n, prad A[]);

int main()
{
    int n;
    prad A[100];
    duomenys(n, A);
    rezultatai(n, A);

}///Duomenu spausdinimo funkcija
void duomenys(int &n, prad A[])
{
    ifstream fd("U2.txt");
    fd >> n >> ws;
    char eil[21];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].pavadinimas=eil;
        fd >> A[i].skaicius;

        for(int j=0; j<A[i].skaicius; j++)
        {
            fd >> A[i].n[j];
            A[i].numeriai[A[i].n[j]]++;


        }

        fd >> ws;
    }
    fd.close();
}
int numeris(int n, prad A[])
{
    int laik=0, kuris=0, nr=0;
    for(int i=0; i<100; i++)
    {

        laik=0;
        for(int j=0; j<n; j++)
        {
            if(A[j].numeriai[i]>0)
            {
                laik++;
            }
        }
        if(laik>kuris)
        {
            kuris=laik;

            nr = i;

        }

    }
    return nr;
}///Rezultatu spausdinimo funkcija
void rezultatai(int n, prad A[])
{
    ofstream fr("U2rez.txt");
    fr << numeris(n, A)<<endl;
    for(int i=0; i<n; i++)
    {
        for(int j=0; j<A[i].skaicius; j++)
        {
            if(A[i].n[j]==numeris(n, A))
            {
                fr << A[i].pavadinimas<<endl;
                break;
            }
        }
    }
    fr.close();
}
