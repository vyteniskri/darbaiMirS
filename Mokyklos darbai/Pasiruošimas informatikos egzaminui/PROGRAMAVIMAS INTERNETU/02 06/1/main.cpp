#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    char pavadinimas[20];
    int h1, m1, h2, m2;
    int valandu, minuciu, visoh, visom;
};
void duomenys(int &n, prad A[]);
void skaiciavimai(int n, prad A[], prad B[], int &visoh, int &visom);
void rezultatai(int n, prad B[], prad A[], int visoh, int visom);

int main()
{
    int n, visoh=0, visom=0;
    prad A[100], B[100];
    duomenys(n, A);
    skaiciavimai(n, A, B, visoh, visom);
    rezultatai(n, B, A, visoh, visom);
}
void duomenys(int &n, prad A[])
{
    ifstream fd ("Duomenys.txt");
    fd >> n >> ws;
    for(int i=1; i<=n; i++)
    {
        fd.get(A[i].pavadinimas, 20);
        fd >> A[i].h1 >> A[i].m1 >> A[i].h2 >> A[i].m2 >> ws;

    }

}
void skaiciavimai(int n, prad A[], prad B[], int &visoh, int &visom)
{
    for(int i=1; i<=n; i++)
    {
        B[i].h1=A[i].h1*60+A[i].m1;
        B[i].h2=A[i].h2*60+A[i].m2;
        B[i].valandu=(B[i].h2-B[i].h1)/60;
        B[i].minuciu=(B[i].h2-B[i].h1)-B[i].valandu*60;
    }

    for(int i=1;i<=n;i++)
        {
               if(i=1)
            {
                B[i].visoh=(24*60-B[i].h1)/60;
                B[i].visom=(24*60-B[i].h1)-B[i].visoh*60;
            }
             if(i=n)
            {
                B[i].visoh=(B[i].h2)/60;
                B[i].visom=(B[i].h2)-B[i].visoh*60;
            }
            else B[i].visoh=24;


        visoh=visoh+B[i].visoh;
        visom=visom+B[i].visom;
    }




}
void rezultatai(int n, prad B[], prad A[], int visoh, int visom)
{
    ofstream fr("Rezultatai.txt");
    for(int i=1; i<=n; i++)
    {
        cout << fixed << setprecision(2)<< A[i].pavadinimas << B[i].valandu << " " << B[i].minuciu<<endl;

    }
    cout << visoh << " "<< visom;
}
