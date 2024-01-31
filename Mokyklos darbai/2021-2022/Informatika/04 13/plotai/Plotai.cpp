#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[], int B[]);
void skaiciavimas(int n, int A[], int B[], int P[], int &viso, int &m, int &d);

int main()
{
   int n, A[100], B[100], P[100], viso=0, m=99, d=0;
   duomenys(n, A, B);
   skaiciavimas(n, A, B, P, viso, m, d);
   ofstream fr("Rezultatai.txt");
   fr << "Visu klasiu plotai:"<<endl;
   for(int i=0; i<n; i++)
   {
       fr << P[i]<< " ";
   }
   fr << endl;
   fr << "Bendras klasiu plotas: "<< viso<<endl;
   fr << "Didziausias klases plotas "<< d<<endl;
   fr << "Maziausias klases plotas "<< m;
fr.close();
}
void duomenys(int &n, int A[], int B[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i] >> B[i];
    }
    fd.close();
}
void skaiciavimas(int n, int A[], int B[], int P[], int &viso, int &m, int &d)
{
    for(int i=0; i<n; i++)
    {
        P[i]=A[i]*B[i];
        viso =viso+P[i];
        if(P[i]<m)
        {
            m=P[i];
        }
        if(P[i]>d)
        {
            d=P[i];
        }
    }
}
