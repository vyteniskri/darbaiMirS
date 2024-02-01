#include <iostream>

using namespace std;

int main()
{
    int a, b, c, l;
    int s, k;
    cout << "Po kiek sausainiu gavo kiekvienas gimtadienio dalyvis ir kiek papildomai sausainiu liko?" << endl;
    cout << endl << "Kiek sausainiu iskepe Tautvydas? "; cin >> a;
    cout << "Keli draugai atsinese sausainiu? "; cin >> b;
    cout << "Kiek zmoniu dalyvavo "; cin >> c;
    l = a * b + a;
    s = l/c;
    cout << "Kiekvienas dalyvis gavo po " << s << " sausainius" << endl;
    k = l - s * c;
    cout << "Tautvydas papildomai gavo " << k << " sausainius" << endl;

    return 0;
}
