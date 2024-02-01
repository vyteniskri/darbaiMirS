#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int N[]);
void rezultatai(int n, int N[], int l, int b, int h, int k, double a);
int main()
{
    int n, N[100], l=1, b=0, h=0, k=0;
    double a;
        duomenys(n, N);
        rezultatai(n, N, l, b, h, k, a);
}
void duomenys(int &n, int N[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i =0; i<n; i++)
    {

        fd >> N[i];

    }

}
void rezultatai(int n, int N[], int l, int b, int h, int k, double a)
{
    ofstream fr ("Rezultatai.txt");
    for(int i = 1; i<=10; i++)
    {
         fr << i << " ";
        for(int j=0; j<n; j++ )
        {
            if (N[j]==l)
            {
                b++;

            }
        }
        l++;
         for(int o=0; o<n; o++ )
        {
            if (N[o]==h)
            {
                k++;

            }
        }
        h++;
        a=b-k;

        fr << fixed << setprecision(2)<<a/n*100<<endl;



    }
}
