#include <iostream>
#include <fstream>
using namespace std;
struct studentas
{
    int nr, stojimas[100], istojo[100];
};
void duomenys(int &N, int k[], int &M, int t[], studentas A[], studentas B[]);
int ar(studentas A, studentas B, int t);
void rezultatai(int N, studentas A[], int k[]);

int main()
{
    int N, k[7], M, t[30];
    studentas A[100], B[100];
    duomenys(N, k, M, t, A, B);
    rezultatai(N, A, k);

}
void duomenys(int &N, int k[], int &M, int t[], studentas A[], studentas B[])
{
    int NR[100], p[100];
    ifstream fd("Duomenys.txt");
    fd >> N;
    for(int i=0; i<N; i++)
    {
        fd >> A[i].nr >> k[i];
        for(int j=0; j<k[i]; j++)
        {
            fd >> A[i].stojimas[j];
        }
    }
    fd >> M;
    for(int i=0; i<M; i++)
    {
        fd >> NR[i] >> t[i];
        for(int j=0; j<t[i]; j++)
        {
            fd >> B[i].stojimas[j];
        }
    }
    for(int i=0; i<N; i++)
    {
        for(int j=0; j<k[i]; j++)
        {
            for(int z=0; z<M; z++)
            {
                if(A[i].stojimas[j]==NR[z])
                {
                    A[i].istojo[j]= ar(A[i], B[z], t[z]);
                    if(A[i].istojo[j]!=0)
                    {
                        A[i].istojo[j]=NR[z];
                    }
                    else A[i].istojo[j]=0;
                }
            }

        }
    }

}
int ar(studentas A, studentas B, int t)
{
    for(int i=0; i<t; i++)
    {
        if(A.nr==B.stojimas[i])
        {
            return A.nr;
        }
    }
    return 0;
}
void rezultatai(int N, studentas A[], int k[])
{
    cout << N<<endl;
    for(int i=0; i<N; i++)
    {
        cout << A[i].nr<< " ";
        for(int j=0; j<k[i]; j++)
        {

            if(A[i].istojo[j]!=0)
            {
                cout << A[i].istojo[j]<<endl;
                break;
            }
            else if(A[i].istojo[j]==0)
            {
                cout<< "neistojo"<<endl;
                break;
            }

        }
    }
}
