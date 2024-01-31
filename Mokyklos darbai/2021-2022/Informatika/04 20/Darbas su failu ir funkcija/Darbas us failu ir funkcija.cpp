#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int V[]);
int skaiciavimas(int n, int V[]);
void rezultatai(int n, int V[]);
int main()
{
   int n, V[100];
   duomenys(n, V);
   rezultatai(n, V);

}
void duomenys(int &n, int V[])
{
    int st_kaina, ked_kaina;
    ifstream fd("Duomenys.txt");
    fd>> n;
    for(int i=0; i<n; i++)
    {
        fd >> st_kaina >> ked_kaina;
        V[i]=st_kaina+(ked_kaina*4);

    }
}
int skaiciavimas(int n, int V[])
{
    int max_kaina=0;
    for(int i=0; i<n; i++)
    {
        if(V[i]>max_kaina)
            max_kaina=V[i];
    }
    return max_kaina;
}
void rezultatai(int n, int V[])
{
    ofstream fr("Rezultatai.txt");
    fr << "Brangiausias komplektas kainuoja "<< skaiciavimas(n, V)<< " Eur";

}
