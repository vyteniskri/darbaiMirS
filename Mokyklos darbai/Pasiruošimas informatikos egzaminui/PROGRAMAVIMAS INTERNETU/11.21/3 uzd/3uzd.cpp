#include <iostream>
#include <fstream>
#include <iomanip>
#include <cmath>
using namespace std;
int  suma(int  n, int   x[]);
int  nelyg(int   n, int   x[]);
int  lyg(int  n, int   x[]);
int  vidkairioji(int  n, int  x[]);
int  viddesinioji(int  n, int x[]);
int main()
{
    int  n, x[500], h;
    double vid1, vid2;


    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd>> h >> x[i];
    }
    fd.close();
    ofstream fr("Rezultatai.txt");

    vid1 = (double)nelyg(n, x)/vidkairioji(n, x);
    vid2 = (double)lyg(n, x)/viddesinioji(n, x);

    fr << suma(n, x)<< endl<< nelyg(n, x)<< endl<< lyg(n,x)<<endl;
    fr << fixed << setprecision(2) <<vid1<< endl<< fixed << setprecision(2)<<vid2;
    fr.close();
}
int  suma(int  n, int   x[])
{
    int sum=0;
    for(int i=0; i<n; i++)
    {
        sum=sum+x[i];
    }



    return sum;
}
int   lyg(int   n, int   x[])
{
   int  isviso=0;
    for(int i=0; i<n; i++)
    {
        if (x[i]%2==0)
        {
            isviso=isviso+x[i];
        }
    }
    return isviso;
}
int   nelyg(int   n, int   x[])
{
    int isviso2=0;
    for(int i=0; i<n; i++)
    {
        if (x[i]%2!=0)
        {
            isviso2=isviso2+x[i];
        }
    }
    return isviso2;
}
int  vidkairioji(int  n, int  x[])
{
    int    l=1;
    for(int i=0; i<n; i++)
    {
        if (x[i]%2!=0)
        {

            l++;
        }
    }

    return l;
}
int  viddesinioji(int  n, int x[])
{

    int  j=-1;
    for(int i=0; i<n; i++)
    {
        if (x[i]%2==0)

        {

            j++;
        }
    }

    return j;
}
