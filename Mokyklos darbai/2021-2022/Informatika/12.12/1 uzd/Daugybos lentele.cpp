#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
    int n, m;

    cin >> n;
    cin >> m;

    for (int i=1; i<=n; i++)
    {

        cout << setw (5) << i;
        for (int j=2; j<=m; j++)
        {
            cout << setw(5)<< i*j;
        }

        cout << endl;

    }




    return 0;
}
