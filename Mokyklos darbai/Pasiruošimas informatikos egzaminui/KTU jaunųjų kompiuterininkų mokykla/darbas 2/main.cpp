#include <iostream>

using namespace std;

int main()
{
    int x, y, n;
    int isviso;
    cout << "pirmoje rado respiratoriu "; cin >> x;
    cout << "antroje rado respiratoriu "; cin >> y;
    cout << "vieno respiratoriaus kaina "; cin >> n;
    isviso = (x + y) * n;
    cout << endl << "Petriukas isviso sumokejo " << isviso << endl;

    return 0;
}
