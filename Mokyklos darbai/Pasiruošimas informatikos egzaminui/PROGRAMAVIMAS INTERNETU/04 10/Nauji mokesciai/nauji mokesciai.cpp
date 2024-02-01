#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    int metai;
    int dantys;
    int Pdantys;
    int Pmetai;
};
void duomenys(int &n, prad A[]);
int sumadantys(int n, prad A);
int sumametai(int n, prad A);
int viso(int n, prad A[]);

int main()
{
   int n;
   prad A[100];
   duomenys(n, A);

    cout << viso(n, A);

}
void duomenys(int &n, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].vardas >> A[i].metai >> A[i].dantys;
        A[i].Pdantys= sumadantys(n, A[i]);
        A[i].Pmetai = sumametai(n, A[i]);

    }
}
int sumadantys(int n, prad A)
{
    int P;
    if(A.metai>6 && A.metai<65)
    {
        P=5*A.dantys;
    }

    return P;
}
int sumametai(int n, prad A)
{
    int suma=0, viso;

       if(A.metai<6 && A.metai>65)
        {
            suma=A.vardas[0]-'A'+1;
        }

    viso=5*suma;
    return viso;
}
int viso(int n, prad A[])
{
    int S=0;
    for(int i=0; i<n; i++)
    {
        S= S+ A[i].Pdantys+ A[i].Pmetai;
    }
    return S;
}

