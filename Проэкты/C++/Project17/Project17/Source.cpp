#include<iostream>
#include<time.h>
#include<iomanip>

using namespace std;

int main()
{
	/*setlocale(0, "");
	int const row = 5;
	int const column = 5;
	int arr[row][column];
	int min = 1;
	int max = 10;
	int sumrow = 0;
	int sumcolumn = 0;
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << right << setw(3) << arr[i][j];
		}
		cout << endl;
	}
	cout << endl;


	for (int j = 0; j < column; j++)
	{
		sumrow = 0;
		for (int i = 0; i < row; i++)
		{
			sumrow += arr[j][i];
		}
		cout << "����� ��������� " << j + 1 << " ������ = " << sumrow << endl;
	}
	cout << endl;




	for (int j = 0; j < row; j++)
	{
		sumcolumn = 0;
		for (int i = 0; i < column; i++)
		{
			sumcolumn += arr[i][j];
		}
		cout << "����� ��������� " << j + 1 << " ������� = " << sumcolumn << endl;
	}
	cout << endl;*/

	/*setlocale(0, "");
	int const row = 2;
	int const column = 2;
	int arr[row][column];
	int min = 1;
	int max = 10;
	int sum30 = 0;
	int nokol = 0;
	int sums = 0;
	double middle = 0;
	int n = 0;
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << right << setw(4) << arr[i][j];
		}
		cout << endl;
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			if (arr[i][j] > 30)
			{
				sum30 = sum30 + arr[i][j];
			}
		}
	}
	cout << "����� ��������� ������� ������� 30 = " << sum30 << endl;

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			if (arr[i][j] % 2 != 0)
			{
				nokol++;
			}
		}
	}
	cout << "���������� �������� ��������� ������� = " << nokol << endl;

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			if (arr[i][j] % 2 == 0)
			{
				middle += arr[i][j];
				n++;
			}
		}
	}
	middle = middle / n;
	cout << "������� �������������� ������ ��������� ������� = " << middle << endl;
	int s;
	cout << "������� ����� --> ";
	cin >> s;
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			if (s == i + j)
			{
				sums += arr[i][j];
			}
		}
	}
	cout << "����� ��������� �������, ����� �������� ������� ����� s = " << sums << endl;*/




	/*setlocale(0, "");
	int const row = 3;
	int const column = 3;
	int arr[row][column];
	int min = 1;
	int max = 450;
	int sum = 0;
	srand(time(0));
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			arr[i][j] = rand() % (max - min + 1) + min;
		}
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			sum += arr[i][j];
		}
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << right << setw(4) << arr[i][j];
		}
		cout << endl;
	}
	cout << "����� ��������� ���������� ������� = " << sum << endl;
	if (sum / 1000 >= 1)
	{
		cout << "����� ��������� ���������� ������� ��������� �������������� ������" << endl;
	}
	else
	{
		cout << "����� ��������� ���������� ������� �� ��������� �������������� ������" << endl;
	}*/


	//system("pause");
}