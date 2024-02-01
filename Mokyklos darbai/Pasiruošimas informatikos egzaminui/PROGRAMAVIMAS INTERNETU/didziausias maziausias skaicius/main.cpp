#include <iostream>
#include <fstream>
using namespace std;

int main()
{
    int  s1, s2, s3, s4, s5, s6, s7, s8, s9, nr1,  nr2, nr3;
    int sum1, sum2, sum3;



    cin >> nr1 >> s1 >> s2 >> s3;
    cin >> nr2 >> s4 >> s5 >> s6;
    cin >> nr3 >> s7 >> s8 >> s9;

    sum1 = s1 + s2 + s3;
    sum2 = s4 + s5 + s6;
    sum3 = s7 + s8 + s9;


    if (sum1<sum2 && sum1<sum3)
    {
        cout << 1 << " "<<  nr1 << endl;
    }
    else if (sum2<sum1 && sum2 < sum3)
    {
         cout << 1 << " "<<  nr2 << endl;
    }
    else if (sum3<sum1 && sum3 <sum2)
    {
         cout << 1 << " "<<  nr3 << endl;
    }



    if (sum1<sum2 && sum2<sum3)
    {
        cout << 2 << " "<< nr2 <<endl;
    }
    else if (sum3 < sum2 && sum2 < sum1)
    {
        cout << 2 << " "<< nr2 <<endl;
    }
    else if (sum1<sum3 && sum3<sum2)
    {
        cout << 2 << " "<< nr3 <<endl;
    }
    else if (sum2<sum1 && sum1<sum3)
    {
         cout << 2 << " "<< nr1 <<endl;
    }
    else if (sum2<sum3 && sum3<sum1)
    {
        cout << 2 << " "<< nr3 <<endl;
    }
    else if (sum3 < sum1 && sum1 < sum2)
    {
        cout << 2 << " "<< nr1 <<endl;
    }



    if (sum1>sum2 && sum1>sum3)
    {
         cout << 3 << " "<< nr1 <<endl;
    }
    else if (sum2>sum1 && sum2>sum3)
    {
        cout << 3 << " "<< nr2 <<endl;
    }
    else if (sum3>sum1 && sum3 > sum2)
    {
        cout << 3 << " "<< nr3 <<endl;
    }

    return 0;
}
