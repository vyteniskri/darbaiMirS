#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int p[], string sportas[]);
void viso(int n, int p[], string sportas[], int s[], bool ats[]);
void rikiavimas(int n, int p[], int s[], string sportas[], bool ats[]);

void rezultatai(int n, string sportas[], int s[], bool ats[]);

int main()
{
    int n, p[100];
    string sportas[100] ;
    int s[100];
    bool ats[100];
    duomenys(n, p, sportas);
    viso(n, p, sportas, s, ats);
    rikiavimas(n, p, s, sportas, ats);

    rezultatai(n, sportas, s, ats);
}
void duomenys(int &n, int p[], string sportas[])
{
    ifstream fd ("U2.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> sportas[i] >> p[i];

    }

}
void viso(int n, int p[], string sportas[], int s[], bool ats[])
{
    for(int i=0; i<n; i++)
    {
        s[i]=0;
        for(int j=i; j<n; j++)
        {
            if(sportas[i]==sportas[j])
            {
                s[i]=s[i]+ p[j];
                ats[j] = false;
            }





        }



    }

}
void rikiavimas(int n, int p[], int s[], string sportas[], bool ats[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i; j<n; j++)
        {
            if(sportas[i]!=sportas[j] &&s[i]<s[j])
            {
                swap(s[i],s[j]);
                swap(sportas[i], sportas[j]);
                swap (ats[i], ats[j]);
            }
        }

    }
}
void rezultatai(int n, string sportas[], int s[], bool ats[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<n; i++)
    {


    if(ats[i]=true)
    {
         cout << sportas[i] << " "<< s[i]<<endl;

    }




    }
}
