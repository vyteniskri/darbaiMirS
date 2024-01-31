#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int n, k, l, sum=0;

    cin >> n;
    cin >> k;

    for(int i=1; i<=n;i++)
    {
        l=pow(i,k);

        sum=sum+l;
    }
    cout << sum;


    return 0;
}
