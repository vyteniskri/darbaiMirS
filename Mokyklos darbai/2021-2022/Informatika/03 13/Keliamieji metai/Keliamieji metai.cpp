#include <iostream>

using namespace std;
void skaiciavimas(int n, int m, int &l, int A[]);

int main()
{
    int n, m, l=0, A[100];
    skaiciavimas(n, m, l, A);
    for(int i=0; i<l; i++)
    {
        cout << A[i]<<endl;
    }


}
void skaiciavimas(int n, int m, int &l, int A[])
{
    cin >> m >> n;
    while(m<n)
    {

        if(m%4==0)
        {
            break;
        }
        m++;
    }

    while(m<n)
    {
        A[l]=m;
        m=m+4;
        l++;
    }

}
