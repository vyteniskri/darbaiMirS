#include <iostream>

using namespace std;

int main()
{
    int n1, n3, n5, k;
    int islaidos, pard1, pard3, pard5;
    cin >> n1 >> n3 >> n5 >> k;
    cin >> islaidos >> pard1 >> pard3 >> pard5;

    int pripilt1, pripilt3, pripilt5;

    pripilt5 = min(k/5, n5);
    k = k - pripilt5*5;

    pripilt3 = min (k/3, n3);
    k = k - pripilt3 * 3;

    pripilt1 = min (k/1, n1);
    k = k - pripilt1;

    cout << endl << pripilt1 << " " << pripilt3 << " " << pripilt5 << " "<<k <<endl;

    int nepa1, nepa3, nepa5;

    nepa5 = n5 - pripilt5;
    nepa3 = n3 - pripilt3;
    nepa1 = n1- pripilt1;

    cout << nepa1 << " " << nepa3 << " " << nepa5<< endl;

    int reikejo1, reikejo3, reikejo5;

    reikejo5 = k/5;
    k = k - reikejo5*5;

    reikejo3 = k/3;
    k = k - reikejo3 * 3;

    reikejo1 = k/1;
    k = k - reikejo1 * 1;

    cout << reikejo1 << " " << reikejo3 << " " << reikejo5<< endl;

    int pelnas;

    pelnas = (pripilt1 + reikejo1)*pard1 + (pripilt3 + reikejo3)*pard3 + (pripilt5 + reikejo5)*pard5 - islaidos;

    cout << pelnas;

    return 0;
}
