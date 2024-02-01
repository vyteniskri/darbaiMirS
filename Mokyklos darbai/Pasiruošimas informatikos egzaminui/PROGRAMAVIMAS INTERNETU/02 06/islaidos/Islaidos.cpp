#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char vardas[15];
    double kainosb, kainosd;
};
void duomenys(double &b, double &d, double &m, int &n, prad A[]);
void rezultatai(int n, prad A[]);
double skaiciavimas(double b,double m, double a);
int main()
{
   double b, d, m;
   int n;
   prad A[100];
   duomenys(b, d, m, n, A);
   rezultatai(n, A);

}
void duomenys(double &b, double &d, double &m, int &n, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> b >> d >> m >> n>> ws;
    double a, B;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 15);
        fd >> a >> B >> ws;
        A[i].kainosb = skaiciavimas(b, m, a);
        A[i].kainosd = skaiciavimas(d, m, B);
    }
}
double skaiciavimas(double b,double m, double a)
{
    double x=b*m/100*a;

    return x;
}
void rezultatai(int n, prad A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0;i<n;i++)
    {
        cout <<fixed << setprecision(2)<< A[i].vardas << A[i].kainosb<< " "<< A[i].kainosd<<endl;
    }
}
