#include<iostream>
using namespace std;

int main()

{
	/*setlocale(0, "");
	int num, result = 1;
	cout << "������� ����� : ";
	do {
		cin >> num;
		if (num != 0 && num > 0)
		{
			result = result * num;
		}




	} while (num != 0);
	cout <<"���������: "<<result<<"."<<endl;



	system("pause");*/



	
	/*setlocale(0, "");
	int num, pop = 0;
	const int znum = 7;
	cout << "���� \"������ �����\".\n��������� \"�������\" ����� �� 1 �� 10. \n�������� ��� �� 5 �������. \n������� ����� � ������� <Enter>" << endl;
	
	
	do {
		cout << "--> ";
		cin >> num;
		if (num == znum)
		{
			cout << "�� ��������! ����������! " << endl;
			pop = 5;
		}

		if (num != znum)
		{
			cout << "���. " << endl;
			if (pop == 4)
			{
				cout << "�� ���������." << endl;
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
		cout << "������� ����� --> ";
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
	cout << "���������� ���� � 3 ������������� �����: " << kolnum << endl;
	system("pause");*/

	/*setlocale(0, "");
	int num, sum = 0, otr = 1;
	do{
		cout << "������� ����� --> ";
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
		cout << "����� ������������� ������! (" << sum << ')' << endl;
	}
	else
	{
		cout << "������������ ������������� ������! (" << otr << ')' << endl;
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

	cout <<"���������� ������������� ����� : "<<result << endl;
	cout <<"���������� ����� : "<<kontkol << endl;

	system("pause");*/


	setlocale(0, "");
	int num2, num1;
	cout << "���������� ����������� ������ ��������." << endl;
	for (int i = 0; i != 2; i++)
	{
		cout << "������� ����� --> ";
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


	cout << "��� = " << num1<<endl;
	system("pause");

	/*setlocale(0, "");
	int num,sum = 0,kontsum,outnum,kontnum;
	for (int i = 0; i < 5; i++)
	{
	cout << "������� ����� --> ";
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
	cout <<"����� "<<outnum<<" � ���������� ������ : "<<kontsum << endl;
	system("pause");*/

}
}