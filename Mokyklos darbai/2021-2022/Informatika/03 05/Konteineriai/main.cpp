#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int &g, int b[]);
void skaiciavimas(int n, int g, int b[], int sum[], int &kiek);
int suma(int b[], int g,int n);
void keitimas(int n, int sum[]);
void rezultatai(int g, int sum[], int n, int kiek);
int main()
{
   int n, g, b[100], kiek;
    int sum[100];
    duomenys (n, g, b);
    skaiciavimas(n, g, b, sum, kiek);
    keitimas(n, sum);
    rezultatai(g, sum, n, kiek);

}
void duomenys(int &n, int &g, int b[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> g;
    for(int i=0; i<n; i++)
    {
        fd >> b[i];


    }
}
void skaiciavimas(int n, int g, int b[], int sum[], int &kiek)
{

     for(int i=0; i<n; i++)
    {

    sum[i]= suma(b, g, n);

        for(int j=0;j<n;j++)
        {
            b[j]=b[j]-b[j]/g*g;

        }
    g--;

        kiek=kiek + sum[i];

    }


}
int suma(int b[], int g, int n)
{
    int S=0;
    for(int i=0; i<n; i++)
    {
       S=S+b[i]/g;

    }

    return S;

}
void keitimas(int n, int sum[])
{
    for(int i=0; i<n; i++)
    {

        for(int j=i; j<n; j++)
        {
            if(sum[i]<sum[j])
            {
                swap(sum[i], sum[j]);

            }
        }

    }
}
void rezultatai(int g, int sum[], int n, int kiek)
{

cout << kiek <<endl;
    for(int i=0; i<n; i++)
    {
        cout << sum[i] <<endl;
    }

}
