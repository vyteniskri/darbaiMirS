#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
    int x, y, d;
    double l;



    cout << "du sveikieji skaiciai x ir y, saulio koordinates" ; cin>> x >> y;

    l= sqrt(x*x + y*y);

    if (l < 5) d= 10;
    else if (l>5, l<10) d= 5;
    else d= 0;



    cout << "kai x= " << x <<", y= " << y << ", tuomet: Atstumas iki taikinio centro "<< fixed << setprecision(1) << l <<". Saulys gaus " << d << " tasku" << endl;





    return 0;
}
