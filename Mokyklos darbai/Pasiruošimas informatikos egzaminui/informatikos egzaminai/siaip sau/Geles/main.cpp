#include <iostream>
#include <fstream>
using namespace std;
int did(int interval[]);
int pradzia(int interval[]);
int pabaiga(int interval[]);
void rezultatai(int interval[]);
int main()
{
    ifstream fd("U1.txt");
    int n, nr ,pm , pd, gm, gd, p, interval[93]={0}, g;
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> nr >> pm >> pd >> gm >> gd;
        if(pm==6)
        {
            p=0;
        }
        else if(pm==7)
        {
            p=30;
        }
        else if(pm==8)
        {
            p=61;
        }
        if(gm==6)
        {
            g=0;
        }
        else if(gm==7)
        {
            g=30;
        }
        else if(gm==8)
        {
            g=61;
        }
        for(int j=p+pd;j<g+gd; j++)
        {
            interval[j]++;

        }
    }

    rezultatai(interval);
}///Didziausias skirtingu zydinciu geliu skaicius
int did(int interval[])
{
    int s=0;
    for(int i=1; i<=92; i++)
    {
        if(interval[i]>s)
        {
            s=interval[i];
        }
    }
    return s;
}///Pirmos dienos vieta sarase
int pradzia(int interval[])
{
    for(int i=1; i<=92; i++)
    {
        if(interval[i]==did(interval))
        {
            return i;
        }
    }
}
int pabaiga(int interval[])
{
    for(int i=pradzia(interval); i<=92; i++)
    {
        if(interval[i]<did(interval))
        {
            return i;
        }
    }
}///Rezultatu spausdinimo funkcija
void rezultatai(int interval[])
{
    ofstream fr("U1rez.txt");
    fr << did(interval)<<endl;
    if(pradzia(interval)<31)
    {
        fr << 6 << " " << pradzia(interval)<<endl;
    }
    else if(pradzia(interval)<62 && pradzia(interval)>30)
    {
        fr << 7 << " "<< pradzia(interval)-30<<endl;
    }
    else fr << 8 << " "<<  pradzia(interval)-61<<endl;
    if(pabaiga(interval)<31)
    {
        fr << 6 << " " << pabaiga(interval);
    }
    else if(pabaiga(interval)<62 && pabaiga(interval)>30)
    {
        fr << 7 << " " << pabaiga(interval)-30;
    }
    else fr << 8 << " "<<  pabaiga(interval)-61<<endl;
}
