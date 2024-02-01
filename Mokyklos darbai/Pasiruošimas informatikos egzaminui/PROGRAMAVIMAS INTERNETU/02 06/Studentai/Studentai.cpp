#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char marsrutas[20];
    int laikas;
};
void duomenys(int &n, prad A[]);
void rezultatai(int n, prad A[]);
void rikiavimas(int n, prad A[]);

int main()
{
  int n;

  prad A[100];
  duomenys(n, A);
    rezultatai(n, A);
    rikiavimas(n, A);
}

void duomenys(int &n, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n>> ws;
    int a, b, c, d;
    for(int i=0; i<n;i++)
    {
        fd.get(A[i].marsrutas, 20);

        fd >>a>> b >> c >> d >>ws;
        A[i].laikas = c*60+d - a*60+b;
    }
}

void rezultatai(int n, prad A[])
{
    for(int i=0; i<n; i++)
    {
        cout << A[i].marsrutas << " "<< A[i].laikas<<endl;
    }
}
void rikiavimas(int n, prad A[])
{
    for(int i=0; i<n;i++)
    {
        for(int j=i+1;j<n;j++)
        {
            if(A[i].laikas<A[j].laikas)
            {
                swap(A[i], A[j]);
            }

        }
    }
}
