#include <iostream>
#include <fstream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    double a[100];
    ifstream fd("Duomenys.txt");
    for(int i=0; i<2; i++)
    {
        fd >> a[i];

    }



        for(int i=0; i<2; i++)
    {
         cout << setw(11);
        if(1<abs(a[i]) && abs(a[i])<100)
        {
            cout << fixed;
        }
        else cout << scientific;
         cout << setprecision(4)<< a[i]<<endl;
    }

}
