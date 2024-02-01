#include <iostream>
#include <fstream>
using namespace std;
struct dievas
{
    string vardas;
    int taskai, suma=0, lyg=0;
};
void duomenys(int &n, int &k, dievas A[]);
string valdovas(int n, dievas A[]);

int main()
{
    ofstream fr("U2rez.txt");
    int n, k;
    dievas A[50];
    duomenys(n, k, A);
    ///For ciklas spausdinantis rezultatus
    for(int i=0; i<n; i++)
    {

        if(valdovas(n, A)==A[i].vardas)
        {
            fr << valdovas(n, A)<< " "<<A[i].suma;

        }
    }

} ///Duomenu spausdinimo funkcija
void duomenys(int &n, int &k, dievas A[])
{

    ifstream fd("U2.txt");
    fd >> n >> k>> ws;
    char eil[11];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 11);
        A[i].vardas=eil;

        for(int j=0; j<k; j++)
        {
            fd >> A[j].taskai;
            if(A[j].taskai%2==0)
            {
                A[i].lyg++;
            }
            A[i].suma=A[i].suma+A[j].taskai;
        }
        fd >>ws;

    }
}///Valdovo radinmo funkcija
string valdovas(int n, dievas A[])
{
    int s=0, L;
    string D;
    for(int i=0; i<n; i++)
    {
        if(A[i].suma>s)
        {
            s=A[i].suma;
            D=A[i].vardas;
            L=A[i].lyg;
        }
        else if(A[i].suma==s && A[i].lyg>L)
        {
            s=A[i].suma;
            D=A[i].vardas;
            L=A[i].lyg;
        }
    }
    return D;

}
