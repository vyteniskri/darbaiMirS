#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;
double kiekreikes (double x, double y, double sx, double sy);
int main()
{
    double x, y, sx, sy;
    ifstream fd ("Duomenys.txt");
    fd >> x >> y >> sx >> sy;
    fd.close();
    ofstream fr ("Rezultatas.txt");
        fr <<  kiekreikes (x,y,sx,sy);

    return 0;
}



 double kiekreikes (double x, double y, double sx, double sy)
{
   double ilgis, plotis, ats;
    ilgis = ceil(sx/(x/100));
    plotis = ceil (sy/(y/100));
    ats = ilgis * plotis;



 return ats;
}
