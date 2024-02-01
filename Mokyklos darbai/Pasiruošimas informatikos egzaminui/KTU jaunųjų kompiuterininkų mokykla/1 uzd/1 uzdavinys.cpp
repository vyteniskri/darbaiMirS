#include <iostream>
#include <iomanip>


using namespace std;

int main()
{
    double a, b, c, d, a1, b1, c1, d1;
    cout << "Iveskite lasiu vidurkius: "; cin >> a >> b >> c >> d;

    if ( a > b && a > c && a>d)
        {
        b1 = a - b;
        c1 = a - c;
        d1 = a - d;

                cout << fixed<< setprecision(1)<<"Didziausias vidurkis: "<< a<< endl;
                cout << fixed<< setprecision(1)<<"Kitu klasiu vidurkiai skiriasi: " << b1 << " " << c1 << " "<< d1;
    }
           else if (b > a && b > c && b > d)
{

        a1 = b - a;
        c1 = b - c;
        d1 = b - d;

                cout <<fixed<< setprecision(1)<<"Didziausias vidurkis: "<< b<< endl;
                 cout << fixed<< setprecision(1)<<"Kitu klasiu vidurkiai skiriasi: " << a1 << " " << c1 << " "<< d1;
}

            else if ( c >a && c>b && c>d)
{

        a1 = c - a;
        b1 = c - b;
        d1 = c - d;

                cout <<fixed<< setprecision(1)<<"Didziausias vidurkis: "<< c<< endl;
                cout << fixed<< setprecision(1)<<"Kitu klasiu vidurkiai skiriasi: " << a1 << " " << b1 << " "<< d1;
}

            else
    {


        a1 = d - a;
        b1 = d - b;
        c1 = d - c;

                cout << fixed<< setprecision(1)<<"Didziausias vidurkis: "<< d<< endl;
                  cout << fixed<< setprecision(1)<<"Kitu klasiu vidurkiai skiriasi: " << a1 << " " << b1 << " "<< c1;
}


    return 0;
}
