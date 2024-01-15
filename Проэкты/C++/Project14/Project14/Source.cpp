#include<iostream>
#include<time.h>
#include<iomanip>
using namespace std;

int main()
{

	
	/*int min = -20;
	int max = 10;
	int count = 0;
	setlocale(0, "");
	const int row = 3, col = 4;
	int arr[row][col];
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			if (arr[i][j] < 0)
			{
				count++;
			}
		}
	}
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << right << setw(4) << arr[i][j] ;
		}
		cout << endl;
	}

	cout << "Отрицательных чисел -> " << count << endl;*/
	
	
	/*int min = 0;
	int max = 10;
	int count = 0;
	setlocale(0, "");
	const int row = 6, col = 6;
	const int size = 6;
	int arr[row][col];
	int arr2[size];
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}
	cout << "Двумерный массив 6*6 : " << endl;
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}
	cout << endl;
	cout << "Одномерный массив 6 : " << endl;
	for (int j = 0; j < size; j++)
	{
		arr2[j] = rand() % (max - min + 1) + min;
	}

	for (int j = 0; j < size; j++)
	{
		cout <<left <<setw(3) <<arr2[j];
	}

	cout << endl;
	cout << endl;
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			if (i % 2 != 0)
			{
			
				arr[i][j] = arr2[j];

			}
		}
	}

	cout << "Измененный двумерный массив 6*6 : " << endl;
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}
	cout << endl;*/
	
	
	/*int min = 0;
	int max = 4;
	int count = 1;
	setlocale(0, "");
	const int row = 3, col = 4;
	int arr[row][col];
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			if (arr[i][j] != 0)
			{
				count = arr[i][j] * count;
			}
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << right << setw(2) << arr[i][j];
		}
		cout << endl;
	}

	cout << "произведение ненулевых элементов массива = "<<count << endl;*/
	



	/*int min = 0;
	int max = 10;
	setlocale(0, "");
	const int row = 5, col = 5;
	int arr[row][col];
	srand(time(0));

	for (int i = 0; i < row; ++i)
	{
		for (int j = 0; j < col; ++j)
		{
			arr[i][j] = rand() % (max - min + 1) + min;

		}

	}
	cout << "массив 6*6 :" << endl;
	for (int i = 0; i<row; ++i)
	{
		for (int j = 0; j < col; ++j)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}
	cout << endl;

	
	for (int i = 0; i < row; ++i) 
	{
		int tmp;
		tmp = arr[i][i];
		arr[i][i] = arr[i][row - 1 - i];
		arr[i][row - 1 - i] = tmp;
	}
	cout << "измененный массив 6*6 :" << endl;
	for (int i = 0; i<row; ++i) 
	{
		for (int j = 0; j < col; ++j)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}
	cout << endl;*/
		
	
		
	
		
		
	
	
	
	/*setlocale(0, "");
	int min = 0;
	int max = 10;
	const int row = 6, col = 6;
	const int size = 6;
	int arr1[row][col];
	int arr2[size];
	srand(time(0));
	cout << "массив 6*6 :" << endl;
	for (int i = 0; i<row; i++) 
	{
		for (int j = 0; j<col; j++)
		{
			arr1[i][j] = rand() % (max - min + 1) + min;
			cout << arr1[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;
	for (int i = 0; i<row; i += 2)
	{
		for (int j = 0; j < col; j++)
		{
			arr2[j] = arr1[i][j];
		}
		for (int j = 0; j < col; j++)
		{
			arr1[i][j] = arr1[i + 1][j];
		}
		for (int j = 0; j < col; j++)
		{
			arr1[i + 1][j] = arr2[j];
		}
	}
	cout << "измененный массив 6*6 :" << endl;
	for (int i = 0; i<row; i++)
	{
		for (int j = 0; j<col; j++)
		{
			cout << arr1[i][j] << " ";
		}
		cout << endl;
	}
	cout << endl;*/

	
	
	//system("pause");


}