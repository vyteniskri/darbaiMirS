#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &x, int &sk, int &sunk, int &kiek);
void sunkiausia(int sk, int &sunk);
void kieksunk(int sk, int sunk, int &kiek);

int main()
{
    ofstream fr("U1rez.txt");
    int x, sunk=0, sk, kiek=0;
    duomenys(x, sk, sunk, kiek);
    sunkiausia(sk, sunk);
    kieksunk(sk, sunk, kiek);
    fr << sunk << " "<< kiek;

}///Duomenu spausdinimo funkcija
void duomenys(int &x, int &sk, int &sunk, int &kiek)
{

    ifstream fd("U1.txt");
    fd >> x;
    for(int i=0; i<x; i++)
    {
        fd >> sk;
        sunkiausia(sk, sunk);
        kieksunk(sk, sunk, kiek);

    }
}///Sunkiausios kuprines ieskojimo funkcija
void sunkiausia(int sk, int &sunk)
{
    if(sk>sunk)
    {
        sunk=sk;

    }
}///Kiek kupriniu lengvesnius uz sunkiausia 2 ir daugiau kartu
void kieksunk(int sk, int sunk, int &kiek)
{

    if(sk*2<=10000)
    {
        kiek++;

    }
}
