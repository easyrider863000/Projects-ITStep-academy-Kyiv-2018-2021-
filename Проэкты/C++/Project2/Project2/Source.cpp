#include <iostream>
#include <Windows.h>


using namespace std;

int main()
{
	/*int num2, num1;
	for (int i = 0; i != 2; i++)
	{
		cout << "Enter number --> ";
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
	cout << num1;
	system("pause");*/

	int num;
	cin >> num;
	for (num = num; num < 1;num = int(num / 10))
	{
		cout << num;
	}
	cout << num;
	system("pause");


	/*int num,result;
	cin >> num;
	for (int num1 = num; num1 < 1;)
	{
		cout << num;
		num1 = num1 % 10;
	}
	system("pause");*/

	/*setlocale(0, "");
	int i,result = 0;
	do {
		cout << "enter number --> ";
		cin >> i;
		result += i;
	} while (i != 0);
	cout << result << endl;
	system("pause");*/

	/*setlocale(0, "");
	int i, result = 1;
	do {
		cout << "enter number --> ";
		cin >> i;
		if (i != 0)
		{
			result *= i;
		}

	} while (i != 0);
	cout << result << endl;
	system("pause");*/

	/*int numm,num, i = 0;
	bool f = true;//флаг f для if
	do {
		cin >> num;
		if (f)
		{
			numm = num;
			f = false;
		}
		if (num != 0 &&num > numm)
		{
			numm = num;
		}

	} while (num != 0);
	cout << numm << endl;
	system("pause");*/

	/*int num, result = 0, i = 0;
	double average,num;
	setlocale(0, "");
	cout << "Вычисление среднего арифметического последовательности\nположительных чисел :\nВводите после стрелки числа.Для завершения ввода введите ноль." << endl;
	do {
		cout << "-> ";
		cin >> num;
		if (num != 0)
		{
			i++;
			result += num;
		}

	} while (num!= 0);
	average = result / i;
	cout << "Введено чисел: " << i << endl;
	cout << "Сумма чисел: " << result << endl;
	cout << "Среднее арифметическое : " << average << endl;
	system("pause");*/

	/*setlocale(0, "");
	char sym;
	int kol,line;
	cout << "Введите символ --> ";
	cin >> sym;
	cout << "Введите число символов --> ";
	cin >> kol;
	cout << "1.Линия вертикальная\n2.Линия Горизонтальная\n(Выберите 1 или 2) --> ";
	cin >> line;

	do {
		switch (line)
		{
		case(1):
			cout << sym << endl;
			break;
		case(2):
			cout << sym;
			break;
		default:
			break;
		}
		kol--;
	} while (kol != 0);
	cout << endl;
	system("pause");*/



	/*setlocale(0, "");
	int num,max;
	int f = true;
	cout << "Определение максимального четного числа последовательности\nположительных чисел.\nВводите после стрелки числа.Для завершения ввода введите ноль." << endl;
	do {
		cout << "-> ";
		cin >> num;
		if (f&&num%2 == 0)
		{
			max = num;

			f = false;
		}
		if (num > max&&num % 2 == 0)
		{
			max = num;
		}
	} while (num != 0);
	cout << max << endl;
	system("pause");*/
	
	/*int num, result = 0, i = 0,a = 0;
	setlocale(0, "");
	cout << "Вычисление суммы положительных чисел:\nВводите после стрелки числа.Для завершения ввода введите ноль. " << endl;
	do {
		cout << "-> ";
		cin >> num;
		if (num != 0)
		{

			if (num > 0)
			{
				result += num;
				i++;
			}
			else
			{
				a++;
			}
		}

	} while (num!= 0);
	cout << "Введено чисел: " << a + i << endl;
	cout << "Положительных чисел : " << i << endl;
	cout << "Сумма положительных чисел: " << result << endl;
	system("pause");*/
	

	/*setlocale(0, "");
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
	
	cout <<"Наибольшее отрицательное число : "<<result << endl;
	cout <<"Порядковый номер : "<<kontkol << endl;
	
	system("pause");*/
}