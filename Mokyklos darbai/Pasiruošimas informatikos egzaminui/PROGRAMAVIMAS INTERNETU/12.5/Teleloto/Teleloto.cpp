#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int P[], int L[]);
void kiek(int n, int P[], int L[], int &sum1, int &sum2);
int did(int n, int L[]);
int pirko(int sum1);
void rezultatai(int sum1, int sum2, int n, int L[], int c);
int main()
{
    int n, P[100], L[100];
    int sum1=0, sum2=0, c;
    duomenys(n,P, L);
    kiek(n, P, L, sum1, sum2);
    rezultatai(sum1, sum2, n, L, c);

}
void duomenys(int &n, int P[], int L[])
{
    fstream fd ("Duomenys.txt");
    fd >> n;
    for (int i=0; i<n; i++)
    {
        fd >> P[i]>> L[i];
    }
}
void kiek(int n, int P[], int L[], int &sum1, int &sum2)
{
    for(int i=0; i<n; i++)
    {
        sum1=sum1+P[i];
        sum2=sum2+L[i];
    }
}
int did(int n, int L[])
{
    int a=0;
    for(int i=0; i<n; i++)
    {
        if (L[i]>a)
        {
            a=L[i];
        }
    }
    return a;
}
int pirko(int sum1)
{
    int b;
    b=sum1/2;

    return b;
}
void rezultatai(int sum1, int sum2, int n, int L[], int c)
{
    ofstream fr("Rezultatai.txt");
    fr << sum1 << " Lt "<< sum2 << " Lt"<<endl;
    fr << "Didziausias laimejimas "<< did(n, L)<< " Lt"<<endl;
    fr << "Petras pirko "<< pirko(sum1)<< " bilietus"<<endl;
    c= sum2 - sum1;
    if (c>0)
    {
        fr << "Pelnas "<< c << " Lt";
    }
    else if (c<0)
    {
        fr << "Nuostolis "<< c<< " Lt";
    }
    else if (c=0)
    {
        fr << "Lygiosios";
    }
}

