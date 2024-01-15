#include<iostream>

using namespace std;

void print_array(int arr[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}

bool priam(double h1, double w1, double h2, double w2)
{
	if ((h1>h2&&w1>w2)|| (h1<h2&&w1<w2))
	{
		return true;
	}
	else
	{
		return false;
	}
}

void print_array(int arr[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}


void fill_array(int arr[], int size)
{
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % 10;
	}
} //--------------------------- 1

void fill_array(int arr[][4], int row, int col)
{
	for (int i = 0; i < row; i++)
	{

		for (int j = 0; j < col; j++)
		{
			arr[i][j] = rand() % 10;
		}
	}
}

void hello(int n = 1)
{
	for (int i = 0; i < n; i++)
	{
		cout << "hello world" << endl;
	}
} // -----------------------------2

int Sum(int a = 0, int b = 0, int c = 0)
{
	return a + b + c;
}






int main()
{
	/*const int s1 = 5, s2 = 7;
	int arr[s1]{ 1,2,3,4,5 };
	int mas[s2]{ 8,5,1,2,3,4,5 };
	print_array(arr, s1);
	print_array(mas, s2);*/

	/*setlocale(0, "");
	double h1, w1, h2, w2;
	cin >> h1;
	cin >> w1;
	cin >> h2;
	cin >> w2;

	if (priam(h1, w1, h2, w2) == true)
	{
		cout << "влазит " << endl;
	}
	if (priam(h1, w1, h2, w2) == false)
	{
		cout << "не влазит " << endl;
	}*/

	/*const int size = 10;
	int arr[size];
	fill_array(arr, size);
	print_array(arr, size);*/ // ---------1

	/*hello(3);
	cout << endl;
	hello();*/ // --------------2

	/*cout << Sum(1, 3) << endl;*/




	//system("pause");
}
