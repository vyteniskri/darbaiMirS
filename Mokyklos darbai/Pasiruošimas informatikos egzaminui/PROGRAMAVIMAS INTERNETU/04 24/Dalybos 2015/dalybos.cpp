#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    int slyvos;
    int liko;
};
void duomenys(prad A[]);
void skaiciavimas(prad A[]);
void rezultatai(prad A[]);

int main()
{
    prad A[100];
    duomenys(A);
    skaiciavimas(A);
    rezultatai(A);
}
void duomenys(prad A[])
{
    ifstream fd("U1.txt");
    for(int i=0; i<20; i++)
    {
        fd >> A[i].slyvos;
        A[i].liko=10-A[i].slyvos;
        if(i>=10)
        {
            A[i].slyvos=0;
            A[i].liko=0;
        }

    }
    fd.close();
}
void skaiciavimas(prad A[])
{
    for(int i=0; i<20; i++)
    {
        for(int j=i+1; j<=20; j++)
        {

            if(A[i].liko>0)
            {
                A[j].slyvos++;
                A[i].liko--;
            }



        }


    }
}
void rezultatai(prad A[])
{
    ofstream fr("U1rez.txt");
    for(int i=0; i<20; i++)
    {
        fr << A[i].slyvos<< " ";
    }
    fr.close();
}
