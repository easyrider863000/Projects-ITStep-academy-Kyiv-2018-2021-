#include<iostream>
using namespace std;
int main()
{
	/*setlocale(0, "");
	int arr[10];
	int n = 0;
	int i = 0;
	while( i < 10)
	{
		if (n % 2 != 0)
		{
			arr[i] = n;
			i++;
		}
		n++;
	}
	for (int j = 0; j < 10; j++)
	{
		cout<<j<<" -> " << arr[j] << endl;
	}*/


	/*int const size = 10;
	int arr1[size];
	int arr2[size];

	for (int i = 0; i < size; i++)
	{
		cout << "Enter number --> ";
		cin >> arr1[i];
	}
	cout << endl;
	
	for (int j = 0; j < size; j++)
	{
		arr2[j] = arr1[size - 1 - j];
	}

	for (int x = 0; x < size; x++)
	{
		cout << arr2[x]<<" ";
	}
	cout << endl;*/

	/*setlocale(0, "");
	int const size = 10;
	int arr[size];
	int result = 1;
	int max;
	int minposition;
	int min;
	int zeronum = 0;

	for (int i = 0; i < size; i++)
	{
		cout << "Введите число --> ";
		cin >> arr[i];
	}
	cout << endl;

	for (int i = 0; i < size; i++)
	{
		result *= arr[i];
	}
	cout << "a. произведение всех элементов массива = ";
	cout << result << endl;
	for (int i = 0; i < size; i++)
	{
		if (i == 0)
		{
			max = arr[i];
		}
		if (i != 0 && arr[i] > max)
		{
			max = arr[i];
		}
	}
	cout << "b. максимальный элемент = ";
	cout << max << endl;
	for (int i = 0; i < size; i++)
	{
		if (i == 0)
		{
			minposition = i;
			min = arr[i];
		}
		if (i != 0 && arr[i] < min)
		{
			minposition = i;
			min = arr[i];
		}
	}
	cout << "c. позиция минимального элемента --> ";
	cout << minposition+1 << endl;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == 0)
		{
			zeronum += 1;
		}
	}
	cout << "d. количество элементов равных нулю --> ";
	cout << zeronum << endl;*/
	
	/*setlocale(0, "");
	int const size = 5;
	int arr[size];

	for (int i = 0; i < size; i++)
	{
		cout << "Введите число --> ";
		cin >> arr[i];
	}
	cout << "Положительные числа --> ";
	for (int i = 0; i < size; i++)
	{
		if (arr[i] > 0)
		{
			cout << arr[i]<<" ";
		}
	}
	cout << endl;
	cout << "Отрицательные числа --> ";
	for (int i = 0; i < size; i++)
	{
		if (arr[i] < 0)
		{
			cout << arr[i] << " ";
		}
	}
	cout << endl;*/
	
	
	
	system("pause");
}