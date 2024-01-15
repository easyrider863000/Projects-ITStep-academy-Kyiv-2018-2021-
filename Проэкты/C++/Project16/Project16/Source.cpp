#include<iostream>

using namespace std;

int composition(int a, int b)
{
	cout << "composition numbers --> ";
	return a * b;
}

int kolnum(int num)
{
	int tmp;
	for (int i = 1; num >= 1; num /= 10, i++)
	{
		tmp = i;
	}
		return tmp;
}

int max(int a, int b)
{
	cout << "max number --> ";
	if (a >= b)
	{
		return a;
	}
	else
	{
		return b;
	}
}
int main()
{
	/*int a,b;
	cout << "enter number --> ";
	cin >> a;
	cout << "enter number --> ";
	cin >> b;
	cout << composition(a,b) << endl;*/

	/*int num; 
	cin >> num;
	cout << endl << kolnum(num) << endl;*/
	
	/*int a, b;
	cout << "enter number --> ";
	cin >> a;
	cout << "enter number --> ";
	cin >> b;
	cout << max(a, b) << endl;*/
	
	//system("pause");
}