#include<iostream>
#include<ctime>
using namespace std;

int main()
{
	/*int arr[10];
	for (int i = 0; i < 10; i++)
	{
		cout << "Enter number -> ";
		cin >> arr[i];
	}
	cout << endl;
	for (int i = 0; i < 10; i++)
	{
		arr[i] = arr[i] * -1;
	}
	for (int i = 0; i < 10; i++)
	{
		cout << arr[i] << endl;
	}*/

	/*int min = 1;
	int max = 10;
	int const size = 10;
	int arr[size];
	int sum = 0;
	int Sum = 0;
	srand(time(0));
	setlocale(0, "");
	for (int i = 0; i < 10; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		if (arr[i] % 2 == 0)
		{
			Sum += arr[i];
		}
		else
		{
			sum += arr[i];
		}
	}
	for (int i = 0; i < 10; i++)
	{
		cout << arr[i] << endl;
	}
	cout << "сума четных = " << Sum << endl;
	cout << "сума нечетных = " << sum << endl;*/





	/*int tmp;
	const int size = 10;
	int arr1[size];
	int arr2[size] = { 0 };
	for (int i = 0; i < size; i++)
	{
		arr1[i] = rand() % 10;
	}
	cout << "Massive --> ";
	for (int i = 0; i < size; i++)
	{
		cout << arr1[i] << " ";
	}
	cout << endl;

	cout << "duplicate values --> ";
	for (int i = 0; i < size; i++)
	{
		tmp = arr1[i];
		for (int j = i + 1; j < size; j++)
		{
			if (arr1[j] == tmp)
			{
				arr2[i] = tmp;
			}
		}
	}
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (arr2[j] == arr2[i])
			{
				arr2[i] = 0;
			}
		}
	}
	for (int j = 0; j < size; j++)
	{
		if (arr2[j] != 0)
		{
			cout << arr2[j] << " ";
		}
	}
	cout << endl;*/



	/*setlocale(0, "");
	int a = 0;
	int max;
	const int size = 10;
	int arr[size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % 10;
	}
	for (int i = 0; i < size; i++)
	{
		if (arr[i] > a)
		{
			a = arr[i] + 1;
		}
	}
	max = a;
	cout << "Массив --> ";
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	for (int i = 0; i < size; i++)
	{
		if (arr[i] < a&&arr[i] % 2 != 0)
		{
			a = arr[i];
		}
	}
	cout << endl;
	if (a == max)
	{
		cout << "В этом массиве нет нечетных чисел" << endl;
	}
	else
	{
		cout << "Самое маленькое нечетное число --> " << a << endl;
	}*/


	/*int const size = 20;
	int min = 0;
	int max = size;
	int arr[size];
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		cout << i << " -> \t" << arr[i] << "\t";
		for (int j = 0; j < arr[i]; j++)
		{
			cout << "*";
		}
		cout << endl;
	}*/

	/*setlocale(0, "");
	int const size = 15;
	int min = 1;
	int max = 5;
	int arr[size];
	int count = 0;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	cout << "Рейтинг:\tЧастота:" << endl;
	for (int i = min; i <= max; i++)
	{
		cout << i << "\t\t";
		count = 0;
		for (int j = 0; j < size; j++)
		{
			if (arr[j] == i)
			{
				count++;
			}
		}
		cout << count << endl;
	}*/


	//system("pause");
}