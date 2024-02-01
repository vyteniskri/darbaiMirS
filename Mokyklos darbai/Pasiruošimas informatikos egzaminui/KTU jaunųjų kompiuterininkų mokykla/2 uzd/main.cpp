#include <iostream>

using namespace std;

int main()
{
    int n, s=0, c=0;

    cout << "Iveskite zingsniu kieki iki mokyklos: "; cin >> n;

    for (int i=1; i<=n; i++)
    {
       if ( i % 10==0)
       {
           s++;
       }
       if ( i % 10==5)
       {
           c++;
       }



    }

    cout << "Suplojimu bus: "<<s<<endl;
    cout << "Spragtelejimu bus: "<<c;





    return 0;
}
