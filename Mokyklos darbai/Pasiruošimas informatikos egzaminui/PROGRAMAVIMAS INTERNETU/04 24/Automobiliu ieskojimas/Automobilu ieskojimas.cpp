#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    string vardas;
    string marke;
    int kaina;
};
struct BMW
{
    int kaina;
};
struct Audi
{
    int kaina;
};
void duomenys(int &n, prad A[], BMW T[], Audi B[]);
string brangiausia(int n, BMW T[], Audi B[]);
string pigiausia(int n, BMW T[], Audi B[]);
void rezultatai(int n, BMW T[], Audi B[]);
int main()
{
    int n;
   prad A[100];
   BMW T[100];
   Audi B[100];
   duomenys(n, A, T, B);
   rezultatai(n, T, B);

} //Duomenų skausdinimo funkcija
void duomenys(int &n, prad A[], BMW T[], Audi B[])
{
    ifstream fd("auto_data.txt");
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].vardas >> A[i].marke >> A[i].kaina;
        if(A[i].vardas =="BMW")
        {
            T[i].kaina = A[i].kaina;
        }
        else T[i].kaina=0;
        if(A[i].vardas =="Audi")
        {
            B[i].kaina = A[i].kaina;
        }
         else B[i].kaina=0;

    }
} //Randamas brangiausias automobilis
string brangiausia(int n, BMW T[], Audi B[])
{
    int t=0, b=0;
    for(int i=0; i<n; i++)
    {
        if(T[i].kaina>t)
        {
            t=T[i].kaina;
        }
        if(B[i].kaina>b)
        {
            b= B[i].kaina;
        }
    }
    if(t>b)
    {
        return "Tomas";
    }
    else return "Benas";
} // Randamas pigiausias automobilis
string pigiausia(int n, BMW T[], Audi B[])
{
    int t=99, b=99;
    for(int i=0; i<n; i++)
    {
        if(T[i].kaina<t)
        {
            t=T[i].kaina;
        }
        if(B[i].kaina<b)
        {
            b= B[i].kaina;
        }
    }
    if(t<b)
    {
        return "Tomas";
    }
    else return "Benas";
}
void rezultatai(int n, BMW T[], Audi B[])
{
    ofstream fr("auto_res.txt");
    fr << "Brangiausias: "<< brangiausia(n, T, B)<<endl;
    fr << "Pigiausia: "<< pigiausia(n, T, B)<<endl;
    if(brangiausia(n, T, B)=="Tomas" && pigiausia(n, T, B)=="Tomas")
    {
        fr << "Tomas";
    }
    else if(brangiausia(n, T, B)=="Benas" && pigiausia(n, T, B)=="Benas")
    {
        fr << "Benas";
    }
    else fr << "Lygiosios";
}
