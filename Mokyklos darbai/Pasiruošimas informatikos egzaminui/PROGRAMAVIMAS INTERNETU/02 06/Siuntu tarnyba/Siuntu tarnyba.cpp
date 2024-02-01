#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[10];
    int skaiciai;
};
void duomenys(int &n, int &m, prad A[]);
int atstumas(int x, int y);
void jeigu(int n, int m, prad A[], int &B, int &d,string &pav);
void rezultatai(int n, int B, int d, string pav);
int main()
{
    int n, m, B=0, d=0;
    string pav;
    prad A[100];
    duomenys(n, m, A);
    jeigu(n, m, A, B, d, pav);
    rezultatai(n, B, d, pav);
}
void duomenys(int &n, int &m, prad A[])
{

    ifstream fd("Duomenys.txt");
    fd >> n >> m >> ws;
    int x, y;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 10);
        fd >> x >> y >> ws;
        A[i].skaiciai= atstumas(x, y);

    }
}
int atstumas(int x, int y)
{
    int S;
    if(x>=0 && y>=0)
    {
        S=x+y;
    }
    else if (x>=0 && y<=0)
    {
        S=x+y*(-1);
    }
    else if (x<=0 && y>=0)
    {
        S=x*(-1)+y;
    }
    else S=(x+y)*(-1);
    return 2*S;

}
void jeigu(int n, int m, prad A[], int &B, int &d,string &pav)
{
    for(int i=0; i<n; i++)
    {
        B=B+A[i].skaiciai;
        if(B<m)
        {

            pav=A[i].vardas;

            d++;

        }
        else if(B>m)
        {
            B=B-A[i].skaiciai;
            break;
        }


    }

}
void rezultatai(int n, int B, int d, string pav)
{
    ofstream fr("U1.rez.txt");
    fr << d << " "<< B << " "<< pav;
}
