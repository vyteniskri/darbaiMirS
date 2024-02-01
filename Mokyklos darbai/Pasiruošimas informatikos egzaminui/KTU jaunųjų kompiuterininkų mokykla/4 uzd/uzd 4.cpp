#include <iostream>

using namespace std;

int main()
{
    int n, e, k=0;
    double vid, s=0;

    cout << "Kiek egluciu atvezta? "; cin >> n;

    for(int i=1; i<=n; i++)
    {
        cout << "Iveskite "<< i << " eglutes auksti: "; cin >> e;

        s = s + e;
        k++;



    }

vid= s/k;

cout << "Eglutes aukscio vidurkis: "<< vid << " cm";


    return 0;
}
