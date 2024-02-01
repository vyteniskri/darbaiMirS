#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &k, int &k1, int x[], int y[]);
void trukst( int n[], int k1, int y[], int k, int x[], int s);
void rezultatai(int n[]);
int main()
{
    int k, k1, x[100], y[100];
    int  n[100], s=0;
    duomenys(k, k1, x, y);
    trukst(n, k1, y, k, x, s);
    rezultatai(n);
}
void duomenys(int &k, int &k1, int x[], int y[])
{
    ifstream fd ("Duomenys.txt");
    fd >> k >> k1;
    for (int i=0; i<k; i++)
    {
        fd >> x[i] >> y[i];
    }
}
void trukst(int n[], int k1, int y[], int k, int x[], int s)
{
    for (int i=0; i<=10; i++)
    {

        for(int j=0; j<k; j++)
        {
            if(x[j]==s)
            {
                n[i]=k1-y[j];

                break;
            }
            else n[i]=15;

        }
        s++;




    }

}
void rezultatai(int n[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<=10; i++)
    {

        fr << i << " "<< n[i]<<endl;


    }

}
