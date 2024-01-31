#include <iostream>
#include <fstream>
using namespace std;

int main()
{
   int n, sum=0, sk;
   ifstream fd("U1.txt");
    fd >> n;

  for (int i = 0; i < n; i++)
  {
      fd >> sk;

      if (sk % 2==0)

      {
          sum++;
      }


  }

   fd.close ();


  if (sk > 0)
  {
      cout << sum;
  }
  else
  {
      cout << "Nera";
  }





    return 0;
}
