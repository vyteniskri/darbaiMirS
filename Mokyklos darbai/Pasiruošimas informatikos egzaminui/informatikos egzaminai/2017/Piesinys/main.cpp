#include <iostream>
#include <fstream>
using namespace std;
struct spalvos
{
    int x, y, dx, dy, R=255, G=255, B=255;
};
void issiuntimas(int n, spalvos A[], spalvos L[100][100]);
void uzdejimas(spalvos A, spalvos L[100][100]);
int main()
{
    ifstream fd("U2.txt");
    ofstream fr("U2rez.txt");
    int n, didx[100], didy[100], a=0, b=0;
    spalvos A[100], L[100][100];
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].x >> A[i].y >> A[i].dx >> A[i].dy >> A[i].R >> A[i].G >> A[i].B;
        didx[i]=A[i].dx-A[i].x;
        didy[i]=A[i].dy-A[i].y;
        if(didx[i]>b)
        {
            b=didx[i];
        }
        if(didy[i]>a)
        {
            a=didy[i];
        }

    }
    issiuntimas(n, A, L);
    ///Rezultatu spausdinimo funkcija
    fr <<a << " "<< b<<endl;
    for(int i=0; i<a; i++)
    {
            for(int j=0; j<b; j++)
            {
               fr <<  L[i][j].R << " "<< L[i][j].G<< " "<< L[i][j].B<<endl;
            }


    }


}
void issiuntimas(int n, spalvos A[], spalvos L[100][100])
{
    for(int i=0; i<n; i++)
    {
        uzdejimas(A[i], L);
    }
}//Funkcija kuri uzdeda spalvas ant baltu kubeliu
void uzdejimas(spalvos A, spalvos L[100][100])
{
    for(int i=A.y; i<(A.y+A.dy); i++)
    {
        for(int j=A.x; j<(A.x + A.dx); j++)
        {
            L[i][j].R=A.R;
            L[i][j].G=A.G;
            L[i][j].B=A.B;
        }
    }


}

