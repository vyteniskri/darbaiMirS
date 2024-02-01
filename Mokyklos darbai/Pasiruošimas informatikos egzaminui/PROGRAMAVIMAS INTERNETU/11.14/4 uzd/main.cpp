#include <iostream>
#include <fstream>
#include <cmath>
#include <iomanip>
using namespace std;
double Krast(double x, double y, double x1, double y1, double x2, double y2);
int main()
{
        int x, y, x1, y1, x2, y2;
ifstream fd("Duomenys.txt");
        fd >> x >> y;
        fd >> x1 >> y1;
        fd >> x2 >> y2;

        fd.close();
    ofstream fr("Rezultatai.txt");
    fr << fixed << setprecision (2) <<Krast(x, y, x1, y1, x2, y2);






    return 0;
}

double Krast(double x, double y, double x1, double y1, double x2, double y2)
{
    double A, B, C, p, P, plotas;


{


        A = floor(sqrt(pow((x-x1),2)+pow((y-y1),2)));
        B = floor(sqrt(pow((x1-x),2)+pow((y1-y),2)));
        C = floor(sqrt(pow((x2-x),2)+pow((y2-y),2)));
        P= A + B + C;

    p=P/2;
    plotas = sqrt(p*(p-A)*(p-B)*(p-C));
}
  return plotas;
}
