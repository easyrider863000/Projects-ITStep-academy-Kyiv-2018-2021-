#include<iostream>

using namespace std;

int main()

{


	/*setlocale(0, "");
	int num, step, max = 0, quantity = 1, position;
	cout << "введите число --> ";
	cin >> num;
	do
	{
	step = num % 10;
	if (step>max)
	{
	max = step;
	position = quantity;
	}
	num /= 10;
	quantity++;
	} while (num>0);
	cout << "в веденном числе максимальной цифой является " << max << " , которая стоит на позиции : " <<endl<<"a) "<< position << " c конца  " <<endl<<"b) "<< quantity - position << " c начала"<<endl;*/



	/*setlocale(0, "");
	int num, MAX = 9, max = 9;
	cout << "Введите число --> ";
	cin >> num;
	do
	{
	max = MAX;
	MAX = num % 10;
	num = num / 10;
	} while (num >= 1 && max > MAX);
	if (max > MAX)
	{
	cout << "Упорядоченно по возрастанию" << endl;
	}
	else
	{
	cout << "Не упорядоченно по возрастанию" << endl;
	}
	system("pause");*/



	/*setlocale(0, "");
	double num;
	int i, m, n, result;
	bool f;
	cout << "Введите число --> ";
	cin >> num;
	result = n = m = 1;
	f = 0;

	for (i = 1; i < num; i++)
	{
	n = m;
	m = result;
	result = n + m;
	if (result == num)
	{
	f = 1;
	}
	}
	if (f)
	{
	cout << num << " - это число Фибоначи" << endl;
	}
	else
	{
	cout << num << " - это не число Фибоначи" << endl;
	}
	system("pause");*/
}