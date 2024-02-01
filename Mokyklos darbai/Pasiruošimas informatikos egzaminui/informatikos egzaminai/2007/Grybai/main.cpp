#include <iostream>
#include <fstream>
using namespace std;
void rezultatai(int b[], int l[], int r[]);
int diena( int b[], int l[], int r[]);
int main()
{
    ifstream fd("U1.txt");
    int n, b[32]= {0}, r[32]= {0}, l[32]= {0};
    int B, R, L, d;
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> d;
        fd >> B >> R >> L;
        ///Priskiriu dienoms grybu skaiciu
        b[d]=b[d]+B;
        r[d]=r[d]+R;
        l[d]=l[d]+L;
    }
    rezultatai(b, l, r);

}///rezultatai spausdinami i faila
void rezultatai(int b[], int l[], int r[])
{
    ofstream fr("U1rez.txt");
    for(int i=0; i<32; i++)
    {
        if(b[i]>0 || l[i]>0 || r[i]>0)
        {
            fr << i << " "<< b[i]<< " "<< r[i]<< " "<< l[i]<<endl;
        }

    }
    for(int i=0; i<32; i++)
    {
        if(diena(b, l, r)==i)
        {
            fr << i << " " <<b[i]+r[i]+l[i];
        }
    }
}///funkcija dienos kuria surinkta daugiausiai grybu rasti
int diena( int b[], int l[], int r[])
{
    int s=0, nr;
    for(int i=0; i<32; i++)
    {
        if(b[i]+r[i]+l[i]>s)
        {
            s=b[i]+r[i]+l[i];
            nr=i;
        }
    }
    return nr;
}
