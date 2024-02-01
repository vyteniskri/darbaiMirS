#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int v[], int m[]);
void pusvalandis(int val1[], int val2[], int min1[], int min2[]);
int kiekpirk(int n, int v[], int m[], int val1, int min1, int val2, int min2);
void rezultatai(int n, int v[], int val1[], int val2[], int min1[], int min2[], int m[]);
int main()
{
   int val1[24]={0}, val2[24]={0}, min1[24]={0}, min2[24]={0};
   int v[100], m[100];
   int n;
   duomenys(n, v, m);
   pusvalandis(val1, val2, min1, min2);
    rezultatai(n, v, val1, val2, min1, min2, m);
}
void duomenys(int &n, int v[], int m[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> v[i] >> m[i];
    }
    fd.close();
}
void pusvalandis(int val1[], int val2[], int min1[], int min2[])
{
    val1[0]=8;
    min1[0]=0;
    val2[0]=8;
    min2[0]=30;
    for(int i=1; i<24; i++)
    {
        if(min1[i-1]==30)
        {
            val1[i] = val1[i-1]+1;
        }
        else val1[i] = val1[i-1];
         if(min1[i-1]==0)
        {
            min1[i] = 30;
        }
        else min1[i]=0;
        if(min2[i-1]==30)
        {
            val2[i] = val2[i-1]+1;
        }
        else val2[i] = val2[i-1];
         if(min2[i-1]==0)
        {
            min2[i] = 30;
        }
        else min2[i]=0;

    }

}
int kiekpirk(int n, int v[], int m[], int val1, int min1, int val2, int min2)
{
    int k=0;
    for(int i=0; i<n; i++)
    {
        if(val1*60+min1<=v[i]*60+m[i] && v[i]*60+m[i]<val2*60+min2)
        {
           k++;
        }
    }
    return k;
}
void rezultatai(int n, int v[], int val1[], int val2[], int min1[], int min2[], int m[])
{
    for(int i=0; i<24; i++)
    {
        cout << val1[i] << " "<< min1[i] << " "<< val2[i]<< " "<< min2[i]<< " ";
        cout << kiekpirk(n, v, m, val1[i], min1[i], val2[i], min2[i])<<endl;
    }
}
