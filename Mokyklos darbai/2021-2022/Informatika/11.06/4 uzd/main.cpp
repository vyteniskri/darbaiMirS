#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    int n, k, M = 10000, V, sum=0, G;
    ifstream fd ("U1.txt");

    fd >> n;


    for (int i = 0; i<n; i++)
    {
       fd >> k;

       if (k<M)
       {
           M=k;
       }
        sum = sum + k;

    }

    V= sum/n;
    G = V - M;
cout << "Greiciausias begikas: "<< M << " sek."<<endl;
cout << "Jis buvo "<< G << " greitesnis uz vidurki. ";


    return 0;
}
