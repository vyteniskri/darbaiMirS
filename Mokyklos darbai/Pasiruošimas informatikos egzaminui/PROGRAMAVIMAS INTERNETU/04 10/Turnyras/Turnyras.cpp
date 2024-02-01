#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
struct prad
{
    string pavadinimas;
    int taskai1;
    int taskai2;
};
void duomenys(int &n, prad A[]);
void vidutiniskai(int n, prad A[], double &v, double &suma);

int main()
{
    int n;
    double v, suma=0;
    prad A[100];
    duomenys(n, A);
    vidutiniskai(n, A, v, suma);

        cout << fixed << setprecision(2)<< v<<endl;
        cout << int(suma);

}
void duomenys(int &n, prad A[])
{
    ifstream fd("turnyras_data.txt ");
    fd >>n;
    for(int i=0; i<n; i++)
    {
        fd >> A[i].pavadinimas >> A[i].taskai1 >> A[i].taskai2;
    }

}
void vidutiniskai(int n, prad A[], double &v, double &suma)
{

    for(int i=0; i<n; i++)
    {
        suma= suma + A[i].taskai1;
    }
    v=suma/n;
}
