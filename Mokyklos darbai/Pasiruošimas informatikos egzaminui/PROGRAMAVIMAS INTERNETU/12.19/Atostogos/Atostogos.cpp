#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int s[], int v[], double vk[], double sk[]);
void rezultatas(int n, int s[], int v[], double vk[], double sk[], double zs[], double kk[]);
int main()
{
    int n, s[100], v[100];
    double vk[100], sk[100];
    double zs[100], kk[100];
    duomenys(n, s, v, vk, sk);
    rezultatas(n, s, v, vk, sk, zs, kk);
}
void duomenys(int &n, int s[], int v[], double vk[], double sk[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n;i++)
    {
        fd >> s[i] >> v[i] >> sk[i] >> vk[i];
    }
}
void rezultatas(int n, int s[], int v[], double vk[], double sk[], double zs[], double kk[])
{
    ofstream fr("Rezultatai.txt");
    for (int i=0; i<n; i++)
    {
        zs[i]= s[i]+ v[i];
        kk[i]=s[i]*sk[i]+v[i]*vk[i];
        fr <<  fixed << setprecision(0)<<zs[i] << " ";
        fr << fixed << setprecision(2)<< kk[i]<<endl;
    }
}
