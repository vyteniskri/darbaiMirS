#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

double Plotas(double a, double b);
double DangosKaina(double p, double kaina);
int main()
{
    int n; //kabinetu skaicius
    double s=0; //pinigu suma, reikalinga visu kabinetu grindu dangai pirkti
    double a, b, k;

    cout << Plotas(15,10)<<endl;
    cout << DangosKaina(12.5, 10)<<endl;
    ifstream fd ("Duomenys.txt");
    fd >> n;
    cout << n<<endl;
    for (int i=0; i<n;i++)
    {
        double p, dk;
        fd >> a >> b >> k;

        p = Plotas(a, b);
        dk = DangosKaina(p,k);
        s= s +dk;
        cout << fixed<<setprecision(2)<<p<<endl;
        cout << fixed <<setprecision(2)<< dk << endl;
        cout << fixed <<setprecision(2)<< s << endl;


    }
    fd.close();
    ofstream fr("Rezultatai4.txt");
    fr << fixed << setprecision (2) << s<<endl;
    fr.close();




return 0;
}
double Plotas(double a, double b)
{
    double p;

     p = a*b;

      return p;
}
double DangosKaina(double p, double kaina)
{
    double dk;

    dk = 1.03 * p * kaina;

    return dk;
}
