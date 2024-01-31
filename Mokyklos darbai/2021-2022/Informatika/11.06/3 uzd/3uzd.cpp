#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int m, k, vid;
    double sum=0;

    ifstream fd("U1.txt");
    fd >> m;
    for (int i = 0; i < m;i++)
    {
        fd >> k;

        sum = sum +k;



    }
    fd.close();

   vid = sum/m;

    cout << "Is viso: "<< sum <<endl;
    cout << "Vidutiniskai: " << vid;

    return 0;
}
