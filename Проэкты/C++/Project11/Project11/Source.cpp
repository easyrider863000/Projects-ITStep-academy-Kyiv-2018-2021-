#include<iostream>
#include<ctime>
#include<iomanip>
using namespace std;

int main()
{
	/*int min;
	int max;
	cin >> min >> max;
	int const size = 10;
	int arr[size];
	int sum = 0;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min+1) + min;
	}
	cout << endl;
	for (int j = 0; j < size; j++)
	{
		cout << j+1 << " -> " << arr[j] << endl;
	}
	cout << endl;
	for (int g = 0; g < size; g++)
	{
		sum = sum + arr[g];
	}

	cout << "sum = " << sum << endl;
	cout << endl;*/



	/*int min = 0;
	int max = 10;
	int const size = 10;
	int arr[size];
	int sum = 0;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	cout << endl;

	for (int j = 0; j < size; j++)
	{
		cout  << arr[j] << endl;
	}*/

	/*cout << endl;
	int n = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (arr[j] == arr[i]&&i!=j)
			{
				n++;
				if (n >=2)
				{
					cout << arr[i] << " ";
				}
			}
		}
	}*/
















	//149
	/*int min = 0;
	int max = 10;
	int const size = 10;
	int arr[size];
	int num;
	int n = 0;
	cout << "Enter number --> ";
	cin >> num;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		cout << arr[i]<<" ";
	}
	cout << endl;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == num)
		{
			cout << "yes"<<endl;
			n = 1;
			break;
		}



	}
	if (n == 0)
	{
		cout << "no" << endl;
	}*/

	//150

	/*int min = 0;
	int max = 4;
	int const size = 3;
	int arr[size];
	bool f = true;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	for (int i = 0; i < size-1; i++)
	{
		if (arr[i] >= arr[i+1])
		{
			f = false;
		}
	}
	if (f)
	{
		cout << "no" << endl;
	}
	else
	{
		cout << "yes" << endl;
	}*/

	//151

	/*int min = 0;
	int max = 10;
	int const size = 10;
	int arr[size];
	int num;
	int n = 0;
	int counter = 0;
	cout << "Enter number --> ";
	cin >> num;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == num)
		{
			counter += 1;
		}у	}
	if (counter == 0)
	{
		cout << "nie powtoriaetsa" << endl;
	}
	if (counter > 0)
	{
		cout << "powtoriaetsa " << counter << " raz" << endl;
	}*/


	/*int min = 0;
	int max = 10;
	int const size = 10;
	int arr[size];
	int num;
	bool f = true;
	int n = 0;
	cout << "Enter number --> ";
	cin >> num;
	srand(time(0));
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
	}
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (arr[i] == arr[j])
			{
				f = false;
			}
		}
	}
	if (f)
	{
		cout << "no" << endl;
	}
	else
	{
		cout << "yes";
	}
	*/



	/*int max = 200;
	int min = 150;
	int const size = 10;
	int result = 0;
	int arr[size];
	int srrost;
	int counter = 0;
	for (int i = 0; i < size; i++)
	{
		arr[i] = rand() % (max - min + 1) + min;
		cout << arr[i]<<" ";
	}
	cout << endl;
	
	for (int i = 0; i < size; i++)
	{
		result += arr[i];
	}
	srrost = result / size;
	cout << "srednii rost = " << srrost << endl;
	
	for (int i = 0; i < size; i++)
	{
		if (arr[i] > srrost)
		{
			counter += 1;
		}
	}
	cout << counter << endl;*/
	
	
	/*const int row = 3, column = 4;
	int arr[row][column] = { 1,2,3,4,5,6,7,8,9,10,11,12 };

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/

	
	/*const int row = 10, column = 10;
	int arr[row][column];

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			if (i == j)
			{
				arr[i][j] = i;
			}
			else
			{
				arr[i][j] = 0;
			}
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/
	
	
	/*const int row = 10, column = 10;
	int arr[row][column];
	int n = 1;
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			arr[i][j] = n++;
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/
	
	
	/*const int row = 10, column = 10;
	int arr[row][column];
	int n = 1;
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0,n = 1; j < column; j++)
		{
			if (i > j)
			{
				arr[i][j] = 0;
			}
			else
			{
				arr[i][j] = n++;
			}
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/
	
	
	
	/*const int row = 5, column = 5;
	int arr[row][column];
	int n = 1;
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++, n++)
		{
			
			if (i % 2 == 0)
			{
				arr[i][j] = n;
			}
			else
			{
				arr[i][column - 1 - j] = n;
			}
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/
	
	
	/*const int row = 5, column = 5;
	int arr[row][column];
	int n = 1;
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++, n++)
		{
	
			if (i % 2 == 0)
			{
				arr[i][j] = n;
			}
			else
			{
				arr[i][column - 1 - j] = n;
			}
		}
	}
	
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			cout << left << setw(3) << arr[i][j];
		}
		cout << endl;
	}*/
	






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

	for (int i = 0; i < size/2; i++)
	{
		tmp = arr[i];
		arr[i] = arr[size - i-1];
		arr[size - i-1] = tmp;
	}
	cout << "измененный массив\t";
	for (int i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;

	


	setlocale(0, "");
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
		
					arr[j] = arr[j+1];

				}
			}
		}
		for (int i = 0; i < size; i++)
		{
			if (arr[i] > max||arr[i]<min)
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
	cout << endl;


	setlocale(0, "");
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
	
	cout << "чаще всего встречаться элемент " << arr[index] << endl;

	
	setlocale(0, "");
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
		for (int j = size -1; j > 0; j--)
		{
			arr[j] = arr[j - 1];
		}
		arr[0] = tmp;
	}
	cout << "измененный массив\t";
	for (int i = 0; i < size; i++)
	{
		cout << arr[i]<<" ";
	}
	cout << endl;*/
	

	/*setlocale(0, "");
	int n;
	int result = 0;
	cout << "enter --> ";
	cin >> n;
	const int row = 4, col = 11;
	int arr[row][col];
	srand(time(0));
	for (int i = 0; i < col; i++)
	{
		for (int j = 0; j < row; j++)
		{
			arr[i][j] = rand() % 15 + 15;
		}
	}

	for (int i = 0; i < col; i++)
	{
		for (int j = 0; j < row; j++)
		{
			cout << arr[i][j] << " ";
		}
		cout << endl;
	}

	for (int i = 0; i < col; i++)
	{


		result += arr[n - 1][i];

	}
	cout << result << endl;*/




	/*setlocale(0, "");
	int n = 2;
	const int row = 3, col = 3;
	int arr[row][col] = { 0,1,2,1,0,3,2,3,0 };
	srand(time(0));
	for (int i = 0; i < col; i++)
	{
		for (int j = 0; j < row; j++)
		{
			arr[i][j] = rand() % 15 + 15;
		}
	}
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			if (arr[i][j] != arr[j][i])
			{
				n = 1;
			}
		}
	}

	if (n == 2)
	{
		cout << "симетрично" << endl;
	}
	else
	{
		cout << "не симетрично" << endl;
	}*/


	/*int min = 0;
	int max = 1;
	int count = 0;
	setlocale(0, "");
	const int row = 12, col = 36;
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
		count = 0;
		cout << "вагон - " << i + 1 << endl;
		cout << "свободные места - ";
		for (int j = 0; j < col; j++)
		{
			if (arr[i][j] == 0)
			{
				cout << " " << j + 1;
				count++;
			}
		}
		cout << endl << "количество свободных мест - " << count;
		cout << endl << endl;
	}

	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < col; j++)
		{
			cout << arr[i][j] << " ";
		}
		cout << endl;
	}*/
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	// -----------------------------------------------------------------------------------классная работа 

	/*setlocale(0, "");
	int const row = 5;
	int const column = 5;
	int arr[row][column];
	int min = 0;
	int max = 3;
	int sum = 0;
	int tmp = 0;
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
		sum = 0;
		for (int j = 0; j < column; j++)
		{
			sum += arr[i][j];
		}
		if (tmp < sum)
		{
			tmp = sum;
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

	cout << tmp << endl;*/
	
	
	
	
	
	
	
	
	
	



	
	
	system("pause");
}