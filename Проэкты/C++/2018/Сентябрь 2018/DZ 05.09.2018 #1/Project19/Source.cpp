#include<iostream>

using namespace std;

char sravnenie(int a, int b)
{
	if (a > b)
	{
		return '>';
	}
	if (a < b)
	{
		return '<';
	}
	else
	{
		return '=';
	}
}

double Procent(double num, double a)
{
	return num / 100 * a;
}


double Plus(double num1, double num2)
{
	return num1 + num2;
}

double Minus(double num1, double num2)
{
	return num1 - num2;
}

double Multiply(double num1, double num2)
{
	return num1 * num2;
}


double Divide(double num1, double num2)
{
	return num1 / num2;
}



double spwd(double num1, char znak, double num2)
{
	switch (znak)
	{

	case '+':
		return Plus(num1, num2);
	case '-':
		return Minus(num1, num2);
	case '*':
		if (num1 != 0 && num2 != 0)
		{
			return Multiply(num1, num2);
		}
		else
		{
			return 0;
		}
	case '/':
		if (num1 != 0 && num2 != 0)
		{
			return Divide(num1, num2);
		}
		else
		{
			return 0;
		}
	}

}


int main()
{
	/*setlocale(0, "");
	int a, b;
	cout << "¬ведите число --> ";
	cin >> a;
	cout << "¬ведите число --> ";
	cin >> b;
	cout << sravnenie(a, b) << endl;*/

	/*setlocale(0, "");
	double a, b;
	cout << "¬ведите число --> ";
	cin >> a;
	cout << "¬ведите процент --> ";
	cin >> b;
	cout << b << " % от числа " << a << " = " << Procent(a, b) << endl;*/

	/*setlocale(0, "");
	double num1, num2;
	char znak;
	cout << "¬ведите 1-е число --> ";
	cin >> num1;
	cout << "¬ведите 2-е число --> ";
	cin >> num2;
	cout << "¬ведите знак( *, / , + , - ) --> ";
	cin >> znak;

	cout << spwd(num1, znak, num2) << endl;*/



	//system("pause");
}