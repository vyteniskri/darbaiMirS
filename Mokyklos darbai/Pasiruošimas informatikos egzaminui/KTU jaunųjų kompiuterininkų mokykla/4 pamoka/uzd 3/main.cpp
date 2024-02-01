#include <iostream>

using namespace std;

int main()
{
    int k, m, n, b;
    cout << "Kelis kartus keltui teks perkelti k skaiciu automobiliu, kuriem persikelti per upe nepavyks? " << endl;
    cout << endl << "Automobiliu skaicius "; cin >> k;
    cout << "I kelta telpa automobiliu "; cin >> m;
    n = k/m;
    cout << "Perkels per kartu "<< n << endl;
    b = k - n*m;
    cout << "Liks neperkelta " << b <<endl;

    return 0;
}
