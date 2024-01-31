#include <iostream>
#include <fstream>
using namespace std;
void sunk (int x, int y, int &a);
void leng(int x, int y, int a, int &k);
int main()
{
    int x, y, a=0, k=0;
ofstream fr("U1rez.txt");
    sunk (x, y, a);
    leng( x, y, a, k);
    fr << a << " "<< k;


}
void sunk (int x, int y, int &a)
{

    ifstream fd ("U1.txt");
    fd >> x;

    for(int i=0; i<x; i++)
    {
        fd >> y;
        if(y>a)
        {
            a=y;
        }
    }

}
void leng(int x, int y, int a, int &k)
{

    ifstream fd ("U1.txt");
    fd >> x;

    for(int i=0; i<x; i++)
    {
        fd >> y;
        if(a>=y*2)
        {
            k++;
        }

    }
}
