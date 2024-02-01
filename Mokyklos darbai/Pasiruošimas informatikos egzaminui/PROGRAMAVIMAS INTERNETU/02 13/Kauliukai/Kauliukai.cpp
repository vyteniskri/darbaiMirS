#include <iostream>
#include <fstream>
using namespace std;
struct prad
{
    char vardas[10];
    int taskai[100];
    int viso;
    int sud;
};
void duomenys(int &n, int &k, prad A[]);
int task(int k, int taskai[]);
int sudetis(int k, int taskai[]);
void rezultatai(int n, int k, prad A[]);
prad didziausias(int n, prad A[]);

int main()
{
    int n, k;
    prad A[100];
    duomenys(n, k, A);
    rezultatai(n, k, A);

}
void duomenys(int &n, int &k, prad A[])
{
    ifstream fd("Duomenys.txt");
    fd >> n >> k>> ws;
    for(int i=0; i<n; i++)
    {
        fd.get(A[i].vardas, 10);
        for(int j=0; j<k; j++)
        {
            fd >> A[i].taskai[j];
        }
        fd >>ws;
        A[i].viso = task(k, A[i].taskai);
        A[i].sud = sudetis(k, A[i].taskai);
    }
}
int sudetis(int k, int taskai[])
{
    int a=0;
    for(int i=0; i<k; i++)
    {
        if(taskai[i]%2==0)
        {
            a++;
        }

    }
    return a;
}
int task(int k, int taskai[])
{
    int sum=0;
    for(int i=0; i<k; i++)
    {
        if(taskai[i]%2==0)
        {
            sum =sum + taskai[i];
        }
        else sum = sum - taskai [i];
    }
    return sum;
}
prad didziausias(int n, prad A[])
{
    prad a;
    a.viso=0;
    a.sud=0;
    for(int i=0; i<n; i++)
    {
        if(A[i].viso>a.viso)
        {
            a=A[i];

        }
        if(A[i].viso=a.viso)
        {
            if(A[i].sud>a.sud)
            {
                a=A[i];
            }

        }
        if(A[i].sud=a.sud)
        {
            if(A[i].vardas<a.vardas)
            {
                a=A[i];
            }

        }

    }

    return a;

}
void rezultatai(int n, int k, prad A[])
{
    prad did = didziausias(n, A);
    ofstream fr("Rezultatai.txt");
    cout << did.vardas << did.viso;


}
