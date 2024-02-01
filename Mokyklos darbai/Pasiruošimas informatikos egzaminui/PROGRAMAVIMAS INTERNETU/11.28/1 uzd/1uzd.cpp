#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void  nuskaityti(int &n, int d[]);
int suma (int n, int d[]);
int daugiaunei(int n, int d[]);
double vidurkis(int n, int d[]);
int main()
{
    int n, d[50];

    nuskaityti(n, d);
    cout <<fixed<<setprecision(1)<< suma(n, d) << endl <<daugiaunei (n, d)<<endl<< vidurkis(n, d);

}

void  nuskaityti(int &n, int d[])
{
    ifstream fd ("muge.txt");
    fd >> n;
    for (int i=0; i<n; i++)
    {
        fd >> d[i];
    }
    fd.close();
}
int suma (int n, int d[])
{
    int sum=0;
    for(int i=0; i<n; i++)
    {
        sum=sum+d[i];
    }
    return sum;
}
int daugiaunei(int n, int d[])
{
    int k=0;
    for(int i=0; i<n; i++)
    {
        if (d[i]>50)
        {
            k++;
        }
    }
    return k;
}
double vidurkis(int n, int d[])
{
    double v;
    double sum=0;
    for(int i=0; i<n; i++)
    {
        sum=sum+d[i];
    }
    v=sum/n;
    return v;
}


