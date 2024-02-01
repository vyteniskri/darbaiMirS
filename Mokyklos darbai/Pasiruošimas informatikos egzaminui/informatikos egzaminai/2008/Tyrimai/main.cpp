#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int m[], int sk[], int teig[], int neig[]);
void didejimo(int m[], int n, int teig[], int neig[], ofstream &fr);
int daugiausiai(int n, int teig[], int m[]);

int main()
{
    ofstream fr("U1rez.txt");
    int m[100], n, sk[100], teig[100]={0}, neig[100]={0};
    duomenys(n, m, sk, teig, neig);
    daugiausiai(n, teig, m);
    didejimo(m, n, teig, neig, fr);
    fr <<endl;
    for(int i=0; i<n; i++)
    {
        fr << setw(6) << teig[i]<< " ";
    }
    fr <<endl;
    for(int i=0; i<n; i++)
    {
        fr << setw(6) << neig[i]<< " ";
    }
    fr <<endl;

    fr << setw(6) <<daugiausiai(n, teig, m);


}
void duomenys(int &n, int m[], int sk[], int teig[], int neig[])
{

    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> m[i] >> sk[i];

    }
    for(int i=0; i<n; i++)
    {
    if(sk[i]>0)
    {
        teig[i]=teig[i]+sk[i];
    }
    else neig[i]=neig[i]+sk[i];
        for(int j=i+1; j<n; j++)
        {
            if(m[i]==m[j] && sk[j]>0)
            {
                teig[i]=teig[i]+sk[j];

                for(int z=j; z<n; z++)
                {
                    m[z]=m[z+1];
                    sk[z]=sk[z+1];
                }
                j--;
                n--;
            }
            else if(m[i]==m[j] && sk[j]<0)
            {
                neig[i]=neig[i]+sk[j];
                for(int z=j; z<n; z++)
                {
                    m[z]=m[z+1];
                    sk[z]=sk[z+1];
                }
                j--;
                n--;
            }
        }
    }
}
void didejimo(int m[], int n, int teig[], int neig[], ofstream &fr)
{

    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(m[i]>m[j])
            {
                swap(m[i], m[j]);
                swap(teig[i], teig[j]);
                swap(neig[i], neig[j]);
            }
        }
    }
    for(int i=0; i<n; i++)
    {
         fr << setw(6)<< m[i]<< " ";
    }

}
int daugiausiai(int n, int teig[], int m[])
{
    int did=0;
    for(int i=0; i<n; i++)
    {
        if(teig[i]>did)
        {
            did=teig[i];
        }


    }
       for(int i=0; i<n; i++)
        {
            if(teig[i]==did)
            {
                return m[i];
            }
        }


}


