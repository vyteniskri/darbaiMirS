#include <iostream>
#include <fstream>
#include <cmath>
#include <iomanip>
using namespace std;
void duomenys(int &m, int &n, double x[], double y[], double X[], double Y[], double S[], double V[], int &N);
double atstumas(int m, double S[]);
double maz(int m, double V[]);
double didziausias(int m, double V[]);

int main()
{
    int m, n, N=0;
    double x[100], y[100], X[100], Y[100], S[100], V[100];
    duomenys(m, n, x, y, X, Y, S, V, N);
    cout << "Maziausias greitis: "<< fixed << setprecision (2) << maz(m, V)<< " mm/s"<<endl;
    cout << "Vidutinis greitis: "<< atstumas(m, S)/N<< " mm/s"<<endl;
    cout << "Didziausias greitis: "<< didziausias(n, V)<< " mm/s"<<endl;
    cout << "Nukeliautas atstumas: "<< atstumas(m, S) << " mm";


}
void duomenys(int &m, int &n, double x[], double y[], double X[], double Y[], double S[], double V[], int &N)
{
    int o=0;
    ifstream fd("Duomenys.txt");
    fd >> m >> n;
    x[0]= {0};
    y[0]= {0};
    for(int i=1; i<=m; i++)
    {
        N=N+o;
        fd >> x[i] >> y[i];
        X[i]= x[i] - x[i-1];
        Y[i]= y[i] - y[i-1];
        S[i] = sqrt((X[i]*X[i])+(Y[i]*Y[i]));
        V[i] = S[i]/n;
        o=n;
    }
    fd.close();
}
double atstumas(int m, double S[])
{
    double k=0;
    for(int i=1; i<=m; i++)
    {
        k=k+S[i];
    }
    return k;
}
double maz(int m, double V[])
{
    double l=99;
    for(int i=1; i<=m; i++)
    {
        if(V[i]<l)
        {
            l=V[i];
        }
    }
    return l;
}
double didziausias(int m, double V[])
{
    double s=0;
    for(int i=1; i<=m; i++)
    {
        if(V[i]>s)
        {
            s=V[i];
        }

    }
    return s;
}
