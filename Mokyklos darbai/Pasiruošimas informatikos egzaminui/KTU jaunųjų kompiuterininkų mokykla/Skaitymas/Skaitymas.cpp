#include <iostream>

using namespace std;

int main()
{

    int n, p1, p=0, d=0,pvid;

    cin >> n;

    for (int i=0; i<n; i++)
    {
        cin >>p1;

        p= p+p1;

        if (p1>30) d++;

    }
    pvid=p/n;

    cout << "p = "<<p << " " << "pvid = "<< pvid<< " " << "d = "<< d;
    return 0;
}
