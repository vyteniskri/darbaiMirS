#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
   int n, k=0,  m;
   double  v, s=0;

   cin >> n;

   for (int i=0; i<n; i++)
   {
      cin >> m;
      s = s + m;
       if (m>20) k++;
   }
    v = s/n;
   cout <<fixed << setprecision(1)<< "v= "<< v << " " << "k= " << k;

    return 0;
}
