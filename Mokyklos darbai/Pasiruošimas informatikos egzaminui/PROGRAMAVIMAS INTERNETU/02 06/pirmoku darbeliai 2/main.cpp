#include <fstream>
#include <iomanip>
#include <iostream>
using namespace std;
const char CDfv[] = "Duomenys.txt";
const char CRfv[] = "Rezultatai.txt";
//---------------------------------------------
struct Vaikas {
         string pav;
         int K[20];
};
//---------------------------------------------
void Skaitymas(Vaikas V[], int & n);
void Rasymas(Vaikas V[], int  n);
//---------------------------------------------
int main ()
{
  int  n;
  Vaikas V[100];
  Skaitymas(V, n);
  Rasymas(V, n);
  return 0;
}
//---------------------------------------------
void Skaitymas(Vaikas V[], int & n)
{
  char eil[16]; int k, sk;
  ifstream fd (CDfv);
  fd >> n >> k;
  fd.ignore(80, '\n');
  for (int i = 0; i < n; i++) {
    fd.get(eil, 15);
    V[i].pav = eil;
    for (int j = 1; j <=10; j++)
        V[i].K[j] = 0;
    for (int j = 0; j < k; j++){
    fd >> sk;
    V[i].K[sk] ++;
    }

  }

}
//---------------------------------------------
void Rasymas(Vaikas V[], int  n)
{
  ofstream fr (CRfv);
  for (int i = 0; i < n; i++) {
    cout << V[i].pav;
    for (int j = 1; j <= 10; j ++)
    cout  << V[i].K[j] << " ";
    cout << endl;
  }

}
