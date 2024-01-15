#include<iostream>
using namespace std;

int main()
{
	setlocale(0, "");
	const int size = 5;
	int arr[size];

	for (int i = 0; i < size; i++)
	{
		cin>>arr[i];
	}

	for (int i = 0; i < 5; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;








	system("pause");
}