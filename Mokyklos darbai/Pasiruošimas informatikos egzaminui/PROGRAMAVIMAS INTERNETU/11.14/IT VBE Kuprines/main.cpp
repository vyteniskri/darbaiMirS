#include <iostream>
#include <fstream>
using namespace std;
int didziausias(int x, int y);
int keliskartus( int y, int x);
int main()
{
    int x, y;
    ofstream fr ("U1rez.txt");

    fr << didziausias(x, y)<< " "<< keliskartus(y, x);
}
 int didziausias(int x, int y)
 {
    ifstream fd ("U1.txt");
    fd >> x;
     int did=0;
      for (int i = 0; i<x;i++)
    {
        fd >> y;
        if(y>did)
        {
            did=y;
        }


    }

    return did;
}
 int didziausias(int x, int y);
int keliskartus( int y, int x)
{
    int  t=0;
    ifstream fd ("U1.txt");
    fd >> x;

    for (int i =0; i<x; i++)
    {
        fd >> y;

        if (didziausias(x, y)>=y*2)
        {
            t++;
        }


    }
    return t;
}


