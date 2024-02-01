#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

int main()
{
    ifstream fd("Duom1.txt");
    ofstream fr("Rez1.txt");
    int n, d;
    double viso, L[100], R[100];
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> d;
        for(int j=0; j<d; j++)
        {
            fd >> R[j];

            L[i]=L[i]+1/R[j];
        }
        viso=viso+1/L[i];
    }
    fr << fixed << setprecision (2) << viso<<endl;
}
