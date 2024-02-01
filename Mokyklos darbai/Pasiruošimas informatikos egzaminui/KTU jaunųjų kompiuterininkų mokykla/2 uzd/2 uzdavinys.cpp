#include <iostream>

using namespace std;

int main()
{
    int a, b, c;

    cout << "Iveskite kiek kiekvienos rusies pauksciu liko ziemoti: "<<endl;
    cin >> a>> b>> c;


    if (a>b && a>c)
    {
    if (b > c)
        {
        cout << a << endl << b <<endl << c << endl;
        cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< a-c;
        }


        if (c>b)
        {
        cout << a << endl << c <<endl << b << endl;
        cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< a-b;
        }
    }
    else if (b > a && b > c)
    {
        if (c>a)
        {
       cout << b << endl << c <<endl << a << endl;
       cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< b-a;
        }
        if (a>c)
        {
        cout << b << endl << a <<endl << c << endl;
        cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< b-c;
        }
    }
    else
    {
        if (b>a)
        {
        cout << c << endl << b <<endl << a << endl;
        cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< c-a;
        }
        if (a>b)
        {
        cout << c << endl << a <<endl << b << endl;
        cout << "Skirtumas tarp didziausio ir maziausio skaiciaus: "<< c-b;
        }
    }


    return 0;
}
