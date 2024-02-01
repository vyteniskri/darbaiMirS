#include <iostream>
#include <fstream>
using namespace std;
int isviso(int n, int x[]);
int kiek(int n, int x[]);
int vid(int n, int x[]);
int main()
{
    int n, x[100];

    ifstream fd ("Duomenys.txt");
    ofstream fr ("Rezultatai2.txt");
    fd >> n;
    for(int i=0;i<n; i++)
    {
        fd >> x[i];

    }
    fr << isviso(n, x)<<endl<< kiek(n, x)<<endl<< vid(n, x);
}
 int isviso(int n, int x[])
 {
    int sum =0;
    for(int i=0;i<n; i++)
    {
        sum=sum+x[i];
    }



    return sum;
}
int kiek(int n, int x[])
{
    int y=0;
    for (int i=0; i<n;i++)
    {
        if (x[i]==0)
        {
            y++;
        }
    }
return y;
}
int vid(int n, int x[])
{
   int vid, g=0;
   for(int i=0;i<n;i++)
   {
       if(x[i]>0)

       {
           g++;
       }
   }
    vid=isviso(n, x)/g;

    return vid;
}
