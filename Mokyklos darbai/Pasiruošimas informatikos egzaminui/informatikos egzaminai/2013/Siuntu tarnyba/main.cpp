#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int &m, int &k, int &s, string &sustojo);
int kelias(int x, int y);
void rezultatai(int k, int s, string sustojo);

int main()
{
    int n, m, k=0, s=0;
    string sustojo;
    duomenys(n, m, k, s, sustojo);
    rezultatai(k, s, sustojo);
}///Duomenu spausdinimo funkcija
void duomenys(int &n, int &m, int &k, int &s, string &sustojo)
{
    string pavadinimas;
    int x, y;
    ifstream fd("U1.txt");
    fd >> n >> m >> ws;
    char eil[11];
    for(int i=0; i<n; i++)
    {
        fd.get(eil, 11);
        pavadinimas=eil;
        fd >> x >> y >> ws;
        if(s<=m)
        {
            s=s + kelias(x, y);
            if(s>=m)
               {
                s=s-kelias(x, y);
                break;
               }
            sustojo=pavadinimas; ///Randu paskutinyji miesta
            k++;

        }


    }

}
int kelias(int x, int y)
{
    if(x>=0 && y>=0)
    {
        return 2*(x + y);
    }
    else if(x>=0 && y<0)
    {
        return 2*(x - y);
    }
    else if(x<0 && y>=0)
    {
        return 2*(y - x);
    }
    else if(x<0 && y<0)
    {
        return (x + y)*(-2);
    }


}///Rezultatu spausdinimo funkcija
void rezultatai(int k, int s, string sustojo)
{
    ofstream fr("U1rez.txt");
    fr << k << " "<< s << " "<<sustojo;
}
