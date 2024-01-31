#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int F1=0, F2=1, sum;
   ofstream fr ("Reiksmes.txt");
fr << F1 <<endl<<F2<<endl;
   for( int n = 0; n <=20;n++)
   {

       sum = F1+F2;
       F1=F2;
       F2=sum;

    fr<<sum<<endl;
   }
    fr.close ();



    return 0;
}
