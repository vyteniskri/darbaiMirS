#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int suma;
    double vid, s=0;
    int k=-1, d=0;
    ofstream fr ("Rezultatai.txt");
cout << "Ivestike suma: "<<endl;
    while(suma !=0 )
    {
         cin >> suma;
        if ( suma > 100)
        {
            d++;
        }

        s=s+suma;


        k++;
    }
    vid = s/k;
    fr << "1. "<< d<<endl;
    fr << "2. "<< vid<<endl;
    fr << "3. "<< k;

fr.close();

    return 0;
}
