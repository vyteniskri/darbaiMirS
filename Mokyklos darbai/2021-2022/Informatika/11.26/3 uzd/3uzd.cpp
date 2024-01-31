#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int n, x;
    int sum=0 , k= -1, liks;
    ofstream fr("Rezultatai.txt");

    cout << "Petriukas gavo saldainiu "; cin >> n;

    while(sum<n)
    {
       cout << "Per diena suvalge "; cin >>x;
       sum=sum+x;
       k++;
    }
    liks = n - (sum-x);
    fr << "Petriukui saldainiu uzteks "<< k << " dienoms ir jam liks "<< liks << " saldainiai";

fr.close();

    return 0;
}
