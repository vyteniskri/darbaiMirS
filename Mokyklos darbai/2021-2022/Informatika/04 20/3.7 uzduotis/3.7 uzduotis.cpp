#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int eurai_litai, eurai_centai, suma_centais=0, n=0, A[100];
    cout << "Iveskite pirmos prekes kaina litais ir centais:"<<endl;
    cin >> eurai_litai >> eurai_centai;
    suma_centais = suma_centais + eurai_litai*100 + eurai_centai;
    A[0]=suma_centais;
    cout << "Iveskite kitu prekiu kainas litais ir centais."<<endl;
    cout << "Noredami nutraukti ivedima, iveskite du nulius:"<<endl;
    while(eurai_litai!=0 && eurai_centai!=0)
    {
        n++;
        cin >> eurai_litai >> eurai_centai;
        suma_centais = suma_centais + eurai_litai*100 + eurai_centai;
        A[n]= eurai_litai*100 + eurai_centai;

    }
    cout << A[0]<<" euro ct"<<endl;
    for(int i=1; i<n; i++)
        {
            cout << A[i] << " euro ct"<<endl;
        }
    cout << "Is viso mokesite: "<< suma_centais/100 << " Eur "<< suma_centais%100 << " euro ct"<<endl;
    cout << "Is viso uz pirkinius sumoketa: "<< suma_centais << " euro ct";

}
