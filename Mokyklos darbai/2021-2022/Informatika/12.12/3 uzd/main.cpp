#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int n, k, l;

    ifstream fd ("Duomenys.txt");
    fd >> n >> k;

    for (int i=1; i<=n;i++)
    {
            int sum=0;





         for ( int j=1; j<=k; j++)
        {
            fd >> l;

            sum = sum + l;


        }
        cout << sum<<endl;


    }


    return 0;
}
