#include <iostream>

using namespace std;

int main()

{
    int b, n, d;

    cout << "kiek zuvu gyvena akvariume? "; cin >> b;
    cout << "kiek zuvu i akvariuma idedama kiekviena diena? "; cin>> d;
    cout << "kiek dienu praejo? "; cin >> n;
    cout << endl <<"Po " <<n<< " dienu akvariume gyevns " << n * d + b << " zuvu" << endl;
    return 0;
}
