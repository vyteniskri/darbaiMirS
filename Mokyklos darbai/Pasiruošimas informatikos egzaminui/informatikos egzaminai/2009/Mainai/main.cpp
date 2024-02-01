#include <iostream>
#include <fstream>
using namespace std;
void kokia(int Gnom[], int Gsk[], int g, int e, int Enom[], int Esk[], int Gikeisti[], int Eikeisti[], int &viso1, int &viso2);

int main()
{
    int g, Gnom[50], Gsk[50], e, Enom[50], Esk[50], Gikeisti[50], Eikeisti[50], viso1=0, viso2=0;
    ifstream fd("U1.txt");
    ofstream fr("U1rez.txt");
    fd >> g;
    for(int i=0; i<g; i++)
    {
        fd >> Gnom[i];
    }
    for(int i=0;i<g; i++)
    {
        fd >> Gsk[i];
    }
    fd >> e;
    for(int i=0; i<e; i++)
    {
        fd >> Enom[i];
    }
    for(int i=0; i<e; i++)
    {
        fd >> Esk[i];
    }
    kokia(Gnom, Gsk, g, e, Enom, Esk, Gikeisti, Eikeisti, viso1, viso2);
    for(int i=0; i<e; i++)
    {
        fr << Enom[i] << " " << Gikeisti[i]<<endl;
    }
    fr << viso1<<endl;
     for(int i=0; i<g; i++)
    {
        fr << Gnom[i] << " " << Eikeisti[i]<<endl;
    }
    fr << viso2;
}///Funkcija, kurioje skaičiuoju, kokią pinigų sumą keičia studentas.
void kokia(int Gnom[], int Gsk[], int g, int e, int Enom[], int Esk[], int Gikeisti[], int Eikeisti[], int &viso1, int &viso2)
{
    int sum1=0, sum2=0;
    for(int i=0; i<g; i++)
    {
        sum1=sum1+Gnom[i]*Gsk[i];
    }
    for(int i=0; i<e; i++)
    {
        sum2=sum2+Enom[i]*Esk[i];
    }
    ///Gilijos studento pinigai verčiami į Eglijos pingus
    if(sum1<=3000)
    {
       for(int i=0; i<e; i++)
        {
            Gikeisti[i] = sum1/Enom[i];
            sum1=sum1-Gikeisti[i]*Enom[i];
            viso1=viso1+Gikeisti[i];
        }
    }
    ///Egilijos studento pinigai verčiami į Gilijos pingus
    if(sum2<=3000)
    {
       for(int i=0; i<g; i++)
        {
            Eikeisti[i] = sum2/Gnom[i];
            sum2=sum2-Eikeisti[i]*Gnom[i];
            viso2=viso2+Eikeisti[i];
        }
    }

}
