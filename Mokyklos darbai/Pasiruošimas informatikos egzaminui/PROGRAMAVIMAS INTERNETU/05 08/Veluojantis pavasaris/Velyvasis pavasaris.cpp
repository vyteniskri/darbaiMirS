#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int &m, int vg[], int vl[], int va[], int bevg[], int bevl[], int beva[]);
int kiek (int s[], int m, int x);
void dienos(int vg[], int vl[],int va[],int bevg[], int bevl[], int beva[], int m, int D[], int n);
int suma(int H[], int n);
void rezultatai(int vg[], int vl[],int va[],int bevg[], int bevl[], int beva[], int D[], int n);

int main()
{
   int n, m;
   int vg[100], vl[100], va[100], bevg[100], bevl[100], beva[100], D[100];
   duomenys(n, m, vg, vl, va, bevg, bevl, beva);
   dienos(vg, vl, va, bevg, bevl, beva, m, D, n);
   rezultatai(vg, vl, va, bevg, bevl, beva, D, n);
}
void duomenys(int &n, int &m, int vg[], int vl[], int va[], int bevg[], int bevl[], int beva[])
{
    int s[100], x;
    ifstream fd("Duomenys.txt");
    fd >> n >> m;
    for(int i=0; i<n; i++)
    {

            for(int j=0; j<m; j++)
            {
                fd >> s[j];
            }
            x=1;
            vg[i]= kiek(s, m, x);
            x=2;
            vl[i]= kiek(s, m, x);
            x=3;
            va[i]= kiek(s, m, x);
            x=4;
            bevg[i]= kiek(s, m, x);
            x=5;
            bevl[i]= kiek(s, m, x);
            x=6;
            beva[i]= kiek(s, m, x);



    }
    fd.close();

}
int kiek (int s[], int m, int x)
{
    int k=0;
    for(int i=0; i<m; i++)
    {
        if(s[i]==x)
        {
            k++;
        }
    }
    return k;
}
void dienos(int vg[], int vl[],int va[],int bevg[], int bevl[], int beva[], int m, int D[], int n)
{
    int l;
    for(int i=0; i<n; i++)
    {
        D[i]= (vg[i]+vl[i]*2+va[i]*3+bevg[i]*4+bevl[i]*5+beva[i]*6)/m;

    }

}
int suma(int H[], int n)
{
    int sum=0;
    for(int i=0; i<n; i++)
    {
        sum=sum+H[i];
    }
    return sum;
}
void rezultatai(int vg[], int vl[],int va[],int bevg[], int bevl[], int beva[], int D[], int n)
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n; i++)
    {
        fr << vg[i]<< " "<< vl[i]<< " "<< va[i]<< " "<< bevg[i]<< " "<< bevl[i]<< " "<< beva[i]<< " " << D[i]<<endl;
    }
    fr << suma(vg, n)<< " "<<suma(vl, n)<< " "<<suma(va, n)<< " "<<suma(bevg, n)<< " "<<suma(bevl, n)<< " "<<suma(beva, n)<< " "<< suma(D, n)/n;

}
