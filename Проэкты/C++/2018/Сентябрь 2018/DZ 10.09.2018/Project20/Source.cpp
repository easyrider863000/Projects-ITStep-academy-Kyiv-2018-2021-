#include<iostream>
using namespace std;

double ARR_Min(double arr[],int size)
{
	double min;
	for (int i = 0; i < size; i++)
	{
		if (i == 0)
		{
			min = arr[i];
		}
		if (i!=0&&arr[i] < min)
		{                            //-----------------------------------------a
			min = arr[i];
		}
		else
		{
			min = min;
		}
	}
	return min;
}
double pos_1_max(double arr[], int size)
{
	int pos;
	int max;
	for (int i = 0; i < size; i++)
	{
		if (i == 0)
		{
			max = arr[i];
			pos = i;
		}                                ////---------------------------b

		if (i != 0 && arr[i] > max)
		{
			max = arr[i];
			pos = i;
		}
	}
	return pos+1;
}
double pos_last_max(double arr[], int size)
{
	int pos;
	int max;
	for (int i = 0; i < size; i++)
	{
		if (i == 0)
		{
			max = arr[i];
			pos = i;
		}                                ////---------------------------c

		if (i != 0 && arr[i] >= max)
		{
			max = arr[i];
			pos = i;
		}
	}
	return pos+1;
}
double odd_el(double arr[], int size)
{
	int result = 1;
	for (int i = 0; i < size; i++)
	{
		if ((int)arr[i] % 2 != 0)
		{
			result*= arr[i]; //--------------------d 
		}
	}
	return result;
}
double sum_od_pos(double arr[], int size)
{
	int sum = 0;
	for (int i = 0; i < size; i++)
	{
		if (i % 2 == 0)
		{
			sum += arr[i]; //--------------------e
		}
	}
	return sum;
}


int main()
{
	setlocale(0, "");
	const int size = 10;
	double arr[size]{ 1,2.3,3.5,1.4,0.5,6.9,12.5,14.0,2.8,11 };
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << "  ";
	}
	cout << endl;
	cout <<"минимальный элемент --> " <<ARR_Min(arr, size) << endl;
	cout <<"позиция первого вхождения максимального элемента --> " <<pos_1_max(arr, size) << endl;
	cout <<"позиция последнего вхождения максимального элемента --> " <<pos_last_max(arr, size) << endl;
	cout <<"произведение нечетных элементов --> " <<odd_el(arr, size) << endl;
	cout <<"сумма элементов находящихся на четных позициях --> " <<sum_od_pos(arr, size) << endl;
	system("pause");
}


