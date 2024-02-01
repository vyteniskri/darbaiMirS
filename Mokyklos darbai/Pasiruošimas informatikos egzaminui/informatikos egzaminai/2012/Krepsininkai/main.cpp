#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int &k, int &t, int laikas[], int s[], int &neigiam, int &d, int &nr1, int &nr2);
void did(int teigiam, int &d, int &nr2, int k);
void rezultatai(int s[], int neigiam, int nr1, int nr2, int d, int n);
void rikiavimas(int n, int s[]);
int main()
{
   int n, k, t, d=0, nr1, nr2;
   int laikas[40], s[40]={0}, neigiam=0;
   duomenys(n, k, t, laikas, s, neigiam, d, nr1, nr2);
   rikiavimas(n, s);
   rezultatai(s, neigiam, nr1, nr2, d, n);

}///Duomenu spausdinimo funkcija
void duomenys(int &n, int &k, int &t, int laikas[], int s[], int &neigiam, int &d, int &nr1, int &nr2)
{
    int m, teigiam=0;
    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> k >> t;

        for(int j=0; j<t; j++)
        {
            fd >> laikas[j];
            if(j==0 && laikas[j]>0)
            {
                s[i]=k;
            }
            if(laikas[j]>0)
            {
               teigiam=teigiam+laikas[j];
            }
            else if(laikas[j]<0)
            {
               m=m+laikas[j];
            }
        }


        did(teigiam, d, nr2, k);
        if(m*(-1)>neigiam)
        {
            neigiam=m*(-1);
            nr1=k;
        }
        else if(m==neigiam && k>nr1)
        {
            neigiam=m*(-1);
            nr1=k;
        }

        teigiam=0;
        m=0;

    }
}
void did(int teigiam, int &d, int &nr2, int k)
{

    if(teigiam>d)
    {
        d=teigiam;
        nr2=k;
    }
    else if(d==teigiam && k>nr2)
    {
        d=teigiam;
        nr2=k;
    }
}///Rikiavinmo funkcija
void rikiavimas(int n, int s[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(s[i]>s[j] && s[i]!=0 && s[j]!=0)
            {
                swap(s[i], s[j]);
            }
        }
    }
} ///Rezultatu spausdinimo funkcija
void rezultatai(int s[], int neigiam, int nr1, int nr2, int d, int n)
{
    ofstream fr("U1rez.txt");

        for(int i=0; i<n; i++)
        {
            if(s[i]!=0)
            {
                cout << s[i]<<" ";
            }

        }
        cout <<endl;
        cout << nr2 << " "<< d<<endl;
        cout << nr1 << " " << neigiam;

}
