#include <iostream>
#include <fstream>
using namespace std;
struct info
{
    int lytis, ranka, numeris;
    int vliko=0, mliko=0;

};
void duomenys(int &n, info A[]);
void kiek(int n, info A[], int &mpora, int &vpora, int &mot, int &vyr);
int main()
{
    ofstream fr("U1rez.txt");
    int n, vpora=0, mpora=0, vyr=0, mot=0;
    info A[100];
    duomenys(n, A);
    kiek(n, A, mpora, vpora, mot ,vyr);
    fr << mpora<<endl;
    fr << vpora<<endl;
    fr << mot << endl;
    fr << vyr;
}///Duomenu spausdinimo funkcija
void duomenys(int &n, info A[])
{
    ifstream fd("U1.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].lytis >> A[i].ranka >> A[i].numeris;
    }

}///Radimo funkcija
void kiek(int n, info A[], int &mpora, int &vpora, int &mot, int &vyr)
{
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].lytis==4 && A[i].ranka!=A[j].ranka && A[i].numeris==A[j].numeris)
            {
                mpora++;
                for(int z=j; z<n; z++)
                {
                   A[z]=A[z+1];
                }
                n--;
                j=i+1;
                for(int l=i; l<n; l++)
                {
                    A[l]=A[l+1];
                }
                n--;


            }
        }
    }
    for(int i=0; i<n; i++)
    {
        for(int j=i+1; j<n; j++)
        {
            if(A[i].lytis==3 && A[i].ranka!=A[j].ranka && A[i].numeris==A[j].numeris)
            {
                vpora++;
                for(int z=j; z<n; z++)
                {
                   A[z]=A[z+1];
                }
                n--;
                j=i+1;
                for(int l=i; l<n; l++)
                {
                    A[l]=A[l+1];
                }
                n--;

            }
        }
    }
    for(int i=0; i<n; i++)
    {
        if(A[i].lytis==4)
        {
            mot++;
        }
        else if(A[i].lytis==3)
        {
            vyr++;
        }

    }
}
