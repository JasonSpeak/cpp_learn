#include <iostream>
#include <vector>
#include<stdlib.h>

using namespace std;

#pragma region 获取数组--getNum()

vector<int> getNum()
{
	vector<int> num;

	int n = 0;
	cin >> n;
	for (int i = 0; i < n; ++i)
	{
		int temp = 0;
		cout << "请输入第" << i + 1 << "个数字" << endl;
		cin >> temp;
		num.push_back(temp);
	}
	return num;
}

#pragma endregion

#pragma region BubbleSort...冒泡排序--run_bubble_sort()


vector<int> bubble_sort(vector<int> num)
{
	int size = num.size();
	for (int i = 0; i < size; i++)
	{
		for (int j = i; j < size; j++)
		{
			if (num[i] > num[j])
			{
				int temp;
				temp = num[i];
				num[i] = num[j];
				num[j] = temp;
			}
		}
		for (auto item : num)
		{
			cout << "第" << i << "次" << item << endl;
		}
	}
	return num;
}

void run_bubble_sort()
{
	vector<int> num = getNum();
	vector<int> res = bubble_sort(num);
	for (auto i : res)
	{
		cout << i << endl;
	}
}

#pragma endregion

#pragma region Quicksort...快速排序--run_quick_sort()

void quick_sort(vector<int> &num, int left, int right)
{
	if(left<right)
	{
		int i = left;
		int j = right;
		int x = num[left];
		while (i < j)
		{
			while (i < j && num[j] >= x)
			{
				j--;
			}
			if (i < j)	
			{
				int temp = num[j];
				num[j] = num[i];
				num[i] = temp;
			}
			while (i < j && num[i] < x)
			{
				i++;
			}
			if (i < j)
			{
				int temp = num[j];
				num[j] = num[i];
				num[i] = temp;
				//j--;
			}
		}
		for (auto item : num)
		{
			cout << item << "&&" << endl;
		}
		cout << "i = " << i << endl;
		cout << "j = " << j << endl;
		cout << "\n" << endl;
		quick_sort(num, left, i - 1);
		quick_sort(num, i + 1, right);

	}
}


void run_quick_sort()

{
	vector<int> num = getNum();
	int left = 0;
	int right = num.size() - 1;
	cout << "right = " << right << endl;
	quick_sort(num, left, right);
	cout << "结果为：" << endl;
	for (auto item : num)
	{
		cout << item << "\t" << endl;
	}
}
#pragma endregion

#pragma region SelectSort...选择排序--run_select_sort()

vector<int> select_sort(vector<int> num)
{
	int n = num.size();
	for (int i = 0; i < n-1; i++)
	{
		int min = i;
		for (int j = i + 1; j < n; j++)
		{
			if (num[j] < num[min])
			{
				min = j;
			}
		}
		if (min != i)
		{
			int temp = num[min];
			num[min] = num[i];
			num[i] = temp;
		}
	}
	return num;
}

void run_select_sort()
{
	vector<int> num = getNum();
	vector<int> res = select_sort(num);
	for (auto item : res)
	{
		cout << item << endl;
	}
}

#pragma endregion

#pragma region InsertSort...插入排序--run_insert_sort()
vector<int> insert_sort(vector<int> num)
{
	int n = num.size();
	for (int i = 1; i < n; i++)
	{
		int get = num[i];
		int j = i - 1;
		while (j >= 0 && num[j] > get)
		{
			num[j + 1] = num[j];
			j--;
		}
		num[j + 1] = get;
	}
	return num;
}

void run_insert_sort()
{
	vector<int> num = getNum();
	vector<int> res = insert_sort(num);
	for (int item : res)
	{
		cout << item << endl;
	}
}
#pragma endregion

int main()
{
	run_insert_sort();
	system("pause");
	return 0;
}



