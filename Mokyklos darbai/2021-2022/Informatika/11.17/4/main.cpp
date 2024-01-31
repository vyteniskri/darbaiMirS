#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;

int main()
{
    int n, N;
    ifstream fd ("Duomenys.txt");
    ofstream fr ("Rezultatai.txt");
    fd >>N;

    for (int i = 0; i<N; i++)
    {
        fd>>n;
        if (n>0)
        {
             fr << n<<endl;
        }

         if (n==0)
        {

            fr << 1 <<endl;
        }
     if (n<0)
        {
            fr <<pow(n,2)<<endl;
        }

    }
    fd.close();


    return 0;
}
