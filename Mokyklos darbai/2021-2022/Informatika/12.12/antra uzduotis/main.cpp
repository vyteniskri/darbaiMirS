#include <iostream>
#include <cmath>
using namespace std;

int main()
{
   int n,a, b, d;

   cin >> n;

   for(int i=1; i<=n; i++)
   {
       a=i*i;
       d=n-a;
       b= sqrt(d);
       if (b%10==0)
       {
           cout << "Taip"<<endl;

       }
        else cout << "Ne"<<endl;



   }



    return 0;
}
