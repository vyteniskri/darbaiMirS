#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    int taskai = 0;
    string zuvis[100];
    string zuvis1;
    int svoris[100];
    int kiek;
};
void duomenys(int &n, int &k, prad A[], prad B[]);
void rikiavimas(int l, prad K[]);
void rezultatai(int n, int k, prad A[], prad B[]);
int main()
{
   int n, k;
    prad A[30], B[30];
    duomenys(n, k, A, B);
    rikiavimas(n, A);
    rikiavimas(k, B);
    rezultatai(n, k, A, B);

}
void duomenys(int &n, int &k, prad A[], prad B[])
{
    int t;
    char eil[21];
    ifstream fd("U2.txt");
    fd >> n>>ws;
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 21);
        A[i].vardas= eil;
        fd >> A[i].kiek >>ws;

        for(int j=0; j<A[i].kiek; j++)
        {
            fd.get(eil,21);
            A[i].zuvis[j]=eil;
            fd >> A[i].svoris[j] >> ws;
            if(A[i].svoris[j]>=200)
            {
                A[i].taskai=A[i].taskai+30;
            }
            else if(A[i].svoris[j]<200)
            {
                A[i].taskai=A[i].taskai+10;
            }

        }
        fd >> ws;

    }
    fd >> k >> ws;
    for(int i=0; i<k; i++)
    {

        B[i].taskai={0};

        fd.get(eil, 21);
           B[i].vardas = eil;
           fd >> t >>ws;

           for(int j=0; j<n; j++)
           {
               for(int z=0; z<A[j].kiek; z++)
               {
                    if(B[i].vardas==A[j].zuvis[z])
                    {
                        A[j].taskai= A[j].taskai +t;
                        B[i].taskai = B[i].taskai + A[j].svoris[z];

                    }
               }

           }
    }

}
void rikiavimas(int l, prad K[])
{
    for(int i=0; i<l; i++)
    {
        for(int j=i; j<l; j++)
        {
            if(K[i].taskai<K[j].taskai || K[i].taskai == K[j].taskai && K[i].vardas>K[j].vardas)
            {
                swap(K[i],K[j]);
            }
        }
    }
}
void rezultatai(int n, int k, prad A[], prad B[])
{
    ofstream fr("U2rez.txt");
    cout << "Dalyviai"<<endl;
    for(int i=0; i<n; i++)
    {
        cout << A[i].vardas << " "<< A[i].taskai<<endl;
    }
    cout << "Laimikis"<<endl;
    for(int i=0; i<k; i++)
    {
        cout << B[i].vardas << " "<< B[i].taskai <<endl;
    }
}
