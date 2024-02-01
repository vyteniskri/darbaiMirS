#include <iostream>
#include <fstream>
using namespace std;
void duomenys(int &n, int bal1[], int bal2[], int bal3[], int &d1, int &d2, int &d3);
void suma(int n, int bal1[], int bal2[], int bal3[], int &s1, int &s2, int &s3);
void taskai(int bal1, int bal2, int bal3, int &a, int &b, int &c);
int did(int t4, int t5, int t6, int d1, int d2, int d3);
void rezultatai(int s1, int s2, int s3, int t1, int t2, int t3, int d1, int d2, int d3, int t4, int t5, int t6);
int main()
{
    int n, bal1[10], bal2[10], bal3[10], a=0, b=0, c=0;
    int  d1, d2, d3, s1=0, s2=0, s3=0, t1=0, t2=0, t3=0, t4, t5, t6;
    duomenys(n, bal1,bal2, bal3, d1, d2, d3);
    suma(n, bal1, bal2, bal3, s1, s2, s3);
    for(int i=0; i<n;i++)
    {
        taskai( bal1[i], bal2[i], bal3[i], a, b, c);
        t1 = t1+a;
        t2= t2+b;
        t3 = t3+c;
    }
    if (t1==t2 && t1==t3){t4=t1+d1; t5=t2+d2; t6=t3+d3;}
    else if (t1==t2 && t1!=t3){t4=t1+d1; t5=t2+d2;}
    else if (t1==t3 && t1!=t2){t4=t1+d1; t6=t3+d3;}
    else if (t2==t3 && t2!=t1){t5=t2+d2; t6=t3+d3;}
   rezultatai(s1, s2, s3, t1, t2, t3, d1, d2, d3, t4, t5, t6);
}
void duomenys(int &n, int bal1[], int bal2[], int bal3[], int &d1, int &d2, int &d3)
{
    ifstream fd ("U1.txt");
    fd >> n;
    for (int i=0; i<n; i++)
    {
        fd >> bal1[i]>> bal2[i]>> bal3[i];
    }
    fd >> d1 >> d2>> d3;

}
void suma(int n, int bal1[], int bal2[], int bal3[], int &s1, int &s2, int &s3)
{
    for (int i=0; i<n; i++)
    {
        s1= s1+bal1[i];
        s2=s2+bal2[i];
        s3= s3+bal3[i];

    }


}
void taskai( int bal1, int bal2, int bal3, int &a, int &b, int &c)
{
    a=0;
    b=0;
    c=0;
    if (bal1>bal2 && bal1>bal3) a=4;
    else if (bal2>bal1 && bal2>bal3) b=4;
    else if (bal3>bal2 && bal3>bal1) c=4;
    else if (bal1==bal2 && bal1!=bal3){a=2; b=2;}
    else if (bal1==bal3 && bal1!=bal2) {a=2; c=2;}
    else if (bal3==bal2 && bal1!=bal3) {c=2; b=2;}
}
int did(int t4, int t5, int t6, int d1, int d2, int d3)
{
    int did;


    if(t4>t5 && t4>t6) did=1;
    else if(t5>t4 && t5>t6) did=2;
    else if(t6>t4 && t6>t5) did=3;



    return did;
}
void rezultatai(int s1, int s2, int s3, int t1, int t2, int t3, int d1, int d2, int d3, int t4, int t5, int t6)
{
    ofstream fr("U1rez.txt");
    fr << s1 << " " << s2<< " "<< s3<<endl;
    fr << t1 << " "<< t2 << " "<< t3<<endl;
    fr << did(t4, t5, t6, d1,  d2, d3);
}
