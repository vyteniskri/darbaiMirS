#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

int main()
{
   int n, Viso, ts;
   double sur=0;
   double vid;

   ifstream fd("U1.txt");

    fd >> n;
    Viso = n*6;
    for (int i = 0; i<n; i++)
    {

        fd >> ts;
        sur = sur + ts;


    }
    fd.close();
  vid = sur/n;

    cout << "Viso tasku: "<< Viso << endl;
    cout << "Tomas surinko: "<< sur << endl;
    cout <<fixed << setprecision (1)<< "Jo tasku vidurkis: "<< vid << endl;

    if (Viso/2>sur)
    {
        cout <<  "Loterija pralaimeta."<< endl;
    }
    else
    {
        cout <<  "Loterija laimeta."<< endl;
    }



    return 0;
}
