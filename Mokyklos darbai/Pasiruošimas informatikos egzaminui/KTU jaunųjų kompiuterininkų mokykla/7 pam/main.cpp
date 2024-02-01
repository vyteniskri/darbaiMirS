#include <iostream>

using namespace std;

int main()
{
   int a, b, s=0;

   cout << "Iveskite intervalo pradzia: "; cin >>a;
   cout << "Iveskite intervalo pabaiga: "; cin >>b;

   for (int i=a; i<=b; i++)
   {
      if (i % 6==0)
       {
           s++;
       }



   }
   cout << "Reikalingu marskineliu skaicius: "<< s;







    return 0;
}
