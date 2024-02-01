#include <iostream>

using namespace std;

int main()
{
    int m, n, k, t;
    cout << "Kelios bus pilnos dezutes ir kiek puodeliu liks nesupakuota? " << endl;
    cout<< endl << "Puodeliu, kuriuos reikia supakuoti, skaicius: "; cin >> m;
    n = m/3;
    cout << "Pilnu dezuciu skaicius: " << n << endl;
    t = n*3;
    k = m - t;
    cout << "Nesupakuotu puodeliu skaicius: " << k << endl;

    return 0;
}
