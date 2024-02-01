#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int a, b, n, d=0, psl=0, x=0;
    ifstream fd ("Duomenys.txt");
    fd >> n >> a >> b;
    while(psl<n)
    {
        psl = psl + a;
        a = a + b;
        d++;
        x++;
    }
    fd.close();
    ofstream fr ("Rezultatai.txt");
    fr << d;




    return 0;
}
