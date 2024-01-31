#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int n, int B[], string A[], string C[]);
int daug(int B[], int D[]);

int main()
{
   int n, B[6]={0}, D[6]={16, 4, 4, 4, 2, 2};
   string A[1000], C[6]={"p", "b", "z", "r", "v", "k"};
   duomenys(n, B, A, C);
   for(int i=0; i<6;i++)
   {
       cout << C[i]<< " "<< B[i]<<endl;
   }
   cout << daug(B, D)<<endl;
   for(int i=0; i<6; i++)
   {
       cout << C[i]<< " "<< B[i]-(daug(B, D)*D[i])<<endl;
   }
}
void duomenys(int n, int B[], string A[], string C[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
   for(int i=0; i<n; i++)
   {
       fd >> A[i];

   }
   for(int i=0; i<6; i++)
   {
       for(int j=0; j<n; j++)
       {
           if(A[j]==C[i])
           {
               B[i]++;
           }
       }

   }
}
int daug(int B[], int D[])
{
    int s=1000, x;
    for(int i=0; i<6; i++)
    {
        x=B[i]/D[i];
        if(x<s)
        {
            s=x;
        }
    }
    return s;
}
