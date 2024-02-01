#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;
void duomenys(int &p, int &k, int &lank, int k1[], int lank1[]);
int did(int p, int k, int k1[], int lank1[], int b, int h, int n, int f, int a);
int lankytojas(int p, int lank, int lank1[], int h, int b, int n, int f, int a);
void rezultatai(int p, int k, int k1[], int lank1[], int b, int h, int n, int f, int a, int lank);
int main()
{
    int p, k, lank, b=0, h=1, n=0, f=0, a;
    int k1[1000], lank1[1000];
    duomenys(p, k, lank, k1, lank1);
    rezultatai(p, k, k1, lank1, b, h, n, f, a, lank);
}
void duomenys(int &p, int &k, int &lank, int k1[], int lank1[])
{
    ifstream fd ("puslapiu_perziuros.txt");
    fd >> p >> k >> lank;
    for(int i=0; i<p; i++)
    {
        fd >> k1[i]>> lank1[i];
    }

}
int did(int p, int k, int k1[], int lank1[], int b, int h, int n, int f, int a)
{
    int q=0;
    for (int i=0; i<k;i++)
    {

        for(int j=0; j<p;j++)
        {

            if (k1[j]==h)
            {
                b++;
            }

        }

        h++;

        for(int o=0; o<p;o++)
        {
            if (k1[o]==n)
            {
                f++;
            }
        }
        n++;
        a=b-f;
        if (a>q)
        {
                q=a;
        }

    }
    return q;
}
int lankytojas(int p, int lank, int lank1[], int h, int b, int n, int f, int a)
{
    int w=0;
    for (int i =0; i<lank;i++)
    {
        for(int j=0; j<p;j++)
        {
          if (lank1[j]==h)
            {
                b++;
            }
        }


    h++;
    for(int o=0; o<p;o++)
        {
            if (lank1[o]==n)
            {
                f++;
            }
        }
        n++;
        a=b-f;
         if (a>w)
        {
                w=a;
        }
    }

    return w;
}
void rezultatai(int p, int k, int k1[], int lank1[], int b, int h, int n, int f, int a, int lank)
{
    ofstream fr("lankomumo_suvestine.txt");
    fr << "Vienas puslapis daugiausiai perziuretas: "<< did(p, k, k1, lank1, b, h, n, f, a) << " kartus."<< endl;
    fr << "Vienas lankytojas daugiausiai perziurejo: "<< lankytojas(p, lank, lank1, h, b, n, f, a) << " puslapius.";
}




