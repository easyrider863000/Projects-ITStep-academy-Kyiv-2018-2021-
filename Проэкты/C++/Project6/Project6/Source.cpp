#include<iostream>
using namespace std;

int main()

{
	int a, b, c;

	cin >> a;
	cin >> b;
	cin >> c;
	c = a / b;
	for (int i = 0; i < 1000; i++)
	{
		cout << "Hello" << endl;
		if (i == 500)
		{
			c = a / b;
		}
	}
	cout << c << endl;

	setlocale(0,"");
	system("pause");
}