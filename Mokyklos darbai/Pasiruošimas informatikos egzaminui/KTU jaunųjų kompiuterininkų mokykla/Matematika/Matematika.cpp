#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    int a, b, c, d, e;
    double vidurkis;

    cout << "Petriuko pazymiai: "; cin >> a >> b >> c >> d >>e;

    vidurkis = round(a + b + c + d + e)/5;

    if(vidurkis > 9) cout << "Petriukas gaus tris saldainius";

    else if (vidurkis<9, vidurkis>7) cout << "Petriukas gaus du saldainius";

    else  cout << "Petriukas gaus viena saldaini";



    return 0;
}
