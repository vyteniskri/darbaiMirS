#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int n, b, k=0;
    ifstream fd ("U1.txt");
    fd >> n;
    for (int i=0; i<n;i++)
    {
        fd >> b;
        if (b>0)
    {
        cout <<  "Ne"<<endl;
    }
        else
        {
        cout << "Taip";
        }

    }











    return 0;
}
