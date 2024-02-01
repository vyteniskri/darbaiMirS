#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas, pavadinimas;
    int kiek, pazymiai;
};
void rikiavimas(int m, prad A[], string vard[], int viso[]);

int main()
{
    ifstream fd("U2.txt");
    string vard[50];
 int m, nr=0;
 prad A[50];
 double sum=0;
 double vidurkis[50];
 int viso[50]={0};
 fd >> m;
 for(int i=0; i<m; i++)
 {
     fd >> A[i].vardas >> A[i].pavadinimas >> A[i].kiek;
     for(int j=0; j<A[i].kiek; j++)
     {
         fd >> A[j].pazymiai;
         sum=sum+A[j].pazymiai;
     }
     vidurkis[i]=sum/A[i].kiek;
     sum=0;

 }
 for(int i=0; i<m; i++)
 {

     for(int j=i; j<m; j++)
     {
         if(A[i].pavadinimas==A[j].pavadinimas && vidurkis[j]>=9)
         {

            vard[j]=A[j].vardas;
             viso[i]++;
             nr++;
         }
     }


 }

 for(int i=0; i<m; i++)
 {
     if(viso[i]==0)
     {
         for(int z=i; z<m; z++)
                {
                    A[z]=A[z+1];
                    viso[z]=viso[z+1];
                    vard[z]=vard[z+1];
                }
                i--;
                m--;
     }
 }

rikiavimas(m, A, vard, viso);
 for(int i=0; i<m; i++)
 {
     cout << A[i].pavadinimas << " "<< viso[i]<<endl;
     for(int j=i; j<m; j++)
     {
         if(A[i].pavadinimas==A[j].pavadinimas)
         {
             cout << vard[j]<<endl;
         }

     }
     for(int j=i+1; j<m; j++)
     {
         if(A[i].pavadinimas==A[j].pavadinimas)
         {
             for(int z=j; z<m; z++)
                {
                    A[z]=A[z+1];
                    viso[z]=viso[z+1];
                    vard[z]=vard[z+1];
                }
                j--;
                m--;
         }
     }
 }


         if(nr==0)
         {
             cout << "Neatitinka vidurkis";
         }



}
void rikiavimas(int m, prad A[], string vard[], int viso[])
{
    for(int i=0; i<m; i++)
    {
        for(int j=i+1; j<m; j++)
        {
            if(viso[i]<viso[j] || viso[i]==viso[j] && A[i].pavadinimas>A[j].pavadinimas)
            {
                swap(viso[i], viso[j]);
                swap(vard[i], vard[j]);
                swap(A[i], A[j]);

            }
        }
    }

}
