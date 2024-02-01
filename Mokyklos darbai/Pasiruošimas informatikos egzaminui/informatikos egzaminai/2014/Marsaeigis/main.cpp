#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct komandos /// Struktutu masyvas pradiniams duomenims ir rezultatu duomenims saugoti
{
    int komanda[30], ivykde[30];
    string sakinys;
    int kiek=0;
};
int main()
{
    ifstream fd("U2.txt");
    ofstream fr("U2rez.txt");
    komandos A[10];
    int  x0, y0, x1, y1, n, k, x, y;
    string ar[10];
    fd >> x0 >> y0;
    x=x0;
    y=y0;
    fd >> x1 >> y1;
    fd >> n;
    for(int i=0; i<n; i++)
    {
        fd >> k;

        for(int j=0; j<k; j++)
        {
            fd >> A[i].komanda[j];

            if(x!=x1 || y!=y1)
            {
                A[i].ivykde[j]=A[i].komanda[j];
                A[i].kiek++;
                if(A[i].komanda[j]==1)
                {
                    y++;

                }
                else if(A[i].komanda[j]==2)
                {
                    x++;
                }
                else if(A[i].komanda[j]==3)
                {
                    y--;

                }
                else if(A[i].komanda[j]==4)
                {
                    x--;
                }
            }


        }
        if(x==x1 || y==y0)
        {
            A[i].sakinys="pasiektas tikslas";
        }
        else A[i].sakinys="sekos pabaiga";
        x=x0;
        y=y0;
    }
    for(int i=0; i<n; i++)
    {
        fr << left << setw(21) << A[i].sakinys<<" ";
        for(int j=0; j<A[i].kiek; j++)
        {
            fr << A[i].ivykde[j]<< " ";
        }
        fr << A[i].kiek <<endl;
    }
}

