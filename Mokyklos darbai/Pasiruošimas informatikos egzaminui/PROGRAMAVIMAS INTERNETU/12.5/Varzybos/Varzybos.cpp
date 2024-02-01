#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int sk[], char lytis[], char sportas[]);
void kiek(int n, char lytis[], char sportas[], int &sum, int &v, int &m, int &sum1, int &v1, int &m1, int &sum2, int &v2, int &m2);
int vidurkis(int n, int sk[], char lytis[], char sportas[], int sum);
void palaikymo(int n, char sportas[], char lytis[], int &s, int &v3, int &m3);
void Rezultatai(int n, char lytis[], char sportas[], int sk[], int sum, int v, int m, int sum1, int v1, int m1, int sum2, int v2, int m2, int s, int v3, int m3 );
int main()
{
    int n, sk[30], sum=0, v=0, m=0, sum1=0, v1=0, m1=0, sum2=0, v2=0, m2=0, s=0, v3=0, m3=0;
    char lytis[30], sportas[30];
    duomenys(n, sk, lytis, sportas);
    kiek(n, lytis, sportas, sum, v, m, sum1, v1, m1, sum2, v2, m2);
    palaikymo(n, sportas, lytis, s, v3, m3);
    Rezultatai(n, lytis, sportas, sk, sum, v, m, sum1, v1, m1, sum2, v2, m2, s, v3, m3);

}
void duomenys(int &n, int sk[], char lytis[], char sportas[])
{
    ifstream fd ("Duomenys.txt");
    fd >> n;

    for(int i=0; i<n;i++)
    {
        fd >> lytis[i] >> sk[i] >> sportas[i];

    }


}
void kiek(int n, char lytis[], char sportas[], int &sum, int &v, int &m, int &sum1, int &v1, int &m1, int &sum2, int &v2, int &m2)
{

    for (int i=0; i<n; i++)
    {
      if ( sportas[i]=='K')
      {
          sum++;
      }


          if(sportas[i]=='K' && lytis[i]== 'V')
        {

            v++;
        }
         if(sportas[i]=='K' && lytis[i]== 'M')
        {

            m++;
        }

       if(sportas[i]=='T')
       {
           sum1++;
       }
       if(sportas[i]=='T' && lytis[i]== 'V')
       {
           v1++;
       }
       if(sportas[i]=='T' && lytis[i]== 'M')
       {
           m1++;
       }

       if(sportas[i]=='F')
       {
           sum2++;
       }
       if(sportas[i]=='F' && lytis[i]== 'V')
       {
           v2++;
       }
       if(sportas[i]=='F' && lytis[i]== 'M')
       {
           m2++;
       }
      }

}
int vidurkis(int n, int sk[], char lytis[], char sportas[], int sum)
{
    int vidur, suma=0;
    for(int i=0; i<n; i++)
    {
        if (sportas[i]=='K')
        {
            suma=suma+sk[i];
        }
    }
    vidur= suma/sum;
    return vidur;

}
void palaikymo(int n, char sportas[], char lytis[], int &s, int &v3, int &m3)
{

    for (int i=0; i<n;i++)
    {
        if (sportas[i]=='S')
        {
            s++;
        }
        if (lytis[i]=='V'&& sportas[i]=='S')
        {
            v3++;
        }
        if(lytis[i]=='M'&& sportas[i]=='S')
        {
            m3++;
        }
    }

}
void Rezultatai(int n, char lytis[], char sportas[], int sk[], int sum, int v, int m, int sum1, int v1, int m1, int sum2, int v2, int m2, int s, int v3, int m3 )
{
    ofstream fr ("Rezultatai.txt");
    fr << sum <<endl;
    if (sum>=7)
    {
        fr << v << " "<< m<<endl;
    }
    else fr << "krepsinio komandos sudaryti negales"<<endl;

    for (int i = 0; i<n; i++)
    {
        if(sum>=7 && sportas[i]=='K')
        {
            fr << lytis[i] << " "<< sk[i]<< " "<< sportas[i]<<endl;
        }

    }
    if (sum>=7)
    {
        fr << vidurkis(n, sk, lytis, sportas, sum)<<endl;
    }
    fr << sum1 << endl;
    if (sum1>=7)
    {
        fr << v1 << " "<< m1 <<endl;
    }
    else fr << "tinklinio komandos sudaryti negales"<<endl;
    for (int i = 0; i<n; i++)
    {
        if(sum1>=7 && sportas[i]=='T')
        {
            fr << lytis[i] << " "<< sk[i]<< " "<< sportas[i]<<endl;
        }

    }
    fr << sum2 << endl;
    if (sum2>=12)
    {
        fr << v2 << " "<< m2<< endl;
    }
    else fr << "futbolo komandos sudaryti negales"<<endl;
    for (int i = 0; i<n; i++)
    {
        if(sum2>=12 && sportas[i]=='F')
        {
            fr << lytis[i] << " "<< sk[i]<< " "<< sportas[i]<<endl;
        }

    }
    fr << s << endl;
    fr << v3 << " "<< m3<<endl;
    for(int i=0; i<n; i++)
    {
        if (sportas[i]=='S')
        {
            fr << lytis[i] << " "<< sk[i]<< " "<< sportas[i]<<endl;
        }
    }
}



