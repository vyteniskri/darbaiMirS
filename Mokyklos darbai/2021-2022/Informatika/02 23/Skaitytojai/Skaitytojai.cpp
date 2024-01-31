#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int A[]);
int suma(int n, int A[]);
double vidutiniskai(int n, int A[]);
void rezultatai(int n, int A[]);
int main()
{
    int n, A[100];
    duomenys(n, A);
    rezultatai(n, A);
}
void duomenys(int &n, int A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i];
    }
}
int suma(int n, int A[])
{
    int sum =0;
    for(int i=0; i<n; i++)
    {
        sum = sum + A[i];
    }
    return sum;
}
double vidutiniskai(int n, int A[])
{
    double vid;
    vid = suma(n, A)/n;
    return vid;
}
void rezultatai(int n, int A[])
{
    cout << suma(n, A)<<endl;
    cout << vidutiniskai(n, A)<<endl;
    cout << fixed << setprecision(1)<< vidutiniskai(n, A)/10;
}
