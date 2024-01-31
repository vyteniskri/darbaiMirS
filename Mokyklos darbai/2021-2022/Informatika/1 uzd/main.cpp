#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void skaiciavimas(double &b, double &d, double &b1, double &d1, double &B, double &D, int &B1, int &D1);
string kuris(int B, int D);
int main()
{
   int B1=2500, D1=3200;
   double b1=1.12, d1=0.99, B, D, b, d;

    ifstream fd("duomenys.txt");
    fd >> b;
    fd >> d;
    skaiciavimas(b, d, b1, d1, B, D, B1, D1);

   cout <<fixed << setprecision(2)<< B << endl << D<<endl<<endl;


    cout << kuris(B, D)<<endl;

}
void skaiciavimas(double &b, double &d, double &b1, double &d1, double &B, double &D, int &B1, int &D1)
{
    B=(b*36000/100*b1)+B1;
    D=(d*36000/100*d1)+D1;

}
string kuris(int B, int D)
{
   if(B>D)
   {
    return "Geriau apsimoka pirki benzinu varoma automobili";
   }
   else return "Geriau apsimoka pirki dizelinu varoma automobili";
}
