#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, double &p1, double &p2, double A[]);
double vidurkis(int n, double A[]);
void atitinka(int n, double A[], double B[], int &k, double &vid, double p1, double p2);
void rezultatai(int k, double B[], double vid, int n, double A[]);

int main()
{
    int n, k=0;
    double p1, p2, A[100], B[100], vid;
    duomenys(n, p1, p2, A);
    atitinka(n, A, B, k, vid, p1, p2);
    rezultatai(k, B, vid, n, A);
}
void duomenys(int &n, double &p1, double &p2, double A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> p1 >> p2;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];

    }

}
double vidurkis(int n, double A[])
{
    double s=0;
    for(int i=0; i<n; i++)
    {
        s=s+A[i];
    }
    return s/n;
}
void atitinka(int n, double A[], double B[], int &k, double &vid, double p1, double p2)
{
    double suma=0;
    for(int i=0; i<n; i++)
    {
        if(A[i]>=p1 && A[i]<=p2)
        {
            B[k]=A[i];
            suma=suma+B[k];
            k++;
        }
    }

    vid=suma/k;
}
void rezultatai(int k, double B[], double vid, int n, double A[])
{
    ofstream fr("Rezultatai.txt");
    fr << fixed << setprecision(3) <<vidurkis(n, A)<<endl;
    if(k!=0)
    {
       fr << k<<endl;
    fr << vid<<endl;
    for(int i=0; i<k; i++)
    {
        fr << B[i]<< " ";
    }
    }
    else fr << "nera";


}
