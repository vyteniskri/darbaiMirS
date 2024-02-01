#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, char lytis[], double kaina[]);
 void avalyne(int n, char lytis[], double kaina[], double &v, double &m, double &vidv, double &vidm);
 double suma(int n, double kaina[]);
 void Atsakymas (int n, char lytis[], double kaina[], double &v, double &m, double &vidv, double &vidm);
int main()
{
    char lytis[100];
    double kaina[100], v=0, m=0, vidm, vidv;
    int n;
    duomenys (n, lytis, kaina);
    avalyne (n ,lytis, kaina, v, m, vidv, vidm);
    Atsakymas (n, lytis, kaina, v, m, vidv, vidm);
}
 void duomenys(int &n, char lytis[], double kaina[])
 {
     ifstream fd ("Duomenys.txt");
    fd >> n;
     for(int i=0;i<n;i++)
     {
         fd >> lytis[i] >> kaina[i];

     }
     fd.close();
 }
 void avalyne(int n, char lytis[], double kaina[], double &v, double &m, double &vidv, double &vidm)
 {
     double  km=0, kv=0;

     for(int i=0;i<n;i++)
     {
         if (lytis[i]=='v')
         {
             v=kaina[i]+ v;
             kv++;
         }
         else if (lytis[i]=='m')
         {
             m=kaina[i]+m;
             km++;
         }

     }
        vidv=v/kv;
         vidm=m/km;
 }
double suma(int n, double kaina[])
{
    double sum= 0;
   for(int i=0;i<n;i++)
   {
        sum = sum + kaina[i];
   }
   return sum;
}
void Atsakymas (int n, char lytis[], double kaina[], double &v, double &m, double &vidv, double &vidm)
{
    ofstream fr ("Rezultatai.txt");

    fr << m << endl << vidm << endl << v << endl << fixed << setprecision (2) << vidv << endl << suma(n, kaina);
}



