#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &s, int &n, int kodas[], int kaina[]);
void atrenka(int s, int n, int kodas[], int kaina[], string TAIP[]);
int kiek(int n, string TAIP[]);
void rezultatai(int s, int n, int kodas[], int kaina[], string TAIP[]);

int main()
{
    int s, n, kodas[100], kaina[100];
    string TAIP[100];
    duomenys(s, n, kodas, kaina);
    atrenka (s, n, kodas, kaina, TAIP);

    rezultatai(s, n, kodas, kaina, TAIP);
}
void duomenys(int &s, int &n, int kodas[], int kaina[])
{
    ifstream fd("Duomenys2.txt");
    fd >> s;
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> kodas[i]>> kaina[i];
    }
}
void atrenka(int s, int n, int kodas[], int kaina[], string TAIP[])
{
    for(int i=0; i<n; i++)
    {
        if(kaina[i]<=s)
        {
            TAIP[i]="TAIP";
        }
        else TAIP[i]="NE";


    }

}
int kiek(int n, string TAIP[])
{
    int k=0;
    for(int i=0; i<n; i++)
    {
        if(TAIP[i]=="TAIP")
        {
            k++;
        }
    }
    return k;
}

void rezultatai(int s, int n, int kodas[], int kaina[], string TAIP[])
{
    ofstream fr ("Rezultatai2.txt");
    for(int i=0; i<n; i++)
    {
        fr << kodas[i]<< " "<< TAIP[i]<<endl;

    }
    fr << "Galima nusipirkti "<< kiek(n, TAIP) << " prekes"<<endl;
    fr << endl;
    fr << "Surikiuotas sarasas"<<endl;
    for(int i=0; i<n; i++)
    {
        for(int j=i; j<n; j++)
        {
            if(kodas[i]>kodas[j])
            {
                swap(kodas[i], kodas[j]);
                swap(TAIP[i], TAIP[j]);
            }
        }
        fr << kodas[i]<< " "<< TAIP[i]<<endl;
    }
}
