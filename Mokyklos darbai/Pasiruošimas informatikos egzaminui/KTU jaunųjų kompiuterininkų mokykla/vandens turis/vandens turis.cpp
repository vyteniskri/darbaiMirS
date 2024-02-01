#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
   double a, b, r;
   double Vvand, Vrutu,  Vkubo;

   cout << "iveskite kubo krastines ilgi a: "; cin >> a;
   cout << "iveskite rutulio skersmeni b: "; cin >> b;

    Vkubo = a*a*a;
    cout << endl << fixed << setprecision(2)<< "Kubo turis: "<< Vkubo <<endl;

   r = b/2;
   Vrutu = 4.0/3*3.14*r*r*r;
   cout << fixed << setprecision(2)<< "Rutulio turis: "<< Vrutu <<endl;

   Vvand = Vkubo - Vrutu;
   cout << fixed << setprecision(2)<< "Vandens turis: "<< Vvand;
    return 0;
}
