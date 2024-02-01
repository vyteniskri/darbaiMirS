#include <iostream>
#include <fstream>
using namespace std;
int kiek(int B[]);

int main()
{
    ifstream fd("U1.txt");
    ofstream fr("U1rez.txt");
    int N, B[100]={0}, A[100];
    fd >> N;
    for(int i=0; i<N; i++)
    {

        for(int j=0; j<6; j++)
        {
            fd >> A[j];
            B[j]= B[j]+A[j];
        }

    }
    fr << kiek(B);

}
int kiek(int B[])
{
    int C[6]={8, 2, 2, 2, 1, 1};
    int s=1000;
   for(int i=0; i<6; i++)
   {
        B[i]=B[i]/C[i];
        if(B[i]<s)
        {
            s=B[i];
        }
   }
   return s;
}
