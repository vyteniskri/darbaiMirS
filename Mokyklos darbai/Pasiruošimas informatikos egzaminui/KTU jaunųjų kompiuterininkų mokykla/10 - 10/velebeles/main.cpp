#include <iostream>

using namespace std;

int main()
{
    int n, G, Z, R, R1, R2, Rvisas; // kruveliu skaicius
    int v; // veleveliu skaicius;

    cin >> n; // Juosteliu kruveliu skaicius
    cout << "Z "; cin >> Z;
    cout << "R "; cin >> R;
    cout << "G "; cin >> G;
    cout << "R "; cin >> R1;
    cout << "R "; cin >> R2;

    Rvisas = R + R1 + R2;


    if (G > Z) v= Z/2;
    else v = G/2;


    if (G > Rvisas) v= Rvisas/2;
    else v = G/2;


    if (Rvisas > Z) v = Z/2;
    else v= Rvisas/2;


    cout << v <<endl;


    int G1, Z1, R3;

    G1 = G - v*2;
    Z1 = Z - v*2;
    R3 = Rvisas - v*2;

    cout << "G = "<< G1 << endl;
    cout << "Z = "<<  Z1<< endl;
    cout << "R = "<< R3 << endl;







    return 0;
}
