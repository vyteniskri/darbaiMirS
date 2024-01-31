#include <iostream>

using namespace std;

int main()
{
   int m=30, j=5;

   for (int i=5; i<=m; i++)
   {
       cout << i;
       if(j<10)
           {
               cout << j<<endl;
           }
           else cout << j/10<<endl;
       j++;



   }

    return 0;
}
