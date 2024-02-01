#include <iostream>
#include <fstream>
using namespace std;
void Duomenys(int &n, int h[], string vardas[], int &H, int &M, int &s, int &m, bool arfinisavo[]);
void rikiavimas(int n, string vardas[], int h[], bool arfinisavo[]);
void rezultatai(int n, string vardas[], int h[], bool arfinisavo[]);

int main()
{
    int n, h[30], H, M, s, m;
    string vardas[30];
    bool arfinisavo[30];
    Duomenys(n, h, vardas, H, M, s, m, arfinisavo);
    rikiavimas(n, vardas, h, arfinisavo);
    rezultatai(n, vardas, h, arfinisavo);

}
void Duomenys(int &n, int h[], string vardas[], int &H, int &M, int &s, int &m, bool arfinisavo[])
{
    string vardas2;
    ifstream fd ("U2.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> vardas[i] >> H >> M >> s;
        h[i]= H*60*60 + M*60 + s;
        arfinisavo[i]= false;
    }
    fd >> m;
    for(int i=0; i<m; i++)
    {
        fd >> vardas2 >> H >> M >> s;
        for(int j=0; j<n; j++)
        {
            if (vardas2== vardas[j])
            {
                h[j]= H*60*60 + M*60 + s - h[j];

                arfinisavo[j] = true;

            }
        }

    }
}
void rikiavimas(int n, string vardas[], int h[], bool arfinisavo[])
{
    for(int i=0; i<n; i++)
    {
        for(int j=i;j<n; j++)
        {
            if(h[i]>h[j])
            {
                swap(h[i],h[j]);
                swap(vardas[i], vardas[j]);
                swap(arfinisavo[i], arfinisavo[j]);
            }
        }
    }
}
void rezultatai(int n, string vardas[], int h[], bool arfinisavo[])
{
    ofstream fr("U2rez.txt");
    for(int i=0; i<n; i++)
    {
        if(arfinisavo[i])
        fr << vardas[i]<< " "<< h[i]/60%60 << " " << h[i]%60<<endl;
    }
}
