#include <iostream>
using namespace std;

int main()
{
	setlocale(0, "");
	double num,result,kontkol;
	bool f = true;
	for (int i = 0; i < 10; i++)
	{
	cin >> num;
	if (f)
	{
	result = num;
	f = false;
	}
	if (num > result&&num < 0)
	{
	kontkol = i+1;
	result = num;
	}
	}

	cout <<"���������� ������������� ����� : "<<result << endl;
	cout <<"���������� ����� : "<<kontkol << endl;

	system("pause");


	/*etlocale(0, "");
	int num2, num1;
	cout << "���������� ����������� ������ ��������." << endl;
	for (int i = 0; i != 2; i++)
	{
		cout << "������� ����� --> ";
		cin >> num1;
		if (i == 0)
		{
			num2 = num1;
		}
		for (num1 = num1; num1 != num2; num2 = num2)
		{
			if (num1 > num2)
			{
				num1 = num1 - num2;
			}
			else
			{
				num2 = num2 - num1;
			}
		}
	}

	cout <<"��� = "<< num1;
	system("pause");*/

}