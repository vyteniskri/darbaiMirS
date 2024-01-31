#include <iostream>
#include <fstream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
   int a, b, c; // a - trumpesnioji krast, b - ilgesnioji krast, c izambine.

   ofstream fr("Rezultatai.txt");


   for (int i =0; i<8;i++)
   {
       cin >> c;

       b= c-1;

       a= sqrt(pow(c,2)-pow(b,2));

       fr << setw(3)<< a<< setw(6)<<b<<setw(9)<<c<<endl;



   }
   fr.close();



    return 0;
}
