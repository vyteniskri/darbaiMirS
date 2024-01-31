#include <iostream>
using namespace std;
double KbTr(double x);

int main()
{
    double n=5;

    cout << KbTr(n)<< " " << KbTr(n)*n;


    return 0;
}
double KbTr(double x)
{

    return x*x;
}
