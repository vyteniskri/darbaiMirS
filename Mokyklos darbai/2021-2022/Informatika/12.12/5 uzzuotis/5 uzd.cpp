#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int n, a1, a2, a3, a4, a5, D, Dp, M, Mp;
    int sum1=0, sum2=0, sum3=0, sum4=0, sum5=0, viso;

    ifstream fd ("duomenys.txt");
    fd >> n;

    for (int i =0; i<n; i++)
    {
        fd >> a1 >> a2 >> a3 >> a4 >> a5;

        sum1 = sum1 + a1;
        sum2 = sum2 + a2;
        sum3 = sum3 + a3;
        sum4 = sum4 + a4;
        sum5 = sum5 + a5;
        viso = sum1 + sum2 + sum3 + sum4 + sum5;
    }
     ;
        D= max(max(sum1, sum2),max(sum3, max(sum4,sum5)));

        Dp = D* 100/viso;

        M = min(min(sum1, sum2),min(sum3, min(sum4,sum5)));

        Mp= M*100/viso;

        cout << Dp << "% pavaru gedimai" <<endl << Mp << "% programines irangos klaidos";
    return 0;
}
