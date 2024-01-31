#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    double did = 0; int a, n, i=0;

    ifstream fd ("U1.txt");



    while (i<100)
    {
            fd >> a;
       if (a>did)
        {
            did=a;
        }
        i++;
    }
    fd.close ();
    cout << "Dizdiausias skaicius "<< did;

 for (int i =0; i<n;i++)
    {
       fd >> a;
        if (a>did)
        {
            did=a;
        }

    }






    return 0;
}
