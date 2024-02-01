#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    string vardas;
    double temp[100];
    double vid;
};
void duomenys(int &n, int &m, prad A[]);
double vidur(int m, double temp[]);
void rezultatai(int n, prad A[]);
double Vidurkis(int n, prad A[]);
int main()
{
    int n, m;
    prad A[100];
    duomenys(n, m, A);
    rezultatai(n, A);
}
void duomenys(int &n, int &m, prad A[])
{
    ifstream fd ("Duomenys.txt");
    fd >> n >> m;
    for(int i=0; i<n;i++)
    {
        fd >> A[i].vardas;


        for(int j=0; j<m;j++)
        {
            fd >> A[i].temp[j];

        }
        A[i].vid = vidur(m, A[i].temp[i]);

    }
}
double vidur(int m, double temp[])
{
    double vid, sum=0;
    for(int i=0; i<m; i++)
    {
        sum = sum +temp[i];
    }
    vid=sum/m;
    return vid;
}
double Vidurkis(int n, prad A[])
{
    double vid, sum=0;
    for(int i=0; i<n; i++)
    {
        sum = sum +A[i].vid;
    }
    vid=sum/n;
    return vid;
}
void rezultatai(int n, prad A[])
{
    ofstream fr("Rezultatai.txt");
    for(int i=0; i<n; i++)
    {
        cout << fixed << setprecision (2) << A[i].vardas << " " << A[i].vid << endl;
    }
    cout << Vidurkis(n, A);
}

