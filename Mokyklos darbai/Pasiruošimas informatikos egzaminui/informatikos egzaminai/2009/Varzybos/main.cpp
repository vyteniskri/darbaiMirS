#include <iostream>
#include <fstream>
using namespace std;
struct varz
{
    string begikas, finisavo;
    int minutes, sekundes, sk;
    int greiciausi;
};
void duomenys(int &k, int &n, varz A[], int &kiek);
void rikiavimas(int kiek, varz A[]);
void rezultatai(int kiek, varz A[]);
int main()
{
    int k, n, kiek=0;
    varz A[50];
    duomenys(k, n, A, kiek);
    rikiavimas(kiek, A);
    rezultatai(kiek, A);
}
void duomenys(int &k, int &n, varz A[], int &kiek)
{
    int begik, maz=999999;
    ifstream fd("U2.txt");
    fd >> k;
    char eil[21];
    for(int i=0; i<k; i++)
    {
        fd >> begik >> ws;
        A[i].sk=begik/2;
        for(int j=0; j<begik; j++)
        {
            fd.get(eil, 21);
            A[j].begikas=eil;

            fd >> A[j].minutes >> A[j].sekundes >> ws;
        }
        ///Ieškau greičiausių bėgikų
        for(int j=0; j<A[i].sk; j++)
        {
            for(int z=0; z<begik; z++)
            {
                if(A[z].minutes*60+A[z].sekundes<maz && A[z].minutes*60+A[z].sekundes!=A[kiek-1].greiciausi)
                {
                    maz=A[z].minutes*60+A[z].sekundes;
                    A[kiek].finisavo=A[z].begikas;
                }

            }
            A[kiek].greiciausi= maz;
            kiek++;
            maz=999999;
        }
    }


}///Rikiavimo funkcija
void rikiavimas(int kiek, varz A[])
{
    for(int i=0; i<kiek; i++)
    {
        for(int j=i+1; j<kiek; j++)
        {
            if(A[i].greiciausi>A[j].greiciausi)
            {
                swap(A[i], A[j]);
            }
        }
    }
}///Rezultatu spausdinimo funkcija
void rezultatai(int kiek, varz A[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<kiek; i++)
    {

        fr << A[i].finisavo << A[i].greiciausi/60<< " "<< A[i].greiciausi%60<<endl;

    }
}
