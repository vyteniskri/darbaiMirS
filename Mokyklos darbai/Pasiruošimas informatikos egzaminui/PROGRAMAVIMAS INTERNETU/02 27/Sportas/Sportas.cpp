#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[20];
    int nr;
    int laikas;
};
void duomenys(int &n, int &me, prad A[], prad V[], prad M[], int &mm, int &vv);
void keitimas(int kiek, prad K[], prad A[]);
void rezultatai(int kiek, prad K[], string lyt, int n, prad A[], ofstream &fr);
int main()
{
    int n, me;
    int mm=0, vv=0;
    ofstream fr("Rezultatai.txt");
    prad A[100], V[100], M[100];
    duomenys(n, me, A, V, M, mm, vv);
    keitimas(mm, M, A);
    keitimas(vv, V, A);
    rezultatai(mm, M, "Merginos", n, A, fr);
    rezultatai(vv, V, "Vaikinai", n, A, fr);
}
void duomenys(int &n, int &me, prad A[], prad V[], prad M[], int &mm, int &vv)
{
    int H, mi, S;
    int nr, H1, M1, S1, b1, b2, b3, b4;
    ifstream fd("Duomenys.txt");
    fd >> n >> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 20);
        fd >> A[i].nr >> H >> mi >> S >> ws;
        A[i].laikas = H*3600+mi*60+S;
    }
    fd >> me;
    for(int i=0; i<me; i++)
    {
        fd >> nr;
        if(nr < 200)
        {
            fd >>  H1 >> M1 >> S1 >> b1 >> b2;
            for(int j=0; j<n; j++)
            {
                if(nr == A[j].nr)
                {
                    M[mm]. laikas = (H1*3600+M1*60+S1+(5-b1)*60+(5-b2)*60)-A[j].laikas;
                }
            }
            M[mm].nr=nr;
            mm++;
        }
        else
        {
            fd >>  H1 >> M1 >> S1 >> b1 >> b2 >> b3 >> b4;

            for(int j=0; j<n; j++)
            {
                if(nr == A[j].nr)
                {
                    V[vv]. laikas = (H1*3600+M1*60+S1+(5-b1)*60+(5-b2)*60+(5-b3)*60+(5-b4)*60)-A[j].laikas;
                }
            }
            V[vv].nr=nr;

            vv++;
        }

    }

}
void keitimas(int kiek, prad K[], prad A[])
{
    for(int i=0; i<kiek; i++)
    {

        for(int j=i; j<kiek; j++)
        {
            if(K[i].laikas>K[j].laikas)
            {
                swap(K[i].laikas, K[j].laikas);
                swap(K[i].nr, K[j].nr);
            }
        }
    }
}
void rezultatai(int kiek, prad K[], string lyt, int n, prad A[], ofstream &fr)
{

    fr << lyt << endl;
    for(int i=0; i<kiek; i++)
    {
        fr << K[i].nr << " ";
        for(int j=0; j<n; j++)
        {
            if(K[i].nr == A[j].nr)
            {
                fr << A[j].vardas<< " ";
            }
        }
        if(K[i].laikas/60<60)
        {
            fr << K[i].laikas/3600 << " "<< K[i].laikas/60 << " "<< K[i].laikas - (K[i].laikas/60*60)<<endl;
        }
        else fr << K[i].laikas/3600 << " "<< K[i].laikas/60-60 << " "<< K[i].laikas - (K[i].laikas/60*60)<<endl;
    }
}
