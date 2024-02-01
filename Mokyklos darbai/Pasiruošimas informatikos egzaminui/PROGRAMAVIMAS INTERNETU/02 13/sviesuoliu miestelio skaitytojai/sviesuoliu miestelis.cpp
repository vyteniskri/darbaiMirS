#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char vardas[15];
    int skaiciai[100];
    double kaina[100];
    double isld;
    int viso =0;
};
void duomenys(int &n, int &k, prad A[]);
double islaidos(double kaina[], int skaiciai[], int k);
double visas(int n, prad A[]);
void rezultatai(int n, prad A[]);
prad daugiausiai(int n, prad A[]);
prad maziausia(int n, prad A[]);
int main()
{
    int n, k;
    prad A[100];
    duomenys(n, k ,A);
    rezultatai(n, A);

}
void duomenys(int &n, int &k, prad A[])
{

    ifstream fd("Duomenys.txt");
    fd >> n >> k >> ws;
     for(int i=0;i<1;i++)
    {
        for(int j=0; j<k; j++)
        {

            fd >> A[i].kaina[j];
        }

    }
            fd >>ws;
    for(int i=0; i<n; i++)
    {

        fd.get(A[i].vardas, 15);
        for(int z=0; z<k; z++)
        {
            fd >> A[i].skaiciai[z];
            A[i].viso= A[i].viso + A[i].skaiciai[z];
        }
        fd >> ws;


            A[i].isld = islaidos(A[0].kaina, A[i].skaiciai, k);

    }
}
double islaidos(double kaina[], int skaiciai[], int k)
{
    double sum =0;
    for(int i=0; i<k; i++)
    {
    sum = sum + (kaina[i]*skaiciai[i]);


    }
    return sum;

}
double visas(int n, prad A[])
{
    double suma=0;
    for(int i=0; i<n; i++)
    {
        suma = suma + A[i].isld;
    }

    return suma;
}
prad daugiausiai(int n, prad A[])
{
    prad a;
    a.viso=0;

    for(int i=0; i<n; i++)
    {

        if(A[i].viso>a.viso)
        {

            a=A[i];

        }

    }

    return a;
}
prad maziausia(int n, prad A[])
{
    prad b;
    b.isld=100;
    for(int i=0; i<n;i++)
    {
        if(b.isld>A[i].isld)
        {
            b=A[i];
        }
    }
    return b;
}
void rezultatai(int n, prad A[])
{
    prad did = daugiausiai(n, A);
    prad maz = maziausia(n, A);
    ofstream fr("Rezultatai.txt");

    for(int i=0; i<n; i++)
    {
        cout << fixed << setprecision (2) << A[i].vardas << A[i].isld <<endl;
    }
    cout << visas(n, A)<<endl;
    cout << did.vardas << did.viso<<endl;
    cout << maz.vardas << maz.isld;
}
