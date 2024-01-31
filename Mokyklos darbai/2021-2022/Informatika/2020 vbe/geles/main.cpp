#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int dienos[]);
int did(int n, int dienos[]);
int kur(int n, int dienos[]);
void rezultatai( int n, int dienos[]);
int main()
{
    int n, dienos[93]={0};
    duomenys(n, dienos);
    rezultatai(n, dienos);

}
void duomenys(int &n, int dienos[])
{
    int prad, pab, m1, m2, d1, d2, nr;
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> nr >> m1 >> d1 >> m2 >> d2;
        if(m1==7)
        {
            prad =30;
        }
        else if (m1 == 8)
        {
            prad =61;
        }
        else prad = 0;

        if(m2==7)
        {
            pab =30;
        }
        else if (m2 == 8)
        {
            pab =61;
        }
        else pab = 0;
        for(int i=prad+d1; i<pab+d2; i++)
        {
            dienos[i]= dienos[i]+1;
        }
}
}
int did(int n, int dienos[])
{
    int ind = 1;
    for(int i=2; i<93; i++)
    {
        if(dienos[i]>dienos[ind])
        {
            ind = i;
        }
    }
    return ind;
}
int kur(int n, int dienos[])
{
    for(int i=did(n, dienos); i<93; i++)
    {
        if(dienos[i]<dienos[did(n, dienos)])
           {
               return i;
           }
    }
}
void rezultatai( int n, int dienos[])
{
    int men;
    cout << dienos[did(n, dienos)]<<endl;
    men = did(n, dienos)/31+6;
    cout << men << " ";
    if(men==6)
    {
        cout << did(n, dienos)<< endl;
    }
    else if(men == 7)
    {
        cout << did(n, dienos)-30<<endl;
    }
    else cout << did(n, dienos) - 61<<endl;

     men = kur(n, dienos)/31+6;
    cout << men << " ";
    if(men==6)
    {
        cout << kur(n, dienos)<< endl;
    }
    else if(men == 7)
    {
        cout << kur(n, dienos)-30<<endl;
    }
    else cout << kur(n, dienos) - 61<<endl;


}
