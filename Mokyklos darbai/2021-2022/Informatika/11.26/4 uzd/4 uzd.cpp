#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

int main()
{
   int m;
   double d=1;
   int  k=0;
   double s;
   ofstream fr ("Rezultatai.txt");
   cout << "Iveskite knygos skyriu skaiciu "; cin >> m;

   while(k<m)
   {

       d++;
       k=k+d;

   }
   s=m/d;
   fr << "Tadas knyga perskaitys per "<< d << " dienas"<<endl;
   fr << "Tadas vidutiniskai per diena perskaite "<< s << " skyriu";

fr.close();


    return 0;
}
