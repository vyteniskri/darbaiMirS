#include <iostream>

using namespace std;

int main()
{
    int var, a, b, x;

    cout << "Iveskite uzduoties varianta: "; cin >> var;
    cout << "Iveskite a reiksme: "; cin >> a;
    cout << "Iveskite b reiksme: "; cin >> b;

    switch(var)
{
    case (1):

        x=a*b+3;
        cout << "Atsakymas: "<<x;
        break;

    case (2):

        x=a+b;
        cout << "Atsakymas: "<<x;
        break;

    case (3):

        x=a-b;
        cout << "Atsakymas: "<<x;
        break;

}
    return 0;
}
