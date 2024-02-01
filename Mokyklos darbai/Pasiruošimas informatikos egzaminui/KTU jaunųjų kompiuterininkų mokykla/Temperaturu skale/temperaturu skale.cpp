#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    double K;
    double C, F, R;

    const double  k = 273.16, r =  0.8;

    cout << "Temperaturu skales" << endl;

    cout << "Iveskite temepratura Kelvino skaleje: "; cin >> K;

    C = K - k;

    cout << fixed << setw(10)<< setprecision(2) << C << " Celcijaus laipsniu"<< endl;

    F = 9*C/5+32;

    cout << fixed <<setw(10) << setprecision(2) << F << " Farenheito laipsniu"<<endl;

    R = r * C;

    cout << fixed <<setw(10) << setprecision(2) << R << " Reomiuro laipsniu" << endl;



    return 0;
}
