#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int A[]);
void rezultatai(int n, int A[]);
int isviso(int n, int A[]);
int nelijo(int n, int A[]);

int main()
{
   int n, A[100];
    duomenys(n, A);
    rezultatai(n, A);

}
void duomenys(int &n, int A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n;
    for(int i=1; i<=n; i++)
    {
        fd >> A[i];
    }
}
int isviso(int n, int A[])
{
    int sum=0;
    for (int i=1; i<=n; i++)
    {
        sum = sum + A[i];
    }
    return sum;
}
int nelijo(int n, int A[])
{
    int a=0;
    for(int i=1; i<=n; i++)
    {
        if(A[i]==0)
        {
            a++;
        }
    }
    return a;
}
int vidutiniskai(int n, int A[])
{
    int b;
    b=isviso(n, A)/(n-nelijo(n, A));
    return b;
}
void rezultatai(int n, int A[])
{
    cout << "Krituliai (lietus)"<<endl;
    cout << "-----------------"<<endl;
    cout << "Diena Krituliu kiekis (mm)"<<endl;
    for(int i=1; i<=n; i++)
    {
        cout << i << " "<< A[i]<<endl;
    }
      cout << "-----------------"<<endl;
    cout << "Isviso iskrito krituliu (mm): "<< isviso(n, A)<<endl;
    cout << "Nelijo (dienas): "<< nelijo(n, A)<<endl;
    cout << "Vidutiniškai kiekvieną lietingą dieną iškrito kritulių (mm): "<< vidutiniskai(n, A);
}
