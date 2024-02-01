#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    int karosai=0, karpiai=0, kuojos=0;
};
void duomenys(int &n, int &d, prad A[]);
int didziausias(int n, prad A[]);
void rezultatai(int n, prad A[]);
int main()
{
    int n, d;
    prad A[100];
    duomenys(n, d, A);
    rezultatai(n, A);
}
void duomenys(int &n, int &d, prad A[])
{
    int karos, karp, kuoj;
    ifstream fd("zvejai_data.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].vardas >> d;
        for(int j=0; j<d; j++)
        {
            fd >> karos >> karp >> kuoj;
            A[i].karosai = A[i].karosai + karos;
            A[i].karpiai = A[i].karpiai + karp;
            A[i].kuojos = A[i].kuojos + kuoj;
        }
    }
    fd.close();
}
int didziausias(int n, prad A[])
{
    int a=0;
    for(int i=0; i<n; i++)
    {

        if(A[i].karosai+A[i].karpiai+A[i].kuojos>a)
        {
            a= A[i].karosai+A[i].karpiai+A[i].kuojos;
        }

    }
    return a;
}
void rezultatai(int n, prad A[])
{
    ofstream fr("zvejai_res.txt");
    for(int i=0; i<n; i++)
    {
        fr << A[i].vardas << " "<< A[i].karosai << " "<< A[i].karpiai << " "<< A[i].kuojos<< endl;

    }
    for(int i=0; i<n; i++)
    {
        if(didziausias(n, A)==A[i].karosai+A[i].karpiai+A[i].kuojos)
        {
            fr << A[i].vardas << " "<< A[i].karosai+A[i].karpiai+A[i].kuojos;
            break;
        }
    }
    fr.close();

}
