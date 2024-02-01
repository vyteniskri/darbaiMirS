#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int sk[], string spalva[], int &Z, int &R, int &G);
int kiek(int Z, int R, int G);

int main()
{
    ofstream fr("U1rez.txt");
    int n, sk[30], Z=0, R=0, G=0;
    string spalva[30];
    duomenys(n, sk, spalva, Z, R, G);
    cout << kiek(Z, R, G)<<endl;
    cout << "G = "<< G-(2*kiek(Z, R, G))<<endl;
    cout << "Z = "<< Z-(2*kiek(Z, R, G))<<endl;
    cout << "R = "<< R-(2*kiek(Z, R, G))<<endl;
}//Duomenu spausdinimo funkcija
void duomenys(int &n, int sk[], string spalva[], int &Z, int &R, int &G)
{
    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> spalva[i] >> sk[i];
        if(spalva[i]=="Z")
        {
            Z=Z+sk[i];
        }
        else if(spalva[i]=="G")
        {
            G=G+sk[i];
        }
        else R=R+sk[i];

    }



} //velevewliu skaiciaus radimo funkcija
int kiek(int Z, int R, int G)
{

    if(Z<R && Z<G)
    {
        return Z/2;
    }
    else if(R<Z && R<G)
    {
        return R/2;
    }
    else return G/2;
}
