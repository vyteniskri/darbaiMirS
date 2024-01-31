#include <iostream>
#include <fstream>
using namespace std;

int main()
{
   int a; double kiek = 0, viso = 0;

   ifstream fd ("U1.txt ");
fd >> a;

   while (!fd.eof())
   {
       fd >> a;
       if (!fd.fail())
       {
            viso ++;
       }

        if(a % 2==0)
        {
            kiek++;
        }

       }

fd.close ();
cout <<kiek << " "<< viso << endl;





    return 0;
}
