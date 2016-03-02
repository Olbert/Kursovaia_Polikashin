#include "stdafx.h"
#include <fstream>
#include <iostream>
//using namespace std;
std::ifstream cin("input.txt");
//std::ofstream cout("output.txt");
int _tmain(int argc, _TCHAR* argv[])
{
	long long a, b, c;
	cin >> a >> b;
	while (b) {
		c = a % b;
		a = b;
		b = c;
	}
	std::cout << "Ответ: " << abs(a);
	return 0;
}
