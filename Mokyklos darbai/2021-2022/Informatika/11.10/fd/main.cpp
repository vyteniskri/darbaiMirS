#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

int main()
{
   int  d;
   double sum = 0, v, n;
   ifstream fd ("U1.txt");
   fd >> n;
   for (int i = 0; i<n; i++)
   {
       fd >> d;
       sum = sum + d;


   }
   fd.close ();
    v = sum /n;

   cout <<fixed << setprecision(3)<< v;

    return 0;
}
