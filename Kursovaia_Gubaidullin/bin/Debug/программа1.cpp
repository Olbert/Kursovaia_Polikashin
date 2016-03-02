#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <time.h>
using namespace std;
int main()
{
	long double a, b, c;
	while (b) {
		c = a % b;
		a = b;
		b = c;
	}
	input >> a >> b;
	output << "Ответ: " << abs(a);
	return 0;
}


