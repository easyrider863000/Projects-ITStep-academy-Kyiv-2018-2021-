#include<iostream>
using namespace std;

int main()

{
	/*setlocale(0, "");
	int num, result = 1;
	cout << "Введите числа : ";
	do {
		cin >> num;
		if (num != 0 && num > 0)
		{
			result = result * num;
		}




	} while (num != 0);
	cout <<"Результат: "<<result<<"."<<endl;



	system("pause");*/



	
	/*setlocale(0, "");
	int num, pop = 0;
	const int znum = 7;
	cout << "Игра \"Угадай число\".\nКомпьютер \"задумал\" число от 1 до 10. \nУгадайте его за 5 попыток. \nВведите число и нажмите <Enter>" << endl;
	
	
	do {
		cout << "--> ";
		cin >> num;
		if (num == znum)
		{
			cout << "Вы выиграли! Поздравляю! " << endl;
			pop = 5;
		}

		if (num != znum)
		{
			cout << "Нет. " << endl;
			if (pop == 4)
			{
				cout << "Вы проиграли." << endl;
			}
			pop++;
		}

		
	} while (pop < 5);

	system("pause");*/


	/*setlocale(0, "");
	int num, tmp;
	int	count = 0, kolnum = 0;
	do
	{
		cout << "Введите число --> ";
		cin >> num;
		if (num>0)
			count++;
		if (count == 3)
		{
			tmp = num;
			while (tmp>0)
			{
				tmp = tmp / 10;
				kolnum++;
			}
		}
	} while (num != 0);
	cout << "Количество цифр в 3 положительном числе: " << kolnum << endl;
	system("pause");*/

	/*setlocale(0, "");
	int num, sum = 0, otr = 1;
	do{
		cout << "Введите число --> ";
		cin >> num;
		if (num > 0)
		{
			sum += num;
		}
		if (num < 0)
		{
			otr *= num;
		}
	} while (num != 0);
	if (sum > otr)
	{
		cout << "Сумма положительных больше! (" << sum << ')' << endl;
	}
	else
	{
		cout << "Произведение отрицательных больше! (" << otr << ')' << endl;
	}
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


	setlocale(0, "");
	int num2, num1;
	cout << "Нахождение наибольшего общего делителя." << endl;
	for (int i = 0; i != 2; i++)
	{
		cout << "Введите число --> ";
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


	cout << "НОД = " << num1<<endl;
	system("pause");

	/*setlocale(0, "");
	int num,sum = 0,kontsum,outnum,kontnum;
	for (int i = 0; i < 5; i++)
	{
	cout << "Введите число --> ";
	cin >> num;
	kontnum = num;
	for (num = num; num != 0; num /= 10)
	{
	sum += num % 10;
	}
	if (i == 0)
	{
	kontsum = sum;
	outnum = kontnum;
	}
	if (sum > kontsum)
	{
	kontsum = sum;
	outnum = kontnum;
	}
	sum = 0;
	}
	cout <<"Число "<<outnum<<" с найбольшей суммой : "<<kontsum << endl;
	system("pause");*/

}
}