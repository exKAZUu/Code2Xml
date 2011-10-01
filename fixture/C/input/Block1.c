#include <stdio.h>

int main() {
	int i = 0;
	
	if (i == 0)
		printf("test");
	
	if (i <= 0 && (i >= 0 || i != 0))
		printf("test");
	
	switch(i)
		case 0:
		printf("test");
	
	while (i != 0)
		printf("test");
	
	do
		printf("test");
	while (i != 0);
	
	for (i = 0; i < 0; i++)
		printf("test");
	return 0;
}
