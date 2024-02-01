#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char vardas[15];
    double skaiciaia, skaiciaib, skaiciaic, procent;
};
void duomenys(int &ak, int &bk, int &rk, int &n, prad A[]);
double v1(int ak, double a);
void rezultatai(int n, prad A[]);
double procentai(double a, double b, double c);
int main()
{
    int ak, bk, rk, n;
   prad A[100];
   duomenys(ak, bk, rk, n, A);
    rezultatai(n, A);
}
void duomenys(int &ak, int &bk, int &rk, int &n, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> ak >> bk >> rk;
    fd >> n >> ws;
    double a, b, c;
    for(int i=0; i<n;i++)
    {
        fd.get(A[i].vardas, 15);
        fd >> a >> b >> c >> ws;
        cout << a << " "<< b << " "<< c<<endl;
        A[i].skaiciaia = v1(ak, a);
        A[i].skaiciaib = v1(bk, b);
        A[i].skaiciaic = v1(rk, c);
        A[i].procent =  procentai(a, b, c);
    }
}
double v1(int ak, double a)
{
    double x = ak*a;
    return x;
}
double procentai(double a, double b, double c)
{
    double y =100-a-b-c;
    return y;
}
void rezultatai(int n, prad A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n;i++)
    {
        fr <<fixed << setprecision(1)<< A[i].vardas << A[i].skaiciaia << " "<< A[i].skaiciaib << " "<< A[i].skaiciaic<< " " << A[i].procent<<endl;
    }


}
