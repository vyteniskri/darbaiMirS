#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int dienos[93]);
int did(int dienos[]);
int pabaiga(int dientos[]);
void rezultatai(int dienos[]);

int main()
{
    int n, dienos[93]={0};
    duomenys(n, dienos);
    rezultatai(dienos);
}
void duomenys(int &n, int dienos[93])
{
    int nr, m1, d1, m2, d2, prad, pab;
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> nr >> m1 >> d1 >> m2 >> d2;
        if(m1==7)
        {
            prad = 30;
        }
        else if(m1==8)
        {
            prad =61;
        }
        else prad =0;
        if(m2==7)
        {
            pab = 30;
        }
        else if(m2==8)
        {
            pab =61;
        }
        else pab =0;
        for(int i=prad+d1; i<pab+d2; i++)
        {
            dienos[i]=dienos[i]+1;
        }
    }
    fd.close();
}
int did(int dienos[])
{
    int vieta=1;
    for(int i=2; i<93; i++)
    {
        if(dienos[i]>dienos[vieta])
        {
            vieta=i;
        }
    }
    return vieta;
}
int pabaiga(int dienos[])
{
    for(int i=did(dienos); i<93; i++)
    {
        if(dienos[i]<dienos[did(dienos)])
        {
            return i;
        }
    }
}
void rezultatai(int dienos[])
{
    int men;
    cout << dienos[did(dienos)]<<endl;
    men = did(dienos)/31+6;
    cout << men<< " ";
    if(men==6)
    {
        cout <<did(dienos)<<endl;
    }
    else if(men==7)
    {
        cout << did(dienos)-30<<endl;
    }
    else cout << did(dienos)-61<<endl;


    men = pabaiga(dienos)/31+6;
    cout << men<< " ";
    if(men==6)
    {
        cout <<pabaiga(dienos)<<endl;
    }
    else if(men==7)
    {
        cout << pabaiga(dienos)-30<<endl;
    }
    else cout << pabaiga(dienos)-61<<endl;
}
