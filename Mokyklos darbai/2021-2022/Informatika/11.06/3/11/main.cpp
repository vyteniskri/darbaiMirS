#include <iostream>
#include <fstream>
using namespace std;
const char FV[]= "tryssk.txt";
int main()
{
   double a, b, c;
   double suma;

   ifstream fd (FV); //bandome atverti faila

   fd >> a >> b >> c; // skaitome duomenis
   fd. close();
   suma = a + b + c;
   cout << suma;

    return 0;
}
