#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
void duomenys(int &k, double &k1, double &k2, double &k3, double v1[], double v2[], double v3[]);
void kiek(int k, double v1[], double v2[], double v3[], double &sum1, double &sum2, double &sum3);
void vid(int k, double sum1, double sum2, double sum3, double &vid1, double &vid2, double &vid3);
void likovoid(int k, double sum1, double sum2, double sum3, double k1, double k2, double k3, double &liko1, double &liko2, double &liko3);
void kiekkartu(int k, double vid1, double vid2, double vid3, double v1[], double v2[], double v3[], int &suma);
void rezultatai(int k, int suma, double sum1, double sum2, double sum3, double vid1, double vid2, double vid3, double liko1, double liko2, double liko3);
int main()
{
    int k, suma;
    double k1, k2, k3, v1[100], v2[100], v3[100];
    double sum1=0, sum2=0, sum3=0, vid1, vid2, vid3, liko1, liko2, liko3;
    duomenys(k,k1, k2, k3, v1, v2, v3 );
    kiek(k, v1, v2, v3, sum1, sum2, sum3);
    vid(k, sum1, sum2, sum3, vid1, vid2, vid3);
    likovoid(k, sum1, sum2, sum3, k1, k2, k3, liko1, liko2, liko3);
    kiekkartu(k, vid1, vid2, vid3, v1, v2, v3, suma);
    rezultatai(k, suma, sum1, sum2, sum3, vid1, vid2, vid3, liko1, liko2, liko3);
}
 void duomenys(int &k, double &k1, double &k2, double &k3, double v1[], double v2[], double v3[])
 {
     ifstream fd ("Duomenys.txt");
     fd >> k;
     fd >> k1 >> k2 >> k3;
     for (int i=0; i< k; i++)
     {
         fd >> v1[i]>> v2[i] >> v3[i];
     }
 }
 void kiek(int k, double v1[], double v2[], double v3[], double &sum1, double &sum2, double &sum3)
 {

     for (int i=0; i< k; i++)
     {
         sum1=sum1+v1[i];
         sum2=sum2+v2[i];
         sum3=sum3+v3[i];
     }
 }
void vid(int k, double sum1, double sum2, double sum3, double &vid1, double &vid2, double &vid3)
{
   vid1=sum1/k;
   vid2=sum2/k;
   vid3=sum3/k;
}
void likovoid(int k, double sum1, double sum2, double sum3, double k1, double k2, double k3, double &liko1, double &liko2, double &liko3)
{
   liko1=k1-sum1;
   liko2=k2-sum2;
   liko3=k3-sum3;
}
void kiekkartu(int k, double vid1, double vid2, double vid3, double v1[], double v2[], double v3[], int &suma)
{
    int v11=0, v22=0, v33=0;
     for (int i=0; i< k; i++)
     {
         if (v1[i]>vid1)
         {
             v11++;
         }
          if (v2[i]>vid2)
         {
             v22++;
         }
          if (v3[i]>vid3)
         {
             v33++;
         }

     }

     suma = v11+v22+v33;
}
void rezultatai(int k, int suma, double sum1, double sum2, double sum3, double vid1, double vid2, double vid3, double liko1, double liko2, double liko3)
{
    ofstream fr("Rezultatai.txt");

    fr<< fixed << setprecision(2)<<sum1 << " "<< sum2 << " "<< sum3<< endl << vid1 << " "<< vid2 << " "<< vid3<< endl;
    fr << liko1 << " "<< liko2 << " "<< liko3 << endl << suma;
}
