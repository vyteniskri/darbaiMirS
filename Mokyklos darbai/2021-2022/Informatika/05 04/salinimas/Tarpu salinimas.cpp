#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    ifstream fd("Duomenys.txt");
    string a[100];
    char eil[100];
   for(int i=0; i<2; i++)
   {
       fd.get(eil, 100);
       a[i]=eil;
    fd >> ws;

   }
   for(int i=0; i<2; i++)
   {
    cout << a[i]<<endl;
   }
}
