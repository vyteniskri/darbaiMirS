#include <iostream>

using namespace std;

int main()
{
    int n, a, k, h, y, r, o, t;
    int d, s;
    cout << "Keliems draugams gales Marius paruosti saldainiu rinkinius, kiek saldainiu liks supakavus dovanas?  " << endl;
    cout << endl << "Kiek saldainiu gauna Marius? "; cin >> n;
    cout << "Kiek saldainiu suvalgo? "; cin >> a;
    cout << "Kelios dienos liko iki kaledu? "; cin >> k;
    h = n * k;
    y = a * k;
    r = h - y;
    o = r/a;
    cout << "Marius dovanas paruos " << o << " draugu"<< endl;
    t = r - a * o;
    cout << "Supakavus dovanas liks " << t << " saldainiai"<< endl;


    return 0;
}
