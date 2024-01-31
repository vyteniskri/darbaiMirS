#include <iostream>
#include <cmath>
#include <fstream>
#include <iomanip>
using namespace std;

int main()
{
    double a, n;
    ofstream fr ("Reiksmes.txt");
    for (int i = 1; i <= 100; i++)
    {
        fr << i << " "<< sqrt(i)<<endl;;




    }
    fr.close();




    return 0;
}
