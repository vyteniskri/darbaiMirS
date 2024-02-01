#include <iostream>

using namespace std;

int main()
{



    double a, b, h;
    double s;
    cout << "Raskite trapecijos plota." <<endl;
    cout << endl << "Trapecijos pagrindai "; cin >> a; cin >> b;
    cout << "Trapecijos aukstine "; cin >> h;
    s = (a + b)/2*h;
    cout << "Trapecijos plotas " << s << endl;

    return 0;
}
