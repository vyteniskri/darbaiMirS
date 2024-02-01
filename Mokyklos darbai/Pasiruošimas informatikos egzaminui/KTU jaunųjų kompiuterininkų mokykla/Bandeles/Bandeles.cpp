#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

int main()
{
   double a, b;
   int n1, n2, n3;
   double k, isviso;

   cout << "Iveskite kainas a ir b: "; cin >> a >> b;
   cout << "Iveskite kiekius n1, n2, n3: "; cin >> n1 >> n2 >> n3;
   cout << "Iveskite bandeles kaina: "; cin >> k;

   if (k<= a) isviso =k*n1;
   else if (a<k, k<b) isviso =k*n2;
   else if (k>=b) isviso =k*n3;

   cout << fixed << setprecision(2)<<"Uz bandeles bus sumoketa: " << isviso<< " e.";



    return 0;
}
