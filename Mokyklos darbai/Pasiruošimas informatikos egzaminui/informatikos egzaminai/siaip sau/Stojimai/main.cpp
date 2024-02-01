#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    int nr, k, pasirinkimai[7], istojo=0;
};
void duomenys(int &N, int &M, prad A[]);
int ar(prad A, int p, int t);
void rezultatai(int N, prad A[]);

int main()
{
    int N, M;
    prad A[100];
    duomenys(N, M, A);
    rezultatai(N, A);
}
void duomenys(int &N, int &M, prad A[])
{
    int NR[10], t[30], P[50][100];
    ifstream fd("U1.txt");
    fd >> N;
    for(int i=0; i<N; i++)
    {
        fd >> A[i].nr >> A[i].k;
        for(int j=0; j<A[i].k; j++)
        {
            fd >> A[i].pasirinkimai[j];
        }
    }
    fd >> M;
    for(int i=0; i<M; i++)
    {
        fd >> NR[i] >> t[i];
        for(int j=0; j<t[i]; j++)
        {
            fd >> P[i][j];
        }

    }
    for(int i=0; i<N; i++)
    {
        for(int j=0; j<A[i].k; j++)
        {
            for(int z=0; z<M; z++)
            {
                if(A[i].pasirinkimai[j]==NR[z])
                {
                    for(int l=0; l<t[z]; l++)
                    {

                        A[i].istojo=ar(A[i], P[z][l], t[z]);
                        if(A[i].istojo==1)
                        {
                            break;
                        }
                    }

                }

                if(A[i].istojo==1)
                {
                    A[i].istojo=NR[z];
                }
            }
            if(A[i].istojo!=0)
            {
                break;
            }
        }
    }
}
int ar(prad A, int P, int t)
{

        if(P==A.nr)
        {
            return 1;
        }

    return 0;
}
void rezultatai(int N, prad A[])
{
    ofstream fr("U2rez.txt");
    cout << N<<endl;
    for(int i=0; i<N; i++)
    {
        cout << A[i].nr << " ";
        if(A[i].istojo==0)
        {
            cout << "neistojo"<<endl;
        }
         else cout << A[i].istojo<<endl;

    }
}
