#include <iostream>
#include <fstream>
using namespace std;
void kiek(int A[], int B[]);

int main()
{
    ifstream fd("U1.txt");
    ofstream fr("U1rez.txt");
    int A[10], B[20]= {0};
    for(int i=0; i<10; i++)
    {
        fd >> A[i];
        B[i]=A[i];
    }
    kiek(A, B);
    for(int i=0; i<20; i++)
    {
        fr << B[i]<< " ";
    }
}///Funkcija suskaiciuojanti kiek slyvu suvalgys kiekvienas mokinys
void kiek(int A[], int B[])
{
    int sk;
    for(int i=0; i<20; i++)
    {
        if(i<10)
        {
            sk=10-A[i];
        }
        else sk=0;
        for(int j=i+1; j<=sk+i; j++)
        {
            B[j]++;
        }

    }
}
