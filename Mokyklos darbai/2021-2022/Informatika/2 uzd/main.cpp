#include <iostream>

using namespace std;

int main()
{
    int s=0, k=1, m, n;

    cin >> n;
    cin >> m;
    for(int i=n; n<=m; n++)
    {
        if(n%2==0)
        {
            s=s+n;
        }
        else k=k*n;
    }
cout << s << " " << k;

    return 0;
}
