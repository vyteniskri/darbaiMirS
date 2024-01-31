#include <iostream>
#include <fstream>
#include <iomanip>
#include <algorithm>

using namespace std;
struct Duomenys // sportavimo duomenims saugoti
{
    string pavadinimas;
    int kartai;
};

void Nuskaitymas (int &n, Duomenys A[]);
void Rikiavimas (int n, Duomenys A[]);
void Irasymas (int n, Duomenys A[]);

int main()
{
    int n = 0; //kiek yra irasu
  Duomenys A[100]; //visiems sportams saugoti
  Nuskaitymas(n, A);
  Rikiavimas (n, A);
  Irasymas(n, A);

return 0;
}
// Duomenu nuskaitymas ir iskart apskaiciavimas, kiek kartu kas sportuota
void Nuskaitymas (int &n, Duomenys A[])
{
    ifstream GET ("U2.txt");
    int x;
    GET >> x;
    for (int i=0; i < x; i++)
    {
        string pav;
        int kart;
        GET >> pav >> kart;
        cout << pav;
        bool yra = false;
        for (int j = 0; j < n ; j++)
        {
            if (A[j].pavadinimas ==pav)
            {
                yra = true;
                A[j].kartai += kart;
            }
        }
        if (!yra)
        {
            A[n].pavadinimas = pav;
            A[n].kartai = kart;
            n++;
        }
                }
    GET.close();
}
// rikiavimas nuo did iki maz ir jeigu kartai sutampa, tuomet pagal abëcëlæ
void Rikiavimas(int n, Duomenys A[])
{
    for (int i = 0; i < n; i++)
    {
        for (int j = i; j < n; j++)
        {
            if (A[i].kartai < A[j].kartai)
            {
                swap(A[i], A[j]);
            }else if (A[i].kartai == A[j].kartai)
            {
                if (A[i].pavadinimas < A[j].pavadinimas)
            {
                swap(A[i], A[j]); //sukeitimas, elementus
            }
        }
    }
}
}
void Irasymas(int n, Duomenys A[])
{

    ofstream PUT("U2rez.txt");
    for (int i = 0; i< n; i++)
    {
        cout << setw(20) << left << A[i].pavadinimas << " " << A[i].kartai << endl;

    }
}
