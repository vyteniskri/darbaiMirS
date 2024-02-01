#include <iostream>

using namespace std;

int main()
{
  int n;
  int p, b, z, r, k, v,p2, p3, p4, b2, b3, b4, z2, z3, z4, r2, r3, r4, k2, k3, k4, v2, v3, v4;
  cin >> n;
  cin >> p >> b>> z>> r>> k>> v;
  cin >> p2 >> b2>> z2>> r2>> k2>> v2;
  cin >> p3 >> b3>> z3>> r3>> k3>> v3;
  cin >> p4 >> b4>> z4>> r4>> k4>> v4;

  int psud, bsud, zsud, rsud, ksud, vsud, T;
  psud = (p+p2+p3+p4)/8;
  bsud = (b+b2+b3+b4)/2;
  zsud = (z+z2+z3+z4)/2;
  rsud = (r+r2+r3+r4)/2;
  ksud = (k+k2+k3+k4);
  vsud = (v+v2+v3+v4);
 if (psud >bsud) T= bsud;
 else T= psud;
 if (psud >zsud) T= zsud;
 else T= psud;
 if (psud >rsud) T= rsud;
 else T= psud;
 if (psud >ksud) T= ksud;
 else T= psud;
 if (psud >vsud) T= vsud;
 else T= psud;

 if (bsud >zsud) T= zsud;
 else T= bsud;
 if (bsud >rsud) T= rsud;
 else T= bsud;
 if (bsud >ksud) T= ksud;
 else T= bsud;
 if (bsud >vsud) T= vsud;
 else T= bsud;

 if (zsud >rsud) T= rsud;
 else T= zsud;
 if (zsud >ksud) T= ksud;
 else T= zsud;
 if (zsud >vsud) T= zsud;
 else T= zsud;

 if (rsud >ksud) T= ksud;
 else T= rsud;
 if (rsud >vsud) T= vsud;
 else T= rsud;

 if (ksud>vsud) T= vsud;
 else T= ksud;
    cout << T;
    return 0;
}
