#include<iostream>
#include<time.h>

using namespace std;

int main()
{
	/*setlocale(0, "");
	int max = 5;
	int min = -5;
	int const size = 10;
	int arr[size];
	int tmp;
	cout << "исходный массив\t\t";
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
		cout << arr[i] << " ";
	}
	cout << endl;

	for (int i = 0; i < size / 2; i++)
	{
		tmp = arr[i];
		arr[i] = arr[size - i - 1];
		arr[size - i - 1] = tmp;
	}
	cout << "измененный массив\t";
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;*/




	/*setlocale(0, "");
	int min = 0;
	int max = 10;
	const int size = 10;
	int arr[size];
	srand(time(0));
	cout << "исходный массив\t\t";
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
		cout << arr[i] << " ";
	}
	cout << endl;
	cout << "укажите индекс элемента для удаления -> ";
	int del;
	cin >> del;
	if (del < size&&del >= 0)
	{

		for (int i = 0; i < size; i++)
		{
			if (i == del)
			{
				for (int j = i; j < size; j++)
				{

					arr[j] = arr[j + 1];

				}
			}
		}
		for (int i = 0; i < size; i++)
		{
			if (arr[i] > max || arr[i]<min)
			{
				arr[i] = 0;
			}
		}
		cout << "измененный массив\t";
		for (int i = 0; i < size; i++)
		{
			cout << arr[i] << " ";
		}
	}
	else
	{
		cout << "нет такого индекса в массиве";
	}
	cout << endl;*/




	/*setlocale(0, "");
	const int size = 10;
	int arr[size];
	int index, MAX = 0;
	int min = -9;
	int max = 10;
	srand(time(0));
	cout << "исходный массив\t\t";
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
		cout << arr[i] << " ";
	}
	cout << endl;

	for (int i = 0; i < size; ++i)
	{
		int count = 0;

		for (int j = 0; j < size; ++j)
		{
			if (arr[j] == arr[i])
			{
				count++;
			}
		}
		if (count > MAX)
		{
			MAX = count;
			index = i;
		}
	}

	cout << "чаще всего встречаться элемент " << arr[index] << endl;*/


	/*setlocale(0, "");
	const int size = 10;
	int arr[size];
	int tmp;
	int min = 1;
	int max = 10;
	srand(time(0));
	cout << "исходный массив\t\t";
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
		cout << arr[i] << " ";
	}
	cout << endl;

	int step;
	cout << "укажите шаг сдвига -> ";
	cin >> step;

	for (int i = 0; i < step; i++)
	{
		tmp = arr[size - 1];
		for (int j = size - 1; j > 0; j--)
		{
			arr[j] = arr[j - 1];
		}
		arr[0] = tmp;
	}
	cout << "измененный массив\t";
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;*/


	//system("pause");

}