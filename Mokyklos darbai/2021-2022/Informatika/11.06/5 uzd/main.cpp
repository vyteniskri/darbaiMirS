#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    int n, k, s, ssum=0, kg =5000, V, ksum=0, v ;

    ifstream fd ("U1.txt");

    fd >> n;

    for (int i=0; i<n; i++)
    {
        fd >> k >> s;

        ksum= ksum + k;



        ssum = ssum + s;






    }
    V = (ksum/n)/100;
    v = (ksum/n)%100;

    cout <<"Pirkinio vid. kaina: "<< V << " eur "<< v << " cnt."<< endl;

    if (ssum<kg)
        {
           cout << "Petriukas gales parnesti pirkinius."<<endl;
        }
    else
        {
       cout << "Petriukas negales parnesti pirkiniu." <<endl;
        }


    return 0;
}
