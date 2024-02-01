#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &k, int &pirmas, int &antras, int &trecias, int &taskai1, int &taskai2, int &taskai3, int &t1, int &t2, int &t3);
void kiek(int b1, int b2, int b3, int &taskai1, int &taskai2, int &taskai3);
int geriausia(int taskai1, int taskai2, int taskai3, int t1, int t2, int t3);
int main()
{
    ofstream fr("U2rez.txt");
   int k, pirmas=0, antras=0, trecias=0;
   int taskai1=0, taskai2=0, taskai3=0;
   int b1, b2, b3, t1, t2, t3;
   duomenys(k, pirmas, antras, trecias, taskai1, taskai2, taskai3, t1, t2, t3);
   fr << pirmas << " "<< antras << " "<< trecias<<endl;
   fr << taskai1 << " "<< taskai2 << " "<< taskai3<<endl;
   fr << geriausia(taskai1, taskai2, taskai3, t1, t2, t3);
}///Duomenu spausdinimo funkcija
void duomenys(int &k, int &pirmas, int &antras, int &trecias, int &taskai1, int &taskai2, int &taskai3, int &t1, int &t2, int &t3)
{
    int b1, b2, b3;
    ifstream fd("U1.txt");
    fd >> k;
    for(int i=0; i<k; i++)
    {
        fd >> b1 >> b2 >> b3;
        kiek(b1, b2, b3, taskai1, taskai2, taskai3);
        pirmas=pirmas+b1;
        antras=antras+b2;
        trecias=trecias+b3;

    }
    fd >> t1 >> t2 >> t3;
} ///Tasku apskaiciavimo procedura viename skyriuje
void kiek(int b1, int b2, int b3, int &taskai1, int &taskai2, int &taskai3)
{
    if(b1==b2 && b1==b3)
    {
        taskai1=taskai1+0;
        taskai2=taskai2+0;
        taskai3=taskai3+0;
    }
    else if(b1>b2 && b1>b3)
    {
         taskai1=taskai1+4;
    }
    else if(b2>b1 && b2>b3)
    {
         taskai2=taskai2+4;
    }
     else if(b3>b2 && b3>b1)
    {
         taskai3=taskai3+4;
    }
    else if(b1==b2 && b1!=b3)
    {
        taskai1=taskai1+2;
        taskai2=taskai2+2;
    }
    else if(b1==b3 && b1!=b2)
    {
        taskai1=taskai1+2;
        taskai3=taskai3+2;
    }
    else if(b2==b3 && b2!=b1)
    {
        taskai2=taskai2+2;
        taskai3=taskai3+2;
    }
}///Geriausias logotipas visoje imoneje
int geriausia(int taskai1, int taskai2, int taskai3, int t1, int t2, int t3)
{
    if(taskai1==taskai2 || taskai1==taskai3 || taskai2==taskai3)
   {
       taskai1=taskai1+t1;
       taskai2=taskai2+t2;
       taskai3=taskai3+t3;
   }
   if(taskai1>taskai2 && taskai1>taskai3)
   {
       return 1;
   }
   else if(taskai2>taskai1 && taskai2>taskai3)
   {
       return 2;
   }
   else if(taskai3>taskai1 && taskai3>taskai2)
   {
       return 3;
   }
}
