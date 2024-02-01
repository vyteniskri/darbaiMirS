#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &n, int &k, int N[]);
void rezultatai(int n, int N[], int &s1, int &l, int &b, int &h, int k);
int main()
{
    int n, k;
    int s1=0, s2=0, s3=0, s4=0, s5=0, l=1, b=0, h=0;
    int N[1000];
    duomenys(n, k, N);
    rezultatai(n, N, s1, l, b, h, k);

}
void duomenys(int &n, int &k, int N[])
{
    ifstream fd("duomenys.txt");
    fd >> n >> k;
    for(int i=0; i<n; i++)
    {
        fd >> N[i];
    }
}
void rezultatai(int n, int N[], int &s1, int &l, int &b, int &h, int k)
{
    ofstream fr ("balsavimo_lentele.txt");
    fr  << "Kandidato nr."<<setw(10)<< "Balsu kiekis."<<endl;

    for(int i=1; i<=k; i++)
    {


        for(int j=0; j<n; j++)
        {

            if (N[j]==l)
            {
                s1++;
            }

        }
        l++;
        for(int j=0; j<n; j++)
        {

            if (N[j]==h)
            {
                b++;
            }

        }
        fr << i << " " << setw(10)<< s1- b <<endl;
        h++;
    }

}








