#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string pavadinimas;
    int vyr, mot, did, maz, viso=0;
};
void duomenys(int &s, int &prmetai, int &gmetai, prad A[], int &m, int &D, int &M, string &pav1, string &pav2);
int didziausia(int m, prad A[]);
int maziausias(int m, prad A[]);
int sum(prad A);
int main()
{
    ofstream fr("tyrimai_res.txt");
    int s, prmetai, gmetai, m, D=0, M=99999;
    string pav1, pav2;
    prad A[50];
    duomenys(s, prmetai, gmetai, A, m, D, M, pav1, pav2);
    fr << pav1 << " "<< D<<endl;
    fr << pav2 << " "<< M <<endl;
    for(int i=0; i<=m; i++)
    {
        fr << prmetai++ << " "<< A[i].viso<<endl;
    }

} // Duomenu spausdinimo funkcija
void duomenys(int &s, int &prmetai, int &gmetai, prad A[], int &m, int &D, int &M, string &pav1, string &pav2)
{
    ifstream fd("tyrimai_data.txt");
    fd >> s >> prmetai >> gmetai;
    m=gmetai-prmetai; // Tyrimu metu trukme
    for(int i=0; i<s; i++)
    {
       fd >> A[i].pavadinimas;
       for(int j=0; j<=m;j++)
       {
           fd >> A[j].vyr >> A[j].mot;
           A[j].viso = A[j].viso + sum(A[j]); //Kiekvienu metu asmenu skaicius
       }
       A[i].did = didziausia(m, A); //Didiausias moteru skaicius vienoje srityje
       A[i].maz = maziausias(m, A); //Maziausias vyru skaicius vienoje srityje
       if(A[i].did>D) //Didziausias moteru skaicius is visu sriciu
       {
           D=A[i].did;
           pav1=A[i].pavadinimas;
       }
       if(A[i].maz<=M) //Maziausias vyru skaicius is visu sriciu
       {
          M=A[i].maz;
          pav2=A[i].pavadinimas;
       }

    }


}
int didziausia(int m, prad A[])
{
    int l=0;
    for(int i=0; i<=m; i++)
    {
        if(A[i].mot > l)
        {
            l=A[i].mot;
        }
    }
    return l;
}
int maziausias(int m, prad A[])
{
    int l=99999;
    for(int i=0; i<=m; i++)
    {
        if(A[i].vyr <= l)
        {
            l=A[i].vyr;
        }
    }
    return l;
}
int sum(prad A)
{
    int viso;
    viso= A.vyr + A.mot;
    return viso;
}
