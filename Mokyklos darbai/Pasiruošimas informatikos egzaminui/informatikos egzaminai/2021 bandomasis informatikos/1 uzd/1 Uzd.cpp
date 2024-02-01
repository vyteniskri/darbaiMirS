#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    int dienam, menesiaid, menesiaim;
    int kiek;
};
void duomenys(int &n, prad A[]);
int penktadieniu(prad H, prad A[]);

int main()
{
    ofstream fr("U1rez.txt");
    int n;
    prad A[1000];
    duomenys(n, A);
    for(int i=0; i<n; i++)
    {
    cout << A[i].kiek <<endl;
    }
    fr.close();

}// Duomenu spausdinimo funkcija
void duomenys(int &n, prad A[])
{
    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].dienam >> A[i].menesiaim;
        for(int j=0; j<A[i].menesiaim; j++)
        {
            fd >> A[j].menesiaid;


        }
        A[i].kiek = penktadieniu(A[i], A); // Kreipiuosi i funkcija


    }
    fd.close();
} // Penktadienio 13 skaiciavimas
int penktadieniu(prad H, prad A[])
{
    int p=-1, d=1, k=0;
    for(int i=0; i<H.menesiaim; i++)
    {

        for(int j=0; j<A[i].menesiaid; j++)
        {

            p++;

            if(p==5 && d==13)
            {
                k++;
            }
            else if(p==7)
            {
                p=0;
            }
            d++;
        }
        d=1;


    }
    return k;
}
