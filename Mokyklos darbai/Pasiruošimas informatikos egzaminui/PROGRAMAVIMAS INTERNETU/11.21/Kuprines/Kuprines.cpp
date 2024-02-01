#include <iostream>
#include <fstream>
using namespace std;
int sunk(int n, int a[]);
 int lengvesnes(int n, int a[]);
int main()
{
    int n;
    int a[100];
    ifstream fd ("Duomenys.txt");
    fd >>n;
    ofstream fr ("Rezultatai.txt");
    for(int i=0; i<n;i++)
    {
        fd >> a[i];
    }

    fr << sunk(n, a) << " "<< lengvesnes(n, a);
}
int sunk(int n, int a[])
{
    int did=0;

    for (int i=0;i<n;i++)
    {

        if (a[i]>did)
        {
            did=a[i];
        }

    }
    return did;
}

 int lengvesnes(int n, int a[])
 {
    int x=0;

    for (int i=0; i<n;i++)
    {
        if (sunk(n, a)>=a[i]*2)
        {
            x++;
        }

    }



    return x;
}
