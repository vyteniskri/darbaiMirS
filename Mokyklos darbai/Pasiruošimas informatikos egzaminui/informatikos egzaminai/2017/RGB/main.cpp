#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &a, int &b, int A[], string B[]);
string kodas(int A);

int main()
{

    int a, b, A[10000];
    int x=0;
    string B[10000];
    duomenys(a, b, A, B);
    for(int i=0; i<a; i++)
    {
        for(int j=0; j<b; j++)
        {
            if(j!=b-1)
            {
               cout << B[x]<< ";";
            }
            else cout << B[x];
            x++;
        }
        cout <<endl;

    }

}//duomenu spausdinimo funkcija
void duomenys(int &a, int &b, int A[], string B[])
{
    string h="";
    ifstream fd("U1.txt");
    fd >> a >> b;
    for(int i=0; i<a*b; i++)
    {
        for(int j=0; j<b; j++)
        {
            fd >> A[j];
            h= h+kodas(A[j]);

        }
    B[i]=h;
    h="";



    }
}//Funkcija konvertuojanti dessimtaini skaiciu i sesioliktaini
string kodas(int A)
{
    string mas[16]={"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F"};

    return mas[A/16]+mas[A%16];
}
